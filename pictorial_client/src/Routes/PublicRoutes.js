import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Home from '../Views/Home';
import Login from '../Views/Login';
import Artist from '../Views/Artist';
import ArtistForm from '../Views/ArtistForm';
import PieceForm from '../Views/PieceForm';
import Pieces from '../Views/Pieces';
import SingleArtistView from '../Views/SingleArtistView';
import SinglePieceView from '../Views/SinglePieceView';

export default function PublicRoutes() {
    return (
        <div>
            <Routes>
                <Route exact path="/" element={Home()} />
                <Route exact path="/login" element={Login()} />
                <Route exact path="/artist" element={Artist()} />
                <Route exact path="/artistform" element={ArtistForm()} />
                <Route exact path="/pieceform" element={PieceForm()} />
                <Route exact path="/pieces" element={Pieces()} />
                {/* these below will be edited to contain a FirebaseId or just regular id */}
                <Route exact path="/singleartist" element={SingleArtistView()} />
                <Route exact path="/singlepiece" element={SinglePieceView()} />
            </Routes>
        </div>
    );
}