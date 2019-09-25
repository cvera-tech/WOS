const randomUrl = "https://jservice.io/api/random";

async function getRandomClue() {
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
    console.log(clue);
}

getRandomClue();