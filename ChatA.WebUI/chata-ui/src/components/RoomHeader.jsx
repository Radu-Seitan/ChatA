import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import GroupsIcon from "@mui/icons-material/Groups";
import { IconButton } from "@mui/material";
import LogoutButton from "./LogoutButton";
import { useState } from "react";
import ProfileModal from "./ProfileModal";

const RoomHeader = ({ title }) => {
  const [open, setOpen] = useState(false);

  return (
    <AppBar position="static">
      <Toolbar>
        <IconButton
          size="large"
          edge="start"
          color="inherit"
          aria-label="menu"
          sx={{ mr: 2 }}
        >
          <GroupsIcon onClick={() => setOpen(true)} />
        </IconButton>
        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
          {title}
        </Typography>
        <LogoutButton />
      </Toolbar>
      <ProfileModal open={open} setOpen={setOpen} />
    </AppBar>
  );
};

export default RoomHeader;
