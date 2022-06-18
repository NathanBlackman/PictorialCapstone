import firebase from "firebase/compat/app";
import "firebase/compat/auth";

const _apiUrl = "https://localhost:7242/api/ArtistUsers";

const _doesUserExist = (firebaseId) => {
    return getToken().then((token) =>
        fetch(`${_apiUrl}/DoesUserExist/${firebaseId}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then(resp => resp.ok));
}

export const getToken = () => {
    const currentUser = firebase.auth().currentUser;
    if (!currentUser) {
        throw new Error("Can't find current user. Are you logged in?");
    }
    return currentUser.getIdToken();
};


// export const login = (email, password) => {
//     return firebase.auth().signInWithEmailAndPassword(email, password)
//         .then((signInResponse) => _doesUserExist(signInResponse.user.uid))
//         .then((doesUserExist) => {
//             if (!doesUserExist) {
//                 logout();
//                 throw new Error("This User Exists in firebase, but")
//             }
//         })
//}

// export const logout = () => {
//     firebase.auth().signOut()
// };