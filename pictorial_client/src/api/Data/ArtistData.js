import axios from 'axios';
import { getToken } from '../authManager';

const dbUrl = `https://localhost:7242/api/ArtistUser`

const getArtistUsers = () => new Promise((resolve, reject) => {
    return getToken().then((token) => {
        axios
            .get(`${dbUrl}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            })
            .then((response) => resolve(response.data))
            .catch(reject);
    });
});

const getArtistUser = (firebaseId) => new Promise((resolve, reject) => {
    return getToken().then((token) => {
        axios
            .get(`${dbUrl}/${firebaseId}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            })
            .then((response) => resolve(response.data))
            .catch(reject);
    });
});

const createArtistUser = (artistUser) => new Promise((resolve, reject) => {
    return getToken().then((token) => {
        axios
            .post(dbUrl, artistUser, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            })
            .then((response) => resolve(response.data))
            .catch(reject);
    });
});

const updateArtistUser = (artistUser) => new Promise((resolve, reject) => {
    return getToken().then((token) => {
        axios
            .patch(`${dbUrl}/${artistUser.firebaseId}`, artistUser, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            })
            .then(() => getArtistUsers().then(resolve))
            .catch(reject);
        });
});

const deleteArtistUser = (artistUser) => new Promise((resolve, reject) => {
    return getToken().then((token) => {
        axios
            .delete(`${dbUrl}/${artistUser.firebaseId}`, artistUser, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            })
            .then(() => getArtistUsers().then(resolve))
            .catch(reject);
    })
})

export {
    getArtistUsers,
    getArtistUser,
    createArtistUser,
    updateArtistUser,
    deleteArtistUser,
}