import { useAuth0 } from "@auth0/auth0-react";
import axiosInstance from "../utils/axios";
import MessageRoom from "./MessageRoom";
import { useCallback, useEffect, useState } from "react";
import List from "@mui/material/List";
import { makeStyles } from "@mui/styles";

const useStyles = makeStyles(() => ({
  container: {
    paddingTop: "0rem",
    borderLeft: "0.0625rem",
  },
}));

const MessageRoomList = ({
  handleSelectedRoom,
  rerender,
  setRerender,
  setSelectedTitle,
  setRoomType,
  selectedRoom,
}) => {
  const { user } = useAuth0();
  const [messageRooms, setMessageRooms] = useState([]);
  const styles = useStyles();

  const getMessageRooms = useCallback(async () => {
    const res = await axiosInstance.get(`api/messagerooms/${user.sub}`);
    setMessageRooms(res.data);
  }, [user]);

  console.log(messageRooms);

  const renderMessageRooms = useCallback(() => {
    return messageRooms.map((value, index) => {
      console.log(value.id, selectedRoom);
      return (
        <MessageRoom
          key={`message-room - ${value} - ${index}`}
          id={value.id}
          handleSelectedRoom={handleSelectedRoom}
          title={value.name}
          type={value.type}
          setSelectedTitle={setSelectedTitle}
          setRoomType={setRoomType}
          selectedRoom={selectedRoom}
        />
      );
    });
  }, [messageRooms]);

  useEffect(() => {
    getMessageRooms();
  }, [rerender]);

  useEffect(() => {
    if (!messageRooms.length) getMessageRooms();
  }, [messageRooms]);

  return (
    <List className={styles.container}>
      {messageRooms.length > 0 && renderMessageRooms()}
    </List>
  );
};

export default MessageRoomList;
