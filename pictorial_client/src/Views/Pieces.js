import React, {useEffect, useState} from "react";
import { getPieces } from "../api/Data/PieceData";
import PieceCard from "../Components/PieceCard";

export default function Pieces() {
    const [pieces, setPieces] = useState([]);

    useEffect(() => {
        let isMounted = true;
        if (isMounted) {
            getPieces().then(setPieces);
        }
        return () => {
            isMounted = false;
        }
    }, [])

    const nullPieces = pieces.filter((allPieces) => allPieces.artistUserId === null)
    
    return (
        <div>
            <h1>Pieces</h1>
            {nullPieces.map((piece) => (
                <PieceCard 
                    key={piece.id}
                    piece={piece}
                    setPieces={setPieces}
                /> 
            ))}
        </div>
    );
}