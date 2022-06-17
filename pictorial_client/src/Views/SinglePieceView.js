import React, { useEffect, useState } from "react";
import { useParams } from 'react-router-dom';
// import { getSinglePiece } from "../api/Data/PieceData";
import SinglePiece from '../Components/SinglePiece';

export default function SinglePieceView() {
    
    const [editPiece, setEditPiece] = useState([]);
    const { id } = useParams();

    useEffect(() => {
        // getSinglePiece(id).then(setEditPiece)
    }, [id]);



    return (
        <>
            <div className="single-piece-view">
                <h1>{editPiece.name}</h1>
                <div className="single-piece-body">
                    {/* finish the singlepiece component */}
                    <SinglePiece piece={editPiece} />
                </div>
            </div>
        </>
    );
}