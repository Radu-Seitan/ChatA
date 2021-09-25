import React from 'react'
import { useAuth0 } from '@auth0/auth0-react'
import { useState, useEffect } from 'react';
import axios from 'axios';


const Profile = () => {
    const {user, isAuthenticated, getIdTokenClaims} = useAuth0();
    const [token, setToken] = useState("");
    getIdTokenClaims().then(e => setToken(e.__raw));

    useEffect(() => {
        if (!token) return;
        axios.interceptors.request.use(
            request => {
                if(request) {
                    request.headers['Authorization'] = 'Bearer ' + token;
                }
                return request;
            },
            error =>{
                return Promise.reject(error);
            }
        );
        axios.get("api/users").then(e => console.log(e.data));
    }, [token])
   
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
