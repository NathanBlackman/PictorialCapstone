// import React, { useState, useEffect } from "react";
// import { useNavigate, Link } from "react-router-dom";
// import { getArtistUsers } from "../api/Data/ArtistData";
// import { Button } from "reactstrap";
// import ArtistCard from "../Components/ArtistCard";

// export default function Artist() {
//     const [artistUsers, setArtistUsers] = useState([]);
    
//     useEffect(() => {
//         let isMounted = true;

//         if (isMounted) {
//             getArtistUsers().then(setArtistUsers);
//         }

//         return () => {
//             isMounted = false;
//         }
//     }, []);

//     let Navigate = useNavigate()
//     const handleClick = () => {
//         Navigate("/artistform");
//     }


//     return (
//         <div>
//             <h1>Artist</h1>
//             <Link to={"/artistform"} >
//                 <Button type="button" onClick={handleClick}></Button>
//             </Link>

//             <div id="artist-container">
//                 {artistUsers.length ? (
//                     artistUsers.map((artistUser) => (
//                         <ArtistCard key={artistUser.id} artistUser={artistUser} setArtistUsers={setArtistUsers} />
//                     ))
//                 ) : (
//                     <h1>No Artists Found</h1>
//                 )}
//             </div>
//         </div>
//     );
// }