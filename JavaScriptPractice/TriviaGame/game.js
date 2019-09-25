(function () {
    /**
     * Calls getRandomClue and sets the page's elements to the clue's values.
     */
    async function buildPage() {
        let clue;
        try {
            clue = await getRandomClue();
        } catch (err) {
            console.error(err);
            return;
        }
        clueValue = clue.value;
        valueElement.innerHTML = clueValue;
        categoryElement.innerHTML = clue.category.title;
        questionElement.innerHTML = clue.question;
        answerElement.removeAttribute('disabled');
        answerElement.focus();
        correctAnswer = clue.answer;
        console.log(correctAnswer);
    }

    /**
     * Makes a GET request for a random clue and returns it if it is valid.
     */
    async function getRandomClue() {
        const randomUrl = "https://jservice.io/api/random";
        const validateClue = (clue) => {
            return (clue.invalid_count === null &&
                clue.question !== null &&
                clue.value !== null);
        };
        let valid = false;
        let clue;
        while (!valid) {
            const response = await fetch(randomUrl);
            if (response.ok) {
                const obj = await response.json();
                clue = obj["0"];
                valid = validateClue(clue);
            }
        }
        return clue;
    }

    /**
     * Processes an input string to remove extraneous words and characters.
     * @param {*} answer 
     */
    // TODO Add support for alternative answers
    // TODO Add removal of extraneous parenthesized information
    function processAnswerString(answer) {
        const answerArray = answer.toLowerCase().split(' ');
        const prunedArray = [];
        for (word of answerArray) {
            if (word !== 'the' && word !== 'a' &&
                word !== 'an' && word !== 'she' &&
                word !== 'he' && word !== 'her' &&
                word !== 'him' && word !== 'and' &&
                word !== 'but' && word !== 'or') {
                prunedArray.push(word);
            }
        }

        // Remove escape characters and quotes
        const noEscapeString = prunedArray.join(' ').split('\\').join('')
        const noQuotes = noEscapeString.split('"').join('').split("'").join('');
        return removeTags(noQuotes);
    }

    /**
     * Registers event handlers for the page (wow!).
     */
    function registerEventHandlers() {
        const submitHandler = function () {
            answerElement.setAttribute('disabled', 'disabled');
            submitElement.setAttribute('disabled', 'disabled');
            const answer = answerElement.value;
            const processedAnswer = processAnswerString(answer);
            const processedCorrectAnswer = processAnswerString(correctAnswer);
            if (processedAnswer === processedCorrectAnswer) {
                updateScore(clueValue);
            } else {
                updateScore(-clueValue);
            }
            answerElement.value = '';
            buildPage();
        }
        answerElement.addEventListener('keyup', () => {
            const answer = answerElement.value;
            const matches = answer.match(/\w{2,}/g);
            if (matches !== null) {
                submitElement.removeAttribute('disabled');
            } else {
                submitElement.setAttribute('disabled', 'disabled');
            }
        });
        submitElement.addEventListener('click', submitHandler);
        answerElement.addEventListener('keyup', event => {
            if (event.code === 'Enter')
                submitHandler();
        });
    }

    /**
     * Removes HTML tags.
     * @param {string} str 
     */
    function removeTags(str) {
        const result = str.match(/<(\w+)>(.*)<\/\1>/);
        if (result !== null) {
            return result[2];
        } else {
            return str;
        }
    }

    /**
     * Adds input value to the score and updates the element's class.
     * @param {*} value 
     */
    function updateScore(value) {
        score += value;
        scoreElement.innerHTML = score;
        if (score < 0) {
            scoreElement.setAttribute('class', 'negative');
        } else if (score > 0) {
            scoreElement.setAttribute('class', 'positive');
        } else {
            scoreElement.setAttribute('class', 'neutral')
        }
    }

    const valueElement = document.getElementById('value');
    const categoryElement = document.getElementById('category');
    const questionElement = document.getElementById('question');
    const answerElement = document.getElementById('answer');
    const submitElement = document.getElementById('submit');
    const scoreElement = document.getElementById('score');
    let correctAnswer;
    let score = 0;
    let clueValue = 0;
    registerEventHandlers();
    buildPage();
})();