import Box from "@mui/material/Box";
import Modal from "@mui/material/Modal";
import Typography from "@mui/material/Typography";
import ExitToAppIcon from "@mui/icons-material/ExitToApp";
import UserInModal from "./UserInModal";
import { IconButton } from "@mui/material";
import { AppBar } from "@material-ui/core";
import Toolbar from "@mui/material/Toolbar";
import { List } from "@mui/material";

const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 400,
  bgcolor: "background.paper",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
  borderRadius: "0.9375rem",
  "& > header": {
    borderRadius: "0.9375rem",
  },
};

const UsersModal = ({ open, setOpen, users, selectUser }) => {
  const renderUsers = () => {
    return users.map((value, index) => {
      return (
        <UserInModal
          key={`user-${value}-${index}`}
          user={value}
          selectUser={selectUser}
          setOpen={setOpen}
        />
      );
    });
  };

  return (
    <Modal
      open={open}
      aria-labelledby="modal-modal-title"
      aria-describedby="modal-modal-description"
      closeAfterTransition
    >
      <Box sx={style}>
        <AppBar position="static" sx={{ paddingBottom: "0.9375rem" }}>
          <Toolbar>
            <IconButton
              edge="start"
              color="inherit"
              aria-label="menu"
              sx={{ mr: 2 }}
              onClick={() => setOpen(false)}
            >
              <ExitToAppIcon sx={{ cursor: "pointer" }} />
            </IconButton>
            <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
              Searched users
            </Typography>
          </Toolbar>
        </AppBar>
        <List>{renderUsers()}</List>
      </Box>
    </Modal>
  );
};

export default UsersModal;
