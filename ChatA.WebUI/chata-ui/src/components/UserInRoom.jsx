import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import ListItemAvatar from "@mui/material/ListItemAvatar";
import Avatar from "@mui/material/Avatar";
import AccountCircleIcon from "@mui/icons-material/AccountCircle";
import { ListItemIcon } from "@mui/material";
import RemoveCircleIcon from '@mui/icons-material/RemoveCircle';
import { IconButton } from "@mui/material";
import axiosInstance from "../utils/axios";


const UserInRoom = ({ user, roomType, rerender, setRerender, selectedRoom }) => {

  const removeUserFromGroup = async () => {
    await axiosInstance.put(`api/messagerooms/remove`, {
      roomId: selectedRoom,
      userId: user.id,
    });
    setRerender(!rerender);
  }

  const renderRemoveIcon = () => {
    if(roomType === 1) return(
      <IconButton size="large"
            edge="end"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 0.1 }}>
        <ListItemIcon>
          <RemoveCircleIcon sx={{marginLeft:"16px"}} onClick={() => removeUserFromGroup()}/>
        </ListItemIcon>
      </IconButton>
      )
  }

  return (
    <ListItem sx={{ cursor: "pointer" }}>
      <ListItemAvatar>
        <Avatar>
          <AccountCircleIcon />
        </Avatar>
      </ListItemAvatar>
      <ListItemText primary={user.username} />
      {renderRemoveIcon()}
    </ListItem>
  );
};

export default UserInRoom;
