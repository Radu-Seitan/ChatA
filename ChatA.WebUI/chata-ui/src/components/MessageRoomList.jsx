import { useAuth0 } from "@auth0/auth0-react";
import axiosInstance from "../utils/axios";
import MessageRoom from "./MessageRoom";
import { useCallback, useState } from "react";

const MessageRoomList = ({ handleSelectedRoom }) => {
  const { user } = useAuth0();
  const [messageRooms, setMessageRooms] = useState([]);

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

  if (!messageRooms.length) getMessageRooms();
  console.log(messageRooms);

  return (
    <div className="message-room-list">
      {messageRooms.length > 0 && renderMessageRooms()}
    </div>
  );
};

export default MessageRoomList;
