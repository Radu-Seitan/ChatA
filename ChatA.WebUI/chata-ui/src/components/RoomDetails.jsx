import SearchBar from "./SearchBar";
import PeopleInRoom from "./PeopleInRoom";
import { Box } from "@mui/system";

const RoomDetails = ({ selectedRoom, roomType }) => {
  const renderSearchBar = () => {
    if (roomType == 1) return <SearchBar />;
  };
  return (
    <Box className="room-details">
      <PeopleInRoom selectedRoom={selectedRoom} />
      {renderSearchBar()}
    </Box>
  );
};

export default RoomDetails;
