import ListItemText from "@mui/material/ListItemText";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItem from "@mui/material/ListItem";
import MessageIcon from "@mui/icons-material/Message";
import ChatBubbleOutlineIcon from "@mui/icons-material/ChatBubbleOutline";
import SmsIcon from "@mui/icons-material/Sms";

const MessageRoom = ({ id, handleSelectedRoom, title, type }) => {
  const onClick = () => handleSelectedRoom(id);
  const renderRoomType = () => {
    if (type === 1) return "Group chat";
    else return "Direct Message";
  };

  const renderIcon = () => {
    if (type === 1) return <MessageIcon />;
    else return <SmsIcon />;
  };
  return (
    <ListItem onClick={() => onClick()} className="message-room">
      <ListItemIcon>{renderIcon()}</ListItemIcon>
      <ListItemText primary={title} secondary={renderRoomType()} />
    </ListItem>
  );
};

export default MessageRoom;
