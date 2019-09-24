const fetch = require('node-fetch');
// console.log(fetch);

fetch("https://api.github.com/users/jbvera")
    .then((res) => res.json())
    .then((json) => console.log(json))
    .catch((reason) => console.log('rejected because', reason));