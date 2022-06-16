import axios from 'axios';

const getPieces = () => new Promise((resolve, reject) => {
    // 
    axios.get(`https://localhost:7242/api/Pieces`)
        .then((response) => {
            resolve(Object.values(response.data));
        })
        .catch(reject);
});

const createPiece = (obj) => new Promise((resolve, reject) => {
    axios
        .post(`https://localhost:7242/api/Pieces`, obj)
        .then((response) => {
            const id = response.data.name;
            axios
                .patch(`https://localhost:7242/api/Pieces/${id}`)
                .then(() => {
                    getPieces().then(resolve);
                });
        })
        .catch(reject);
});

const updatePiece = (updateObj) => new Promise((resolve, reject) => {
    axios
        .patch(`https://localhost:7242/api/Pieces/${updateObj.id}`)
        .then(() => getPieces().then(resolve))
        .catch(reject);
});

const deletePiece = (id) => new Promise((resolve, reject) => {
    axios
        .delete(`https://localhost:7242/api/Pieces/${id}`)
        .then(() => getPieces().then(resolve))
        .catch(reject);
});

const getSinglePiece = (id) => new Promise ((resolve, reject) => {
    axios
        .get(`https://localhost:7242/api/Pieces/${id}`)
        .then((response) => {
            resolve(response.data);
        })
        .catch(reject);
});

export {
    getPieces,
    createPiece,
    updatePiece,
    deletePiece,
    getSinglePiece,
};