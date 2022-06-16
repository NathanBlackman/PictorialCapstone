import React from 'react';
import { deletePiece } from '../api/Data/PieceData';
import {
    Card,
    CardImg,
    CardBody,
    CardTitle,
    Button,
} from 'reactstrap';
import { Link } from 'react-router-dom';

export default function PieceCard({ piece, setPieces }) {
    // add authentication!
    const handleDelete = () => {
        if (window.confirm(`Delete ${piece.name}`) === true) {
            deletePiece(piece.id).then((piece) => setPieces(piece));
        }
    };

    return (
        <div>
            <Card className='piece-card'>
                <CardTitle tag="h5">
                    {piece.name}
                </CardTitle>
                <CardImg
                    alt={piece.name}
                    src={piece.image}
                    top
                    width="100%"
                />
                <CardBody>
                    <Link to={"/singlepiece/:id"}>
                        <Button>
                            Edit
                        </Button>
                    </Link>
                    <Button type="button" onClick={handleDelete}>Delete</Button>
                </CardBody>
            </Card>
        </div>
    )

}