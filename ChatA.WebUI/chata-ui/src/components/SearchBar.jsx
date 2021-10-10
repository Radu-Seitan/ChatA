import { TextField } from "@mui/material";
import { Button } from "@mui/material";
import { useState } from "react";
import axiosInstance from "../utils/axios";

const SearchBar = () => {
  const [name, setName] = useState("");
  const [state, setstate] = useState();
  const getUsers = async () => {
    const res = await axiosInstance.get(`api/users?searchedUsername=${name}`);
    setstate(res.data);
  };

  if (state) console.log(state);
  return (
    <div className="search-user">
      <form name="search-users-form" onSubmit={getUsers}>
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
  );
};

export default SearchBar;
