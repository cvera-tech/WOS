function setDogImage(url) {
    document.getElementById("dog-image").setAttribute("src", url);
}

function setErrorMessage(message) {
    document.getElementById("error-message").textContent = message;
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

makeRequest("POST", "og.ceo/api/breeds/image/xyzzy")
    .then(response => {
        setDogImage(response.message);
        return response;
    })
    .catch(message => setErrorMessage(message));//);