import React, { useEffect } from 'react';
import useParams from 'react-router-dom';
import { getSinglePiece } from '../api/Data/PieceData';
import PieceForm from './PieceForm';

export default function EditPiece() {
    const { id } = useParams();
    const [editPiece, setEditPiece] = useParams();

    useEffect(() => {
        getSinglePiece(id).then(setEditPiece);
    }, []);

    return (
        <div className="edit-piece-form">
            <PieceForm obj={editPiece} />
        </div>
    )
}