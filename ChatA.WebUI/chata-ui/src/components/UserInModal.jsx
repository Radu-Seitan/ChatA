import PersonIcon from "@mui/icons-material/Person";
import { ListItemIcon } from "@mui/material";
import { ListItemText } from "@mui/material";
import { ListItem } from "@mui/material";
import { makeStyles } from "@mui/styles";

const UserInModal = ({ user, selectUser, setOpen }) => {
  return (
    <ListItem
      onClick={() => {
        selectUser(user);
        setOpen(false);
      }}
      sx={{
        cursor: "pointer",
        border: "0.0625rem solid grey",
        borderRadius: "0.625rem",
      }}
    >
      <ListItemIcon>
        <PersonIcon />
      </ListItemIcon>
      <ListItemText>{user.username}</ListItemText>
    </ListItem>
  );
};

export default UserInModal;
