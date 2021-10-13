import SearchBar from "./SearchBar";
import MessageRoomList from "./MessageRoomList";
import UserUIHeader from "./UserUIHeader";
import { Box } from "@mui/system";
import { useState } from "react";

const UserRoomsUI = ({ handleSelectedRoom, setSelectedTitle }) => {
  const [rerender, setRerender] = useState(true);
  return (
    <Box className="user-rooms">
      <UserUIHeader rerender={rerender} setRerender={setRerender} />
      <MessageRoomList
        handleSelectedRoom={handleSelectedRoom}
        rerender={rerender}
        setRerender={setRerender}
        setSelectedTitle={setSelectedTitle}
      />
    </Box>
  );
};
export default UserRoomsUI;
