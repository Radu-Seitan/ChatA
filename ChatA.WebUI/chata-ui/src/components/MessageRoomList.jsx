import { useAuth0 } from "@auth0/auth0-react";
import axiosInstance from "../utils/axios";
import MessageRoom from "./MessageRoom";
import { useCallback, useEffect, useState } from "react";
import List from "@mui/material/List";
import { makeStyles } from "@mui/styles";

const useStyles = makeStyles(() => ({
  container: {
    backgroundColor: "#edeba0",
    paddingTop: "0px",
  },
}));

const MessageRoomList = ({ handleSelectedRoom }) => {
  const { user } = useAuth0();
  const [messageRooms, setMessageRooms] = useState([]);
  const styles = useStyles();

  const getMessageRooms = useCallback(async () => {
    const res = await axiosInstance.get(`api/messagerooms/${user.sub}`);
    setMessageRooms(res.data);
  }, [user]);

  const renderMessageRooms = useCallback(() => {
    return messageRooms.map((value, index) => {
      return (
        <MessageRoom
          key={`message-room - ${value} - ${index}`}
          id={value.id}
          handleSelectedRoom={handleSelectedRoom}
          title={value.name}
          type={value.type}
        />
      );
    });
  }, [messageRooms, handleSelectedRoom]);

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
