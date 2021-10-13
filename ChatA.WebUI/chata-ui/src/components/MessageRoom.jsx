import ListItemText from "@mui/material/ListItemText";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItem from "@mui/material/ListItem";
import MessageIcon from "@mui/icons-material/Message";
import ChatBubbleOutlineIcon from "@mui/icons-material/ChatBubbleOutline";
import SmsIcon from "@mui/icons-material/Sms";
import { useAuth0 } from "@auth0/auth0-react";

const MessageRoom = ({
  id,
  handleSelectedRoom,
  title,
  type,
  setSelectedTitle,
}) => {
  const { user } = useAuth0();
  const onClick = () => {
    handleSelectedRoom(id);
    setSelectedTitle(title);
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
  return (
    <ListItem onClick={() => onClick()} className="message-room">
      <ListItemIcon>{renderIcon()}</ListItemIcon>
      <ListItemText primary={checkTitle()} secondary={renderRoomType()} />
    </ListItem>
  );
};

export default MessageRoom;
