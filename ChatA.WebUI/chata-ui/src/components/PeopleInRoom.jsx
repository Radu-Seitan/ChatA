import { Box } from "@mui/system";
import { useState } from "react";
import axiosInstance from "../utils/axios";
import { useEffect } from "react";

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
  console.log(users);
  useEffect(() => {
    if (!users.length > 0) getUsersInRoom();
  }, [users]);

  return <Box className="people-in-room">People In Room</Box>;
};

export default PeopleInRoom;
