import Box from "@mui/material/Box";
import Modal from "@mui/material/Modal";
import Typography from "@mui/material/Typography";
import ExitToAppIcon from "@mui/icons-material/ExitToApp";
import TextField from "@mui/material/TextField";
import { IconButton, ImageListItem } from "@mui/material";
import { AppBar } from "@material-ui/core";
import Toolbar from "@mui/material/Toolbar";

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

const UserInGroupRoomModal = ({ user, open, setOpen }) => {
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
              Profile
            </Typography>
          </Toolbar>
        </AppBar>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            justifyContent: "space-between",
            marginTop: "20px",
            gap: "20px",
          }}
        >
          <ImageListItem
            sx={{
              width: "200px",
              height: "200px",
              marginLeft: "66px",
            }}
          >
            <img
              src={
                user.imageId
                  ? `api/images/${user.imageId}`
                  : `https://res.cloudinary.com/dxd6gnoof/image/upload/v1641837673/no-user-profile-picture-hand-drawn-illustration-53840792_bxrzb8.jpg`
              }
              alt="user-profile-pic"
            />
          </ImageListItem>
          <TextField
            id="outlined-required"
            label="Name"
            defaultValue={`${user.username}`}
            InputProps={{
              readOnly: true,
            }}
          />
          <TextField
            id="outlined-required"
            label="Email"
            defaultValue={`${user.email}`}
            InputProps={{
              readOnly: true,
            }}
          />
        </Box>
      </Box>
    </Modal>
  );
};

export default UserInGroupRoomModal;
