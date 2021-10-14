import { ListItem } from "@mui/material";
import Typography from "@mui/material/Typography";
import { ListItemText } from "@mui/material";
import { Tooltip } from "@mui/material";

const MyMessage = ({ message }) => {
  const text = message.text;
  const created = message.created.split("T");
  const time = created[1].substr(0, 5);
  const date = created[0].split("-").reverse().join("-");
  const sender = `Sent by ${message.sentBy} at ${time} on ${date}`;
  return (
    <Tooltip title={sender} placement="left">
      <ListItem
        className="my-message"
        sx={{
          width: "fit-content",
          justifyContent: "flex-end",
          borderRadius: "1rem",
          alignSelf: "flex-end",
          backgroundColor: "#1976d2",
          color: "#fff",
          fontSize: "1.5625rem",
          "& > div > p": {
            color: "white",
            fontSize: "12px",
          },
        }}
      >
        <ListItemText primary={text} />
      </ListItem>
    </Tooltip>
  );
};
export default MyMessage;
