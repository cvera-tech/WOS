function setDogImage(url) {
    document.getElementById("dog-image").setAttribute("src", url);
}

function setErrorMessage(message) {
    document.getElementById("error-message").textContent = message;
    console.log(message);
}

function setDogImageFetch(json) {
    if (json.status === "error") {
        throw new Error("HTTP Error: " + json.code);
    }
    else {
        setDogImage(json.message);
    }
}

function makeDogRequest() {
    const xhr = new XMLHttpRequest();
    xhr.open("GET", "https://dog.ceo/api/breeds/image/random");
    xhr.onload = function() {
        let response = JSON.parse(this.responseText);
        setDogImage(response.message);
    };

    xhr.send();
}

function makeRequest(HTTPVerb, url) {
    const promise = new Promise(
        function (resolve, reject) {
            const xhr = new XMLHttpRequest();
            xhr.open(HTTPVerb, url);
            xhr.onload = function() {
                if (xhr.status === 200) {
                    let response = JSON.parse(this.responseText);
                    resolve(response);
                }
                else {
                    let error = JSON.parse(this.responseText);
                    reject(error.message);
                }
            };
            xhr.onerror = function() {
                reject("TRANSACTION ERROR");
            };
            xhr.send();
        }
    );
    return promise;
}

// makeRequest("GET", "https://dog.ceo/api/breeds/image/random")
//     .then(response => {
//         setDogImage(response.message);
//         return response;
//     })
//     .catch(message => setErrorMessage(message));



const randomUrl = "https://dog.ceo/api/breeds/image/random";

// fetch(randomUrl)
//     .then(response => response.json())
//     .then(responseJSON => setDogImageFetch(responseJSON))
//     .catch(message => setErrorMessage(message));

async function asyncDogFetch() {
    try {
        const doggo = await fetch(randomUrl);
        const json = await doggo.json();
        setDogImageFetch(json);
    } catch (err) {
        setErrorMessage(err);
    }
}

asyncDogFetch();