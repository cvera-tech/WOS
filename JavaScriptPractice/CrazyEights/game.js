(async function () {
    const deckIdKey = 'DECK_ID';
    const computerPileName = 'computer_pile';
    const discardPileName = 'discard_pile';
    const humanPileName = 'human_pile';
    const computerDivId = 'computer';
    const playAreaDivId = 'play-area';
    const humanDivId = 'human';
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

    function gebi(id) {
        return document.getElementById(id);
    }

    async function getDeck() {
        let deck;
        let response;
        let deckId = localStorage.getItem(deckIdKey);
        if (deckId !== null) {
            response = await fetchDeck(deckId);
        } else {
            response = await fetchNewShuffledDeck();
        }
        deck = await response.json();
        localStorage.setItem(deckIdKey, deck.deck_id);
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

            const putPileResponses = await Promise.all([
                putCardInPile(deckId, computerPileName, initComputerPile),
                putCardInPile(deckId, discardPileName, initDiscardPile),
                putCardInPile(deckId, humanPileName, initHumanPile)
            ]);

            const putPileObjects = await Promise.all(putPileResponses.map(response => response.json()));
        }

        // Get piles
        const fetchPileResponses = await Promise.all([
            fetchCardsInPile(deckId, computerPileName),
            fetchCardsInPile(deckId, discardPileName),
            fetchCardsInPile(deckId, humanPileName)
        ]);
        const fetchPileObjects = await Promise.all(fetchPileResponses.map(response => response.json()));
        computerPile = fetchPileObjects[0].piles[computerPileName].cards;
        discardPile = fetchPileObjects[1].piles[discardPileName].cards;
        humanPile = fetchPileObjects[2].piles[humanPileName].cards;
        renderCards();
    }

    function matchCard(playedCard, topCard) {
        // TODO
    }

    async function putCardInPile(deckId, pileName, cards) {
        const cardCodes = cards.map(card => card.code).join(',');
        return await fetch(apiUrl + deckId + '/pile/' + pileName + '/add/?cards=' + cardCodes);
    }

    function renderCards() {
        // computer cards
        const computerImages = computerPile
            .map(() => '<div class="card card-down"></div>');
        gebi(computerDivId).innerHTML = computerImages.join('');

        // human cards
        const humanImages = humanPile
            .map(card => card.image)
            .map(url => '<img src="' + url + '" class="card card-up">');
        gebi(humanDivId).innerHTML = humanImages.join('');

        // play area
        const topCard = discardPile[discardPile.length - 1];
        const topCardUrl = topCard.image;
        gebi(playAreaDivId).innerHTML = '<img src="'
            + topCardUrl + '" class="card card-up"><div data-code="deck" class="card card-down"></div>';
    }

    await initGame();
})();