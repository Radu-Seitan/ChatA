import PeopleInRoom from "./PeopleInRoom";
import { Box } from "@mui/system";
import AddUserSearchBar from "./AddUserSearchBar";
import { useState } from "react";

const RoomDetails = ({ selectedRoom, roomType,rerenderRooms,setRerenderRooms }) => {
  const [rerender, setRerender] = useState(false);

  const renderSearchBar = () => {
    if (roomType === 1)
      return (
        <AddUserSearchBar
          selectedRoom={selectedRoom}
          setRerender={setRerender}
          rerender={rerender}
          rerenderRooms={rerenderRooms}
          setRerenderRooms={setRerenderRooms}
        />
      );
  };
  return (
    <Box className="room-details">
      {renderSearchBar()}
      <PeopleInRoom 
        selectedRoom={selectedRoom} 
        rerender={rerender} 
        roomType={roomType}
        setRerender={setRerender}
      />
    </Box>
  );
};

export default RoomDetails;
