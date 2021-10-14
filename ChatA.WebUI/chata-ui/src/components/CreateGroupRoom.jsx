import axiosInstance from "../utils/axios";
import { useState } from "react";
import TextField from "@mui/material/TextField";
import styled from "styled-components";
import { Button } from "@mui/material";

const Hr = styled.hr`
  background-color: rgb(167, 158, 25);
  border: none;
  height: 1px;
  display: flex;
  orientation: row;
`;

const CreateGroupRoom = ({ rerender, setRerender }) => {
  const [name, setName] = useState("");
  const createRoom = async () => {
    const res = await axiosInstance.post(`api/messagerooms/group`, {
      name: name,
    });
    setRerender(!rerender);
  };

  return (
    <div className="create-group-room">
      <form
        name="create-group-room-form"
        onSubmit={(e) => {
          createRoom();
          e.preventDefault();
        }}
        style={{ display: "flex", gap: "10px", alignItems: "center" }}
      >
        <TextField
          id="group-name"
          label="Name the group"
          type="text"
          onChange={(e) => setName(e.target.value)}
        />
        <Button variant="contained" type="submit">
          Create group
        </Button>
      </form>
    </div>
  );
};
export default CreateGroupRoom;
