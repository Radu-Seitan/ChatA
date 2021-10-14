import { Box } from "@mui/system";
import { useState } from "react";
import axiosInstance from "../utils/axios";
import { useEffect } from "react";
import UserInRoom from "./UserInRoom";
import { List } from "@mui/material";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import { Typography } from "@mui/material";

const PeopleInRoom = ({ selectedRoom, rerender }) => {
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
  }, [selectedRoom, rerender]);

  const renderUsersInRoom = () => {
    return users.map((value, index) => {
      return (
        <UserInRoom key={`user-in-room - ${value} - ${index}`} user={value} />
      );
    });
  };

  console.log(users);

  return (
    <Box>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Users in group chat
          </Typography>
        </Toolbar>
      </AppBar>
      <List className="people-in-room">{renderUsersInRoom()}</List>
    </Box>
  );
};

export default PeopleInRoom;
