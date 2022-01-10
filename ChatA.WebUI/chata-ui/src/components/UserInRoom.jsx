import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import { ListItemIcon, ImageListItem } from "@mui/material";
import RemoveCircleIcon from "@mui/icons-material/RemoveCircle";
import { IconButton } from "@mui/material";
import axiosInstance from "../utils/axios";

const UserInRoom = ({
  user,
  roomType,
  rerender,
  setRerender,
  selectedRoom,
  setOpen,
  setSelectedUser,
}) => {
  const removeUserFromGroup = async () => {
    await axiosInstance.put(`api/messagerooms/remove`, {
      roomId: selectedRoom,
      userId: user.id,
    });
    setRerender(!rerender);
  };

  const renderRemoveIcon = () => {
    if (roomType === 1)
      return (
        <IconButton
          size="large"
          edge="end"
          color="inherit"
          aria-label="menu"
          sx={{ mr: 0.1 }}
        >
          <ListItemIcon>
            <RemoveCircleIcon
              sx={{ marginLeft: "16px" }}
              onClick={() => removeUserFromGroup()}
            />
          </ListItemIcon>
        </IconButton>
      );
  };

  return (
    <ListItem
      sx={{ cursor: "pointer" }}
      onClick={() => {
        setSelectedUser(user);
        setOpen(true);
      }}
    >
      <ImageListItem
        sx={{
          width: "60px",
          height: "60px",
          marginRight: "10px",
        }}
      >
        <img
          src={
            user.imageId
              ? `api/images/${user.imageId}`
              : `https://res.cloudinary.com/dxd6gnoof/image/upload/v1641837673/no-user-profile-picture-hand-drawn-illustration-53840792_bxrzb8.jpg`
          }
          alt="user-profile-pic"
          style={{ borderRadius: "10px" }}
        />
      </ImageListItem>
      <ListItemText primary={user.username} />
      {renderRemoveIcon()}
    </ListItem>
  );
};

export default UserInRoom;
