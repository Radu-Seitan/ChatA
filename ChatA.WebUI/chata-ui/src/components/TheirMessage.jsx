import { ListItem } from "@mui/material";
import Typography from "@mui/material/Typography";
import { ListItemText } from "@mui/material";
import { Tooltip } from "@mui/material";

const TheirMessage = ({ message }) => {
  const text = message.text;
  const created = message.created.split("T");
  const time = created[1].substr(0, 5);
  const date = created[0].split("-").reverse().join("-");

  const sender = `Sent by ${message.sentBy} at ${time} on ${date}`;
  return (
    <Tooltip title={sender} placement="right">
      <ListItem
        className="my-message"
        sx={{
          width: "fit-content",
          justifyContent: "flex-start",
          borderRadius: "1rem",
          backgroundColor: "#eeeeee",
          border: "1px solid lightgrey",
        }}
      >
        <ListItemText primary={text} />
      </ListItem>
    </Tooltip>
  );
};
export default TheirMessage;
