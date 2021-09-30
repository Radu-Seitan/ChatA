import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { useEffect } from "react";
import axios from "axios";
import axiosInstance from "../utils/axios";
import UserRoomsUI from "./UserRoomsUI";
import ChatFeed from "./ChatFeed";
import RoomDetails from "./RoomDetails";

const Profile = () => {
  const { user, isAuthenticated, getIdTokenClaims } = useAuth0();
  getIdTokenClaims().then((e) => {
    localStorage.setItem("token", e.__raw);
  });

  useEffect(() => {
    if (!isAuthenticated) return;
    axiosInstance.get("api/users").then((e) => console.log(e.data));
  }, [isAuthenticated]);

  return (
    isAuthenticated && (
      <>
        <div className="profile">
          <UserRoomsUI props={user} />
          <ChatFeed />
          <RoomDetails />
        </div>
      </>
    )
  );
};

export default Profile;
