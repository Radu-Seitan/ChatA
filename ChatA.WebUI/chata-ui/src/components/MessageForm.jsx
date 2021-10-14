import { Box } from "@mui/system";
import TextField from "@mui/material/TextField";
import axiosInstance from "../utils/axios";
import { useState } from "react";
import SendIcon from "@mui/icons-material/Send";
import { InputAdornment } from "@mui/material";
import { makeStyles } from "@mui/styles";
import { useRef } from "react";
import { useEffect } from "react";

const useStyles = makeStyles(() => ({
  container: {
    cursor: "pointer",
  },
}));

const MessageForm = ({ selectedRoom, getMessages }) => {
  const [name, setName] = useState("");
  const [room, setRoom] = useState(selectedRoom);
  const styles = useStyles();
  const inputElement = useRef(null);

  const sendMessage = async () => {
    if (selectedRoom) {
      await axiosInstance.post(`api/messages`, {
        text: `${name}`,
        roomId: `${selectedRoom}`,
      });
      inputElement.current.children[1].children[0].value = null;
    }
  };

  return (
    <Box
      sx={{
        backgroundColor: "white",
        width: "100%",
        marginTop: "auto",
        position: "static",
      }}
    >
      <TextField
        ref={inputElement}
        label="Send your message"
        id="message-input"
        type="text"
        fullWidth
        onChange={(e) => setName(e.target.value)}
        onKeyPress={(event) => {
          if (event.key == "Enter") sendMessage();
        }}
        InputProps={{
          endAdornment: (
            <InputAdornment position="end">
              <SendIcon
                fontSize="large"
                className={styles.container}
                onClick={() => {
                  sendMessage();
                }}
              />
            </InputAdornment>
          ),
          sx: {
            "& fieldset > legend > span": {
              height: "100%",
            },
          },
        }}
      />
    </Box>
  );
};
export default MessageForm;
