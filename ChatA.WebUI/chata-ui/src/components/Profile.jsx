import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { useEffect } from "react";
import axiosInstance from "../utils/axios";
import UserRoomsUI from "./UserRoomsUI";
import ChatFeed from "./ChatFeed";
import RoomDetails from "./RoomDetails";
import { useState } from "react";

const Profile = () => {
  const { user, isAuthenticated, getIdTokenClaims } = useAuth0();
  const [selectedRoom, setSelectedRoom] = useState();
  const [title, setSelectedTitle] = useState("");

  getIdTokenClaims().then((e) => {
    localStorage.setItem("token", e.__raw);
  });

  return (
    isAuthenticated && (
      <>
        <div className="profile">
          <UserRoomsUI
            handleSelectedRoom={setSelectedRoom}
            setSelectedTitle={setSelectedTitle}
          />
          <ChatFeed selectedRoom={selectedRoom} title={title} />
          <RoomDetails selectedRoom={selectedRoom} />
        </div>
      </>
    )
  );
};

export default Profile;
