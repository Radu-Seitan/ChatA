import { Box } from "@mui/system";
import { useState } from "react";
import axiosInstance from "../utils/axios";
import { useEffect } from "react";
import UserInRoom from "./UserInRoom";
import { List } from "@mui/material";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import { Typography } from "@mui/material";
import UserInGroupRoomModal from "./UserInGroupRoomModal";

const PeopleInRoom = ({ selectedRoom, rerender, roomType, setRerender }) => {
  const [users, setUsers] = useState([]);
  const [open, setOpen] = useState(false);
  const [selectedUser, setSelectedUser] = useState();

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

  const renderModal = () => {
    if (selectedUser)
      return (
        <UserInGroupRoomModal
          user={selectedUser}
          open={open}
          setOpen={setOpen}
        />
      );
  };

  const renderUsersInRoom = () => {
    return users.map((value, index) => {
      return (
        <UserInRoom
          key={`user-in-room - ${value} - ${index}`}
          user={value}
          roomType={roomType}
          rerender={rerender}
          setRerender={setRerender}
          selectedRoom={selectedRoom}
          setOpen={setOpen}
          setSelectedUser={setSelectedUser}
        />
      );
    });
  };

  return (
    <>
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
      {renderModal()}
    </>
  );
};

export default PeopleInRoom;
