import React from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { deletePiece } from '../api/Data/PieceData';
import {
    Button,
 } from 'reactstrap';


export default function SinglePiece({ piece }) {
    const Navigate = useNavigate();

    const handleDelete = () => {
        deletePiece(piece.id).then(() => {
            Navigate('/pieces')
        });
    };

    return (
        <div className="single-piece-card">
            <h1 className="single-piece-name">{piece.name}</h1>
            <image className="piece-card-img" src={piece.image} alt={piece.name} />
            <div className="single-piece-body">
                <Link to={`/edit-piece/${piece.id}`} >
                    <Button type="button">Edit</Button>
                </Link>
                <Button type="button" onClick={handleDelete}>Delete</Button>
            </div>
        </div>
    )
}