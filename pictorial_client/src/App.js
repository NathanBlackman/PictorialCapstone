import React, { useEffect, useState } from 'react';
import Navigation from './Components/Navigation';
import PublicRoutes from './Routes/PublicRoutes';
import firebase from 'firebase/compat/app';
import 'firebase/auth';
import 'firebase/firestore';
import Login from './Views/Login';

const firebaseConfig = {
    apiKey: process.env.REACT_APP_API_KEY,
};
firebase.initializeApp(firebaseConfig);

function App() {
    const [user, setUser] = useState(null);

    useEffect(() => {
        firebase.auth().onAuthStateChanged((authed) => {
            if (authed) {
                const userObj = {
                    uid: authed.uid,
                    name: authed.displayName,
                    image: authed.photoURL,
                    user: authed.email.split('@')[0],
                };
                setUser(userObj);
            } else if (user || user === null) {
                setUser(false);
            }
        });
    })

    return (
        <div className="App">
            {user ? (
                <>
                    <Navigation user={user} />
                    <PublicRoutes user={user} />
                </>
            ) : (
                <Login user={user} />
            )}
            
        </div>
    );
}

export default App;
