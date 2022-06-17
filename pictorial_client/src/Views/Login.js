import React from 'react';
import { useNavigate } from 'react-router-dom';
import { Spinner } from 'reactstrap';
import { signInUser } from '../api/auth';

export default function Login( user = {} ) {
    const Navigate = useNavigate();

    const loginHandler = (e) => {
        e.preventDefault();
        signInUser()
            .then(() => Navigate("/pieces"))
            .catch(() => console.log("Failure"))
    }

    return (
        <div className="login-body">
            <h1 className="pictorial-logo">Pictorial</h1>
            {user === null ? (
                <div>
                    <Spinner
                        className="spinner"
                        color="success"
                    />
                </div>
            ) : (
                <div>
                    <button type="button" className="btn btn-success" onClick={loginHandler}>
                        Sign in using Google
                    </button>
                </div>
            )}
        </div>
    );
}