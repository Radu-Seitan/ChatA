import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import GroupsIcon from "@mui/icons-material/Groups";
import { IconButton } from "@mui/material";
import LogoutButton from "./LogoutButton";
import { useState } from "react";
import ProfileModal from "./ProfileModal";
import { useAuth0 } from "@auth0/auth0-react";

const RoomHeader = ({ title, roomType }) => {
  const [open, setOpen] = useState(false);
  const { user } = useAuth0();

  const checkTitle = () => {
    if (roomType === 1) return title;
    else {
      const value = title;
      const array = value.split("&").map((name) => name.trim());
      if (array[0] === user.name) return array[1];
      else return array[0];
    }
  };

  return (
    <AppBar position="static">
      <Toolbar>
        <IconButton
          size="large"
          edge="start"
          color="inherit"
          aria-label="menu"
          sx={{ mr: 2 }}
          onClick={() => setOpen(true)}
        >
          <GroupsIcon />
        </IconButton>
        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
          {checkTitle()}
        </Typography>
        <LogoutButton />
      </Toolbar>
      <ProfileModal open={open} setOpen={setOpen} />
    </AppBar>
  );
};

export default RoomHeader;
