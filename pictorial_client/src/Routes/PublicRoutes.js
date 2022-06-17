import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Home from '../Views/Home';
import Login from '../Views/Login';
import PieceForm from '../Components/PieceForm';
import Pieces from '../Views/Pieces';
// import Profile from '../Views/Profile';
import SinglePieceView from '../Views/SinglePieceView';

export default function PublicRoutes({ obj, user }) {
    return (
        <div>
            <Routes>
                <Route exact path="/" element={Home()} />
                <Route exact path="/login" element={Login(user = {} )} />
                {/* <Route exact path="/artistform" element={ArtistForm()} /> */}
                <Route exact path="/pieceform" element={PieceForm()} />
                <Route exact path="/edit-piece/:id" element={PieceForm(obj = {})} />
                <Route exact path="/pieces" element={Pieces()} />
                {/* these below will be edited to contain a FirebaseId or just regular id */}
                {/* <Route exact path="/profile" element={Profile(user = {})} /> */}
                <Route exact path="/singlepiece/:id" element={SinglePieceView()} />
            </Routes>
        </div>
    );
}