import SearchBar from "./SearchBar";
import PeopleInRoom from "./PeopleInRoom";

const RoomDetails = () => {
  return (
    <div className="room-details">
      <PeopleInRoom />
      RoomDetails Add user to group room
      <SearchBar />
    </div>
  );
};

export default RoomDetails;
