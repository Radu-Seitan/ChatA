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

  getIdTokenClaims().then((e) => {
    localStorage.setItem("token", e.__raw);
  });

  console.log(selectedRoom);
  return (
    isAuthenticated && (
      <>
        <div className="profile">
          <UserRoomsUI handleSelectedRoom={setSelectedRoom} />
          <ChatFeed selectedRoom={selectedRoom} />
          <RoomDetails selectedRoom={selectedRoom} />
        </div>
      </>
    )
  );
};

export default Profile;
