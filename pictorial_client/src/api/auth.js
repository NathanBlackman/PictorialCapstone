import firebase from 'firebase/compat/app';

const signInUser = () => {
    const provider = new firebase.auth.GoogleAuthProvider();
    provider.addScope("profile");
    provider.addScope("email");
    firebase.auth().signInWithPopup(provider).then(function (result) {
        var token = result.credential.accessToken;
        var user = result.user;
    });
};


const signOutUser = () => new Promise((resolve, reject) => {
    firebase
        .auth()
        .signOut()
        .then(resolve)
        .catch(reject);
});

export {
    signInUser,
    signOutUser
}