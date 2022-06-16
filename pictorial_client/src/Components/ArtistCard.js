// import React from 'react';
// import PropTypes from 'prop-types';
// import { Link } from 'react-router-dom';
// // import { useNavigate } from 'react-router-dom';
// import { Button } from 'reactstrap';
// // import { deleteArtistUser } from '../api/Data/ArtistData';



// export default function ArtistCard( {artistUser} ) {
    
//     // const handleDelete = (method) => {
//     //     const del = confirm(`Delete ${artistUser.name}?`);
//     //     if (del && method === 'delete') {
//     //         deleteArtistUser(artistUser).then(setArtistUser);
//     //     }
//     // };

//     // OMIT THIS FILE!!!


//     return (
//         <div className="artist-card">
//             <h5 class="card-title">{artistUser.name}</h5>
//             <img src={artistUser.image} className="card-img" alt={artistUser.name} />
//             <div className="artist-card-body">
//                 <Link to={`/`} >
//                     <Button type="button" className="btn btn-primary" color="primary">View</Button>
//                 </Link>
//                 <Button type="button" className="btn btn-danger">Delete</Button>
//                 {/* onClick={handleDelete} */}
//             </div>
//         </div>
//     );
// }

// ArtistCard.propTypes = {
//     artistUser: PropTypes.shape({
//         firebaseId: PropTypes.string,
//         Image: PropTypes.string,
//         name: PropTypes.string
//     }).isRequired
// }