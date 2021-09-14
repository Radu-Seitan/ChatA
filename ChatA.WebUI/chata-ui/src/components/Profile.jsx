import React from 'react'
import { useAuth0 } from '@auth0/auth0-react'
import { useState } from 'react';


const Profile = () => {
    const {user, isAuthenticated, getIdTokenClaims} = useAuth0();
    const [token, setToken] = useState("");
    getIdTokenClaims().then(e => setToken(e.__raw));
    console.log(token);
    return (
        isAuthenticated && (
            <div>
                <img src ={user.picture} alt={user.name} />
                <h2>{user.name}</h2>
                <p>{user.email}</p>
            </div>
        )
    )
}

export default Profile
