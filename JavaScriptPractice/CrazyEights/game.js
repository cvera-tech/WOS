(function () {
    const deckIdKey = 'DECK_ID';
    const apiUrl = "https://deckofcardsapi.com/api/deck/";
    let remaining = 0;

    async function fetchDeck(id) {
        return fetch(apiUrl + id + '/');
    }

    async function fetchNewShuffledDeck() {
        return fetch(apiUrl + '/new/shuffle/');
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
        console.log(deck);
        return deck;
    }

    function matchCard(playedCard, topCard) {
        // TODO
    }

    getDeck();
})();