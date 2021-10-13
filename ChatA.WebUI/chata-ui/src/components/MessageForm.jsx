import { Box } from "@mui/system";
import TextField from "@mui/material/TextField";
import axiosInstance from "../utils/axios";
import { useState } from "react";
import SendIcon from "@mui/icons-material/Send";
import { InputAdornment } from "@mui/material";
import { makeStyles } from "@mui/styles";

const useStyles = makeStyles(() => ({
  container: {
    cursor: "pointer",
  },
}));

const MessageForm = ({ selectedRoom, getMessages }) => {
  const [name, setName] = useState("");
  const styles = useStyles();

  const sendMessage = async () => {
    if (selectedRoom) {
      await axiosInstance.post(`api/messages`, {
        text: `${name}`,
        roomId: `${selectedRoom}`,
      });
      getMessages();
    }
  };
  return (
    <Box
      sx={{
        backgroundColor: "white",
        width: "100%",
        marginTop: "auto",
      }}
    >
      <TextField
        label="Send your message"
        id="message-input"
        type="text"
        fullWidth
        onChange={(e) => setName(e.target.value)}
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
