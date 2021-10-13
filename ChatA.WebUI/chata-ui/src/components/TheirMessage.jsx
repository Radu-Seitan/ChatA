import { ListItem } from "@mui/material";
import Typography from "@mui/material/Typography";
import { ListItemText } from "@mui/material";
import { Box } from "@mui/system";

const TheirMessage = ({ message }) => {
  const text = message.text;
  const created = message.created.split("T");
  const time = created[1].substr(0, 5);
  const date = created[0].split("-").reverse().join("-");

  const sender = `Sent by ${message.sentBy} at ${time} on ${date}`;
  return (
    <ListItem className="my-message" alignItems="flex-start">
      <ListItemText primary={text} secondary={sender} />
    </ListItem>
  );
};
export default TheirMessage;
