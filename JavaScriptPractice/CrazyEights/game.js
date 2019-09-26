(async function () {
    const deckIdKey = 'DECK_ID';
    const computerPileName = 'computer_pile';
    const discardPileName = 'discard_pile';
    const humanPileName = 'human_pile';
    const computerDivId = 'computer';
    const playAreaDivId = 'play-area';
    const deckDivId = 'deck';
    const discardDivId = 'discard-pile';
    const humanDivId = 'human';
    const apiUrl = "https://deckofcardsapi.com/api/deck/";
    let computerPile = [];
    let discardPile = [];
    let humanPile = [];
    let remaining = 0;

    /**
     * Returns an array of cards drawn from the deck.
     * @param {Number} num 
     */
    async function drawDeckCards(num) {
        const deckId = getDeckId();
        const response = await fetch(apiUrl + deckId + '/draw/?count=' + num);
        const obj = await response.json();
        const cards = obj.cards;
        remaining = obj.remaining;
        return cards;
    }

    async function drawPileCard(pileName, code) {
        const deckId = getDeckId();
        const response = await fetch(apiUrl + deckId + '/pile/' + pileName + '/draw/?cards=' + code);
        const obj = await response.json();
        const card = obj.cards[0];
        return card;
    }

    /**
     * Returns a Promise for a deck.
     * @param {Number} id 
     */
    function fetchDeck(id) {
        return fetch(apiUrl + id + '/');
    }

    /**
     * Returns a Promise for a new shuffled deck.
     */
    function fetchNewShuffledDeck() {
        return fetch(apiUrl + '/new/shuffle/');
    }

    /**
     * Returns a Promise for the list of cards in a pile.
     * @param {string} pileName 
     */
    function fetchCardsInPile(pileName) {
        const deckId = getDeckId();
        return fetch(apiUrl + deckId + '/pile/' + pileName + '/list/');
    }

    /**
     * Returns the HTML element with the given ID.
     * @param {string} id 
     */
    function gebi(id) {
        return document.getElementById(id);
    }

    async function getDeck() {
        let deck;
        let response;
        const deckId = getDeckId();
        if (deckId !== null) {
            response = await fetchDeck(deckId);
        } else {
            response = await fetchNewShuffledDeck();
        }
        deck = await response.json();
        setDeckId(deck.deck_id);
        remaining = deck.remaining;
        return deck;
    }

    /**
     * Returns the deck ID in local storage.
     */
    function getDeckId() {
        return localStorage.getItem(deckIdKey);
    }

    /**
     * Returns the array of cards in a pile.
     * @param {string} pileName 
     */
    async function getPile(pileName) {
        const response = await fetchCardsInPile(pileName);
        const obj = await response.json();
        return obj.piles[pileName].cards;
    }

    /**
     * Returns the top card of the discard pile.
     */
    function getTopCard() {
        return discardPile[discardPile.length - 1];
    }

    async function initGame() {
        const deck = await getDeck();

        if (deck.remaining === 52) {
            // New deck; set up piles.
            const initialCards = await drawDeckCards(11);
            const initComputerPile = initialCards.slice(0, 5);
            const initDiscardPile = initialCards.slice(10);
            const initHumanPile = initialCards.slice(5, 10);

            const putPileResponses = await Promise.all([
                putCardInPile(computerPileName, initComputerPile),
                putCardInPile(discardPileName, initDiscardPile),
                putCardInPile(humanPileName, initHumanPile)
            ]);

            const putPileObjects = await Promise.all(putPileResponses.map(response => response.json()));
        }

        // Get piles
        const fetchPileResponses = await Promise.all([
            fetchCardsInPile(computerPileName),
            fetchCardsInPile(discardPileName),
            fetchCardsInPile(humanPileName)
        ]);
        const fetchPileObjects = await Promise.all(fetchPileResponses.map(response => response.json()));
        computerPile = fetchPileObjects[0].piles[computerPileName].cards;
        discardPile = fetchPileObjects[1].piles[discardPileName].cards;
        humanPile = fetchPileObjects[2].piles[humanPileName].cards;

        renderCards();
        registerEventHandlers();
    }

    /**
     * Returns whether or not two card codes match.
     * @param {string} playCardCode 
     * @param {string} topCardCode 
     */
    function matchCardCode(playCardCode, topCardCode) {
        return (playCardCode[0] === topCardCode[0])
            || (playCardCode[1] === topCardCode[1])
            || (playCardCode[0] === '8');
    }

    async function putCardInPile(pileName, cards) {
        const deckId = getDeckId();
        const cardCodes = cards.map(card => card.code).join(',');
        return await fetch(apiUrl + deckId + '/pile/' + pileName + '/add/?cards=' + cardCodes);
    }

    function registerEventHandlers() {
        gebi(humanDivId).addEventListener('click', async event => {
            const targetElement = event.target;
            if (!targetElement.hasAttribute('data-code')) {
                return;
            }
            const cardCode = targetElement.getAttribute('data-code');
            const topCardCode = getTopCard().code;

            if (matchCardCode(cardCode, topCardCode)) {
                // Put card in discard
                console.log('match');
            }

            renderCards();
        });
        gebi(deckDivId).addEventListener('click', async () => {
            // draw a card
            const drawnCard = (await drawDeckCards(1))[0];
            const drawnCardCode = drawnCard.code;
            console.log(drawnCardCode);
            await putCardInPile(humanPileName, [drawnCard]);

            humanPile = await getPile(humanPileName);
            debugger;
            renderCards();
        });
    }

    function renderCards() {
        // computer cards
        const computerImages = computerPile
            .map(() => '<div class="card card-down"></div>');
        gebi(computerDivId).innerHTML = computerImages.join('');

        // human cards
        const humanImages = humanPile
            .map(card => '<img src="' + card.image + '" class="card card-up" data-code="' + card.code + '">');
        gebi(humanDivId).innerHTML = humanImages.join('');

        // play area
        const topCard = getTopCard();
        const topCardUrl = topCard.image;
        gebi(discardDivId).innerHTML = '<img src="'
            + topCardUrl + '" class="card card-up">';
    }

    function setDeckId(id) {
        localStorage.setItem(deckIdKey, id);
    }

    await initGame();
    console.log(remaining);
})();