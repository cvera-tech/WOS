function makeDogRequest() {
    const xhr = new XMLHttpRequest();
    xhr.open("GET", "https://dog.ceo/api/breeds/image/random");
    xhr.onload = function() {
        let response = JSON.parse(this.responseText);
        setDogImage(response.message);
    };

    xhr.send();
}

function setDogImage(url) {
    document.getElementById("dog-image").setAttribute("src", url);
}

makeDogRequest();