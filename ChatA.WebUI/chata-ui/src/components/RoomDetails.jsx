import SearchBar from "./SearchBar";
import PeopleInRoom from "./PeopleInRoom";

const RoomDetails = ({ selectedRoom }) => {
  return (
    <div className="room-details">
      <PeopleInRoom selectedRoom={selectedRoom} />
      <SearchBar />
    </div>
  );
};

export default RoomDetails;
