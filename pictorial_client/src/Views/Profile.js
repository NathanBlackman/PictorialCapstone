import React, { useState, useEffect } from "react";
import PropTypes from "prop-types";
import { getPieces } from "../api/Data/PieceData";
import PieceCard from "../Components/PieceCard";

export default function Profile({ user }) {
    const [pieces, setPieces] = useState({})

    useEffect(() => {
        let isMounted = true;
        if (isMounted) {
            getPieces().then((pieces) => {
                setPieces(pieces)
            })
        }
        return () => {
            isMounted = false;
        }
    });

    const artistPieces = pieces.filter((allPieces) => allPieces.artistUserId)

    return (
        <div className="profile">
            <div className="profile-container">
                <image className="profile-pic" src={user.image} />
                <h1 className="profile-header">{user.name}</h1>
            </div>
            <div className="profile-pieces-container">
                {artistPieces.map((pieces) => (
                    <PieceCard 
                        pieces={pieces}
                        key={pieces.id}
                        setPieces={setPieces}
                    />
                ))};
            </div>
        </div>
    );
}

Profile.propTypes = {
    user: PropTypes.objectOf({
        name: PropTypes.string,
        image: PropTypes.string,
    }).isRequired,
};