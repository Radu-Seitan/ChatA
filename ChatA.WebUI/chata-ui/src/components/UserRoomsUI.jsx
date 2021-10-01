import SearchBar from "./SearchBar";
import MessageRoomList from "./MessageRoomList";
import CreateGroupRoom from "./CreateGroupRoom";
import LogoutButton from "./LogoutButton";

const UserRoomsUI = ({ handleSelectedRoom }) => {
  return (
    <div className="user-rooms">
      <div className="user-ui-header">
        <SearchBar />
        <CreateGroupRoom />
      </div>
      <MessageRoomList handleSelectedRoom={handleSelectedRoom} />
      <LogoutButton />
    </div>
  );
};
export default UserRoomsUI;
