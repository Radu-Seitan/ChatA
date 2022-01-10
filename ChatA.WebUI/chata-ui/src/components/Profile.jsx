import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { useEffect } from "react";
import axiosInstance from "../utils/axios";
import UserRoomsUI from "./UserRoomsUI";
import ChatFeed from "./ChatFeed";
import RoomDetails from "./RoomDetails";
import { useState } from "react";
import { Box } from "@mui/system";
import { HubConnectionBuilder } from "@microsoft/signalr";
import { useRef } from "react";

const Profile = () => {
  const { isAuthenticated, getIdTokenClaims, user } = useAuth0();
  const [selectedRoom, setSelectedRoom] = useState();
  const [title, setSelectedTitle] = useState("");
  const [connection, setConnection] = useState(null);
  const [roomType, setRoomType] = useState();
  const [rerender, setRerender] = useState(true);
  const feedRef = useRef();

  const checkForUser = async () => {
    try {
      const res = await axiosInstance.get(`api/users/${user.sub}`);
    } catch {
      await axiosInstance.post(`api/users`, {
        id: user.sub,
        username: user.name,
        email: user.email,
      });
    }
  };

  useEffect(() => {
    checkForUser();
  });

  getIdTokenClaims().then((e) => {
    localStorage.setItem("token", e.__raw);
  });

  useEffect(() => {
    if (!localStorage.getItem("token")) return;
    const newConnection = new HubConnectionBuilder()
      .withUrl("https://chata.azurewebsites.net/chathub", {
        accessTokenFactory: () => localStorage.getItem("token"),
      })
      .withAutomaticReconnect()
      .build();

    setConnection(newConnection);
  }, []);

  useEffect(() => {
    if (connection) {
      connection
        .start()
        .then((result) => {
          console.log("Connected!");

          connection.on("ReceiveMessage", (message) => {
            feedRef.current.addMessage(JSON.parse(message));
          });
        })
        .catch((e) => console.log("Connection failed: ", e));
    }
  }, [connection]);

  return (
    isAuthenticated && (
      <Box className="profile">
        <UserRoomsUI
          handleSelectedRoom={setSelectedRoom}
          setSelectedTitle={setSelectedTitle}
          setRoomType={setRoomType}
          selectedRoom={selectedRoom}
          rerender={rerender}
          setRerender={setRerender}
        />
        <ChatFeed
          selectedRoom={selectedRoom}
          title={title}
          ref={feedRef}
          roomType={roomType}
        />
        <RoomDetails
          selectedRoom={selectedRoom}
          roomType={roomType}
          rerenderRooms={rerender}
          setRerenderRooms={setRerender}
        />
      </Box>
    )
  );
};

export default Profile;
