import { TextField } from "@mui/material";
import { Button } from "@mui/material";
import { useState } from "react";
import axiosInstance from "../utils/axios";
import UsersModal from "./UsersModal";
import { useEffect } from "react";
import { Box } from "@mui/system";
import { Toolbar } from "@mui/material";
import { AppBar } from "@material-ui/core";
import { Typography } from "@mui/material";

const AddUserSearchBar = ({ rerender, setRerender, selectedRoom }) => {
  const [name, setName] = useState("");
  const [users, setUsers] = useState();
  const [user, selectUser] = useState();
  const [open, setOpen] = useState(false);

  const getUsers = async () => {
    const res = await axiosInstance.get(`api/users?searchedUsername=${name}`);
    setUsers(res.data);
  };

  const addUserToGroup = async () => {
    await axiosInstance.put(`api/messagerooms`, {
      roomId: selectedRoom,
      userId: user.id,
    });
    setRerender(!rerender);
  };

  const renderModal = () => {
    if (users)
      return (
        <UsersModal
          open={open}
          setOpen={setOpen}
          users={users}
          selectUser={selectUser}
          setRerender={setRerender}
          rerender={rerender}
        />
      );
  };

  useEffect(() => {
    if (user) addUserToGroup();
  }, [user]);

  return (
    <Box>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Add users in room
          </Typography>
        </Toolbar>
      </AppBar>
      <Box
        className="search-user"
        sx={{ paddingTop: "0.625rem", paddingBottom: "0.625rem" }}
      >
        <form
          name="search-users-form"
          onSubmit={(e) => {
            getUsers();
            setOpen(true);
            e.preventDefault();
          }}
          style={{ display: "flex", gap: "10px", alignItems: "center" }}
        >
          <TextField
            id="header-search"
            label="Search user"
            type="text"
            onChange={(e) => setName(e.target.value)}
          />
          <Button variant="contained" type="submit">
            Search user
          </Button>
        </form>
      </Box>
      {renderModal()}
    </Box>
  );
};

export default AddUserSearchBar;
