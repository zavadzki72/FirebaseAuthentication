//REFERENCIA -> https://balta.io/blog/aspnetcore-3-1-autenticando-sua-api-com-google-via-firebase

$(document).ready(function () {

    var firebaseConfig = {
        apiKey: "API-KEY",
        authDomain: "DOMAIN",
        projectId: "PROJECT-ID",
        storageBucket: "STORAGE",
        messagingSenderId: "MESSAGE-SENDER-ID",
        appId: "APP-ID",
        measurementId: "MEASUREMENT-ID"
    };

    firebase.initializeApp(firebaseConfig);
});

function login() {

    var provider = new firebase.auth.GoogleAuthProvider();
    provider.addScope('https://www.googleapis.com/auth/contacts.readonly');

    firebase.auth().signInWithPopup(provider).then(function (result) {

        firebase.auth()
            .currentUser
            .getIdToken()
            .then((idToken) => {
                console.log(idToken);
            }).catch(function (error) {
                console.log(error);
            });

    }).catch(function (error) {
        console.log(error);
    });
}