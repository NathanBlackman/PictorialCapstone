import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from 'react-router-dom';
import { Button } from 'reactstrap';
import PropTypes from 'prop-types';
import { createPiece, updatePiece } from "../api/Data/PieceData";
import {
    Form,
    FormGroup,
    Label,
} from 'reactstrap';

const initialState = {
    id: "",
    name: "",
    image: "",
    date: "",
    artistUserId: "",
}

export default function PieceForm(obj = {}) {
    
    const { id } = useParams();
    const [formInput, setFormInput] = useState(initialState);
    const Navigate = useNavigate();

    useEffect(() => {
        if (obj.id) {
            setFormInput(obj);
        } else {
            setFormInput(initialState);
        }
    }, [obj]);

    // const handleChange = (e) => {
    //     const { name, value } = e.target;

    //     setFormInput((prevState) => ({
    //         ...prevState,
    //         [name]: value
    //     }));
    // };

    const handleChangeName = (e) => {
        setFormInput({
            ...formInput,
            name: e.target.value
        });
    };

    const handleChangeImage = (e) => {
        setFormInput({
            ...formInput,
            image: e.target.value
        });
    };

    const resetForm = () => {
        setFormInput(initialState);
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        if (id) {
            updatePiece(formInput).then(() => {
                resetForm();
                Navigate('/pieces')
            });
        } else {
            createPiece({ ...formInput }).then(() => {
                resetForm();
                Navigate('/pieces')
            });
        }
    };
    
    return (
        <div>
            <Form onSubmit={handleSubmit} className="piece-form">
                <FormGroup>
                    <Label htmlFor="piece-name">
                        Piece Name
                    </Label>
                    <input
                        id="piece-name"
                        name="piece-name"
                        type="text"
                        placeholder="Enter Piece Name"
                        value={formInput.name || ""}
                        onChange={handleChangeName}
                        required
                    />
                </FormGroup>
                <FormGroup>
                    <Label htmlFor="piece-image">
                        Piece Image
                    </Label>
                    <input
                        id="piece-image"
                        name="piece-image"
                        type="text"
                        placeholder="Image Url"
                        value={formInput.image || ""}
                        onChange={handleChangeImage}
                        required
                    />
                </FormGroup>
                <FormGroup htmlFor="test-field">
                    <Label>
                        Test Field
                    </Label>
                    <input 
                        id="test-field"
                        name="test-field"
                        type="text"
                        required
                    />
                </FormGroup>
                <Button type="submit" className="btn btn-success" id="artist-user-form-btn">
                    {obj.id ? 'Update' : 'Submit'}
                </Button>
            </Form>
        </div>
    );
}

PieceForm.propType = {
    obj: PropTypes.shape(PropTypes.obj),
};

PieceForm.defaultProps = {
    obj: {},
};

// PieceForm.propType = {
//     piece: PropTypes.shape({
//         id: PropTypes.string,
//         name: PropTypes.string,
//         image: PropTypes.string,
//         date: PropTypes.string,
//         artistUserId: PropTypes.string
//     }).isRequired
// };