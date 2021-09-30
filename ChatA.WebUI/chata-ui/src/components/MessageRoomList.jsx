import { useAuth0 } from "@auth0/auth0-react";
import axiosInstance from "../utils/axios";
import MessageRoom from "./MessageRoom";
import { useState } from "react";

const MessageRoomList = ({ props }) => {
  const { user } = useAuth0();
  const [state, setstate] = useState();

  const getMessageRooms = async () => {
    const res = await axiosInstance.get(`api/messagerooms/${user.sub}`);
    setstate(res.data);
  };

  console.log(user.sub);
  if (!state) getMessageRooms();
  console.log(state);
  return (
    <div className="message-room-list">
      MessageRoomList
      <MessageRoom />
      <MessageRoom />
      <MessageRoom />
    </div>
  );
};

export default MessageRoomList;
