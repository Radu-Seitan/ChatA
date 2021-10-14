import { Box } from "@mui/system";
import { useState } from "react";
import axiosInstance from "../utils/axios";
import { useEffect } from "react";
import UserInRoom from "./UserInRoom";
import { List } from "@mui/material";
import { useCallback } from "react";

const PeopleInRoom = ({ selectedRoom }) => {
  const [users, setUsers] = useState([]);

  const getUsersInRoom = async () => {
    if (selectedRoom) {
      const res = await axiosInstance.get(
        `api/users/messagerooms/${selectedRoom}`
      );
      setUsers(res.data);
    }
  };

  useEffect(() => {
    getUsersInRoom();
  }, [selectedRoom]);

  const renderUsersInRoom = () => {
    return users.map((value, index) => {
      return (
        <UserInRoom key={`user-in-room - ${value} - ${index}`} user={value} />
      );
    });
  };

  console.log(users);

  return <List className="people-in-room">{renderUsersInRoom()}</List>;
};

export default PeopleInRoom;
