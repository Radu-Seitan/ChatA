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

  useEffect(() => {
    getUsersInRoom();
  }, [selectedRoom]);

  console.log(users);

  return <Box className="people-in-room"></Box>;
};

export default PeopleInRoom;
