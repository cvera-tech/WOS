
const randomUrl = "https://dog.ceo/api/breeds/image/random";
const breedsUrl = "https://dog.ceo/api/breeds/list/all";

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

// asyncDogFetch();


async function fetchAllDogBreeds() {
    try {
        const doggoBreeds = await fetch(breedsUrl);
        const json = await doggoBreeds.json();
        return json;
    } catch (err) {
        setErrorMessage(err);
    }
}

async function createDogList() {
    const dogsList = document.getElementsByClassName("dogs-list").item(0);
    const json = await fetchAllDogBreeds();
    const breeds = json.message;
    for (breed in breeds) {
        if (breeds[breed].length !== 0) {
            for (subbreed of breeds[breed]){
                const listElement = document.createElement("li");
                listElement.innerHTML = breed + " (" + subbreed + ")";
                dogsList.append(listElement);
            }
        } else {
            const listElement = document.createElement("li");
            listElement.innerHTML = breed;
            dogsList.append(listElement);
        }
    }
}
// createDogList();

function createDogList(array) {
    const dogsList = document.getElementsByClassName("dogs-list").item(0);
    for (breed in array) {
        if (array[breed].length !== 0) {
            for (subbreed of array[breed]){
                const listElement = document.createElement("li");
                listElement.innerHTML = breed + " (" + subbreed + ")";
                dogsList.append(listElement);
            }
        } else {
            const listElement = document.createElement("li");
            listElement.innerHTML = breed;
            dogsList.append(listElement);
        }
    }
}

async function BuildPage() {
    const allPromise = Promise.all([fetch(breedsUrl), fetch(randomUrl)]);
    const allResponse = await allPromise;
    const breedsResponse = allResponse[0];
    const breedsObj = await breedsResponse.json();
    createDogList(breedsObj.message);
    const urlResponse = allResponse[1];
    const urlObj = await urlResponse.json();
    setDogImage(urlObj.message);
}

BuildPage();