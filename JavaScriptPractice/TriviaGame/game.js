

async function getRandomClue() {
    const randomUrl = "https://jservice.io/api/random";
    let invalid = true;
    let clue;
    while (invalid) {
        const response = await fetch(randomUrl);
        if (response.ok) {
            const obj = await response.json();
            clue = obj["0"];
            if (clue.invalid_count === null) {
                invalid = false;
            } else {
                console.log("Invalid");
            }
        } else {
            console.log("Not OK");
        }
    }
    return clue;
}

async function buildPage() {
    let clue;
    try {
        clue = await getRandomClue();
    } catch (err) {
        console.error(err);
        return;
    }
    valueElement.innerHTML = clue.value;
    categoryElement.innerHTML = clue.category.title;
    questionElement.innerHTML = clue.question;
    answerElement.removeAttribute('disabled');
    registerEventHandlers();
    correctAnswer = clue.answer;
    console.log(correctAnswer);
}

function registerEventHandlers() {
    answerElement.addEventListener('keyup', () => {
        const answer = answerElement.value;
        const matches = answer.match(/\w{2,}/g);
        if (matches !== null) {
            submitElement.removeAttribute('disabled');
        } else {
            submitElement.setAttribute('disabled', 'disabled');
        }
    });
    submitElement.addEventListener('click', () => {
        const answer = answerElement.value;
        const processedAnswer = processAnswer(answer);
        const processedCorrectAnswer = processAnswer(correctAnswer);
        if (processedAnswer === processedCorrectAnswer) {
            console.log("Hooray");
        }
    });
}

// TODO Add support for alternative answers
function processAnswer(answer) {
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

const valueElement = document.getElementById('value');
const categoryElement = document.getElementById('category');
const questionElement = document.getElementById('question');
const answerElement = document.getElementById('answer');
const submitElement = document.getElementById('submit');
let correctAnswer;
buildPage();