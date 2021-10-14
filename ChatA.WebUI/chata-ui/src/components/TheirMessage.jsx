import { ListItem } from "@mui/material";
import Typography from "@mui/material/Typography";
import { ListItemText } from "@mui/material";

const TheirMessage = ({ message }) => {
  const text = message.text;
  const created = message.created.split("T");
  const time = created[1].substr(0, 5);
  const date = created[0].split("-").reverse().join("-");

  const sender = `Sent by ${message.sentBy} at ${time} on ${date}`;
  return (
    <ListItem
      className="my-message"
      sx={{
        border: "1px solid grey",
        width: "fit-content",
        justifyContent: "flex-start",
        borderRadius: "1.5625rem",
      }}
    >
      <ListItemText primary={text} secondary={sender} />
    </ListItem>
  );
};
export default TheirMessage;
