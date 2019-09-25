

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
}

const valueElement = document.getElementById('value');
const categoryElement = document.getElementById('category');
const questionElement = document.getElementById('question');
const answerElement = document.getElementById('answer');
const submitElement = document.getElementById('submit');
buildPage();