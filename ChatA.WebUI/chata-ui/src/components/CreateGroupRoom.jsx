import axiosInstance from "../utils/axios";

const CreateGroupRoom = () => {
  const createRoom = () => {
    await axiosInstance;
  };

  return (
    <div className="create-group-room">
      <form name="create-group-room-form" /*onSubmit={handleSubmit}*/>
        <input
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
