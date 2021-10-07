import axiosInstance from "../utils/axios";
import { useState } from "react";

const CreateGroupRoom = () => {
  const [name, setName] = useState("");

  const createRoom = async () => {
    const res = await axiosInstance.post(`api/messagerooms/group`, {
      name: name,
    });
  };

  return (
    <div className="create-group-room">
      <form name="create-group-room-form" onSubmit={createRoom}>
        <input
          onChange={(e) => setName(e.target.value)}
          type="text"
          id="group-name"
          placeholder="Name the group"
          name="name-group-room"
        />
        <input type="submit" value="Create group" />
      </form>
    </div>
  );
};
export default CreateGroupRoom;
