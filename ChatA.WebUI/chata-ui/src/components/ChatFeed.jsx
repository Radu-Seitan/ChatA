import MessageForm from "./MessageForm";
import MyMessage from "./MyMessage";
import TheirMessage from "./TheirMessage";
import RoomHeader from "./RoomHeader";
import { Box } from "@mui/system";
import { useCallback, useState } from "react";
import axiosInstance from "../utils/axios";
import { useEffect } from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { List } from "@mui/material";

const ChatFeed = ({ selectedRoom, title }) => {
  const { user } = useAuth0();
  const [messages, setMessages] = useState([]);

  const getMessages = async () => {
    const res = await axiosInstance.get(`api/messages/${selectedRoom}`);
    setMessages(res.data);
  };

  useEffect(() => {
    if (selectedRoom) {
      getMessages();
    }
  }, [selectedRoom]);

  const renderMessages = useCallback(() => {
    return messages.map((value, index) => {
      if (value.sentBy === user.name)
        return (
          <MyMessage
            key={`message - ${value} - ${index}`}
            message={value}
            className="message"
          />
        );
      return (
        <TheirMessage
          key={`message - ${value} - ${index}`}
          message={value}
          className="message"
        />
      );
    });
  }, [messages]);

  return (
    <Box
      className="chat-feed"
      sx={{
        borderLeft: "0.0625rem solid black",
        borderRight: "0.0625rem solid black",
      }}
    >
      <RoomHeader title={title} />
      <List
        sx={{
          maxHeight: "calc(100%-5.5rem)",
          overflow: "auto",
        }}
      >
        {messages.length > 0 && renderMessages()}
      </List>
      <MessageForm selectedRoom={selectedRoom} getMessages={getMessages} />
    </Box>
  );
};

export default ChatFeed;
