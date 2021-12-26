import ListItemText from "@mui/material/ListItemText";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItem from "@mui/material/ListItem";
import MessageIcon from "@mui/icons-material/Message";
import ChatBubbleOutlineIcon from "@mui/icons-material/ChatBubbleOutline";
import SmsIcon from "@mui/icons-material/Sms";
import DeleteOutlineIcon from '@mui/icons-material/DeleteOutline';
import { useAuth0 } from "@auth0/auth0-react";
import axiosInstance from "../utils/axios";
import { Box } from "@mui/material";

const MessageRoom = ({
  id,
  handleSelectedRoom,
  title,
  type,
  setSelectedTitle,
  setRoomType,
  selectedRoom,
  setRerender,
  rerender
}) => {
  const { user } = useAuth0();
  const onClick = () => {
    handleSelectedRoom(id);
    setSelectedTitle(title);
    setRoomType(type);
  };
  const renderRoomType = () => {
    if (type === 1) return "Group chat";
    else return "Direct Message";
  };

  const renderIcon = () => {
    if (type === 1) return <MessageIcon />;
    else return <SmsIcon />;
  };

  const checkTitle = () => {
    if (type === 1) return title;
    else {
      const value = title;
      const array = value.split("&").map((name) => name.trim());
      if (array[0] === user.name) return array[1];
      else return array[0];
    }
  };

  const deleteMessageRoom = async () => {
    const res = await axiosInstance.delete(`api/MessageRooms/${id}`);
    setRerender(!rerender);
  }

   const renderBin = () => {
    if(type === 1) return <DeleteOutlineIcon fontSize='medium'onClick={() => deleteMessageRoom()}/>
    else return <></>
  }

  return (
      <ListItem
        className="message-room"
        sx={{
          cursor: "pointer",
        }}
      >
        <ListItem onClick={() => onClick()}>
          <ListItemIcon>{renderIcon()}</ListItemIcon>
          <ListItemText primary={checkTitle()} secondary={renderRoomType()} />
        </ListItem>
        {renderBin()}
      </ListItem>
  );
};

export default MessageRoom;
