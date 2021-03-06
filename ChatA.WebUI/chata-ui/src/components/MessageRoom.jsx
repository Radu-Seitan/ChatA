import ListItemText from "@mui/material/ListItemText";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItem from "@mui/material/ListItem";
import MessageIcon from "@mui/icons-material/Message";
import ChatBubbleOutlineIcon from "@mui/icons-material/ChatBubbleOutline";
import SmsIcon from "@mui/icons-material/Sms";
import ExitToAppIcon from "@mui/icons-material/ExitToApp";
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
  rerender,
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

  const leaveMessageRoom = async () => {
    await axiosInstance.put(`api/MessageRooms/leave/${id}`);
    setRerender(!rerender);
  };

  const renderLeave = () => {
    if (type === 1)
      return (
        <ExitToAppIcon
          fontSize="medium"
          sx={{ marginTop: "27.5px", marginRight: "20px" }}
          onClick={() => leaveMessageRoom()}
        />
      );
    else return <></>;
  };

  return (
    <Box
      className="message-room"
      sx={{
        cursor: "pointer",
        display: "flex",
        flexDirection: "row",
      }}
    >
      <ListItem onClick={() => onClick()}>
        <ListItemIcon>{renderIcon()}</ListItemIcon>
        <ListItemText primary={checkTitle()} secondary={renderRoomType()} />
      </ListItem>
      {renderLeave()}
    </Box>
  );
};

export default MessageRoom;
