import PersonIcon from "@mui/icons-material/Person";
import { ListItemIcon } from "@mui/material";
import { ListItemText } from "@mui/material";
import { ListItem } from "@mui/material";
import { makeStyles } from "@mui/styles";

const useStyles = makeStyles(() => ({
  container: {
    border: "0.0625rem solid",
    borderColor: "black",
  },
}));

const User = ({ user, selectUser, setOpen }) => {
  const styles = useStyles();
  return (
    <ListItem
      onClick={() => {
        selectUser(user);
        setOpen(false);
      }}
      className={styles.conatiner}
    >
      <ListItemIcon>
        <PersonIcon />
      </ListItemIcon>
      <ListItemText>{user.username}</ListItemText>
    </ListItem>
  );
};

export default User;
