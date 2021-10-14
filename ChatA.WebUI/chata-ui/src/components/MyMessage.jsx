import { ListItem } from "@mui/material";
import Typography from "@mui/material/Typography";
import { ListItemText } from "@mui/material";
import { format } from "date-fns";

const MyMessage = ({ message }) => {
  const text = message.text;
  const created = message.created.split("T");
  const time = created[1].substr(0, 5);
  const date = created[0].split("-").reverse().join("-");
  const sender = `Sent by ${message.sentBy} at ${time} on ${date}`;
  return (
    <ListItem
      className="my-message"
      sx={{
        borderBottom: "1px solid grey",
        width: "fit-content",
        justifyContent: "flex-end",
      }}
    >
      <ListItemText primary={text} secondary={sender} />
    </ListItem>
  );
};
export default MyMessage;
