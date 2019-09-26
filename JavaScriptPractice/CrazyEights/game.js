(async function () {
    const deckIdKey = 'DECK_ID';
    const computerPileName = 'computer_pile';
    const discardPileName = 'discard_pile';
    const humanPileName = 'human_pile';
    const apiUrl = "https://deckofcardsapi.com/api/deck/";
    let computerPile = [];
    let discardPile = [];
    let humanPile = [];

    /**
     * Returns an array of cards drawn from the deck.
     * @param {Number} deckId 
     * @param {Number} num 
     */
    async function drawCards(deckId, num) {
        const response = await fetch(apiUrl + deckId + '/draw/?count=' + num);
        const obj = await response.json();
        const cards = obj.cards;
        return cards;
    }

    function fetchDeck(id) {
        return fetch(apiUrl + id + '/');
    }

    function fetchNewShuffledDeck() {
        return fetch(apiUrl + '/new/shuffle/');
    }

    function fetchCardsInPile(deckId, pileName) {
        return fetch(apiUrl + deckId + '/pile/' + pileName + '/list/');
    }

    async function getDeck() {
        let deck;
        let response;
        // let deckId = localStorage.getItem(deckIdKey);
        // if (deckId !== null) {
        //     response = await fetchDeck(deckId);
        // } else {
            response = await fetchNewShuffledDeck();
        // }
        deck = await response.json();
        localStorage.setItem(deckIdKey, deck.deck_id);
        // console.log(deck);
        return deck;
    }

    async function initGame() {
        const deck = await getDeck();
        const deckId = deck.deck_id;
        
        if (deck.remaining === 52) {
            // New deck; set up piles.
            const initialCards = await drawCards(deckId, 11);
            const initComputerPile = initialCards.slice(0, 5);
            const initDiscardPile = initialCards.slice(10);
            const initHumanPile = initialCards.slice(5, 10);
            const computerPileCodes = initComputerPile.map(card => card.code);
            const discardPileCodes = initDiscardPile.map(card => card.code);
            const humanPileCodes = initHumanPile.map(card => card.code);
            // console.log(computerPileCodes, discardPileCodes, humanPileCodes);

            const putPileResponses = await Promise.all([
                putCardInPile(deckId, computerPileName, initComputerPile),
                putCardInPile(deckId, discardPileName, initDiscardPile),
                putCardInPile(deckId, humanPileName, initHumanPile)
            ]);

            const putPileObjects = await Promise.all(putPileResponses.map(response => response.json()));
            // console.log(putPileObjects);
        }

        // Get piles
        const fetchPileResponses = await Promise.all([
            fetchCardsInPile(deckId, computerPileName),
            fetchCardsInPile(deckId, discardPileName),
            fetchCardsInPile(deckId, humanPileName)
        ]);
        const fetchPileObjects = await Promise.all(fetchPileResponses.map(response => response.json()));
        // console.log(fetchPileObjects);
    }

    function matchCard(playedCard, topCard) {
        // TODO
    }

    async function putCardInPile(deckId, pileName, cards) {
        const cardCodes = cards.map(card => card.code).join(',');
        return await fetch(apiUrl + deckId + '/pile/' + pileName + '/add/?cards=' + cardCodes);
    }

    await initGame();
    console.log(computerPile, discardPile, humanPile);
})();