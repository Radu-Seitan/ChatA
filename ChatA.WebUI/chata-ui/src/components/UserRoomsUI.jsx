import SearchBar from "./SearchBar";
import MessageRoomList from "./MessageRoomList";
import CreateGroupRoom from "./CreateGroupRoom";
import LogoutButton from "./LogoutButton";

const UserRoomsUI = ({ props }) => {
  return (
    <div className="user-rooms">
      <SearchBar />
      <CreateGroupRoom />
      UserRoomUI
      <MessageRoomList props={props} />
      <LogoutButton />
    </div>
  );
};
export default UserRoomsUI;
