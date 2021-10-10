import SearchBar from "./SearchBar";
import MessageRoomList from "./MessageRoomList";
import UserUIHeader from "./UserUIHeader";
import LogoutButton from "./LogoutButton";

const UserRoomsUI = ({ handleSelectedRoom }) => {
  return (
    <div className="user-rooms">
      <UserUIHeader />
      <MessageRoomList handleSelectedRoom={handleSelectedRoom} />
      <LogoutButton />
    </div>
  );
};
export default UserRoomsUI;
