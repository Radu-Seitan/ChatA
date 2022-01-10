import MessageForm from "./MessageForm";
import MyMessage from "./MyMessage";
import TheirMessage from "./TheirMessage";
import RoomHeader from "./RoomHeader";
import { Box } from "@mui/system";
import { forwardRef, useCallback, useState } from "react";
import axiosInstance from "../utils/axios";
import { useEffect, useRef } from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { List } from "@mui/material";
import { useImperativeHandle } from "react";

const ChatFeed = forwardRef(({ selectedRoom, title, roomType }, ref) => {
  const { user } = useAuth0();
  const [messages, setMessages] = useState([]);

  const containerRef = useRef(null);

  const getMessages = async () => {
    const res = await axiosInstance.get(`api/messages/${selectedRoom}`);
    setMessages(res.data);
  };

  useEffect(() => {
    if (selectedRoom) {
      getMessages();
    }
  }, [selectedRoom]);

  useEffect(() => {
    containerRef.current.scrollIntoView();
  });

  const renderMessages = useCallback(() => {
    return messages.map((value, index) => {
      if (value.senderId === user.sub)
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

  useImperativeHandle(ref, () => ({
    addMessage(message) {
      if (selectedRoom === message.roomId) {
        setMessages((messages) => [...messages, message]);
      }
    },
  }));

  return (
    <Box
      className="chat-feed"
      sx={{
        borderLeft: "0.0625rem solid black",
        borderRight: "0.0625rem solid black",
        backgroundColor: "rgba(25, 118, 210, 0.1)",
      }}
    >
      <RoomHeader title={title} roomType={roomType} />
      <List
        sx={{
          maxHeight: "calc(100%-5.5rem)",
          overflow: "auto",
          display: "flex",
          flexDirection: "column",
          gap: "5px",
          padding: "5px",
        }}
      >
        {messages.length > 0 && renderMessages()}
        <Box ref={containerRef}></Box>
      </List>
      <MessageForm selectedRoom={selectedRoom} getMessages={getMessages} />
    </Box>
  );
});

export default ChatFeed;
