import { TextField } from "@mui/material";
import { Button } from "@mui/material";
import { useState } from "react";
import axiosInstance from "../utils/axios";
import UsersModal from "./UsersModal";
import { useEffect } from "react";
import { render } from "react-dom";

const SearchBar = ({ setRerender, rerender }) => {
  const [name, setName] = useState("");
  const [users, setUsers] = useState();
  const [user, selectUser] = useState();
  const [open, setOpen] = useState(false);

  const getUsers = async () => {
    const res = await axiosInstance.get(`api/users?searchedUsername=${name}`);
    setUsers(res.data);
  };

  const createDirectMessage = async () => {
    const res = await axiosInstance.post(`api/messagerooms/individual`, {
      secondUserId: user.id,
    });
    setRerender(!render);
  };

  const renderModal = () => {
    if (users)
      return (
        <UsersModal
          open={open}
          setOpen={setOpen}
          users={users}
          selectUser={selectUser}
          setRerender={setRerender}
          rerender={rerender}
        />
      );
  };

  useEffect(() => {
    if (user) createDirectMessage();
  }, [user]);
  return (
    <>
      <div className="search-user">
        <form
          name="search-users-form"
          onSubmit={(e) => {
            getUsers();
            setOpen(true);
            e.preventDefault();
          }}
        >
          <TextField
            id="header-search"
            label="Search user"
            type="text"
            onChange={(e) => setName(e.target.value)}
          />
          <Button variant="contained" type="submit">
            Search user
          </Button>
        </form>
      </div>
      {renderModal()}
    </>
  );
};

export default SearchBar;
