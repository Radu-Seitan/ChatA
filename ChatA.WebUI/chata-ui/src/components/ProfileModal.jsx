import Box from "@mui/material/Box";
import Modal from "@mui/material/Modal";
import Typography from "@mui/material/Typography";
import ExitToAppIcon from "@mui/icons-material/ExitToApp";
import TextField from "@mui/material/TextField";
import { IconButton, ImageListItem, Button, Input } from "@mui/material";
import { AppBar } from "@material-ui/core";
import Toolbar from "@mui/material/Toolbar";
import { useAuth0 } from "@auth0/auth0-react";
import { useState } from "react";
import axiosInstance from "../utils/axios";
import { useEffect } from "react";

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

const ProfileModal = ({ open, setOpen }) => {
  const { user } = useAuth0();
  const [username, setUsername] = useState();
  const [email, setEmail] = useState();
  const [userFromDatabase, setUserFromDatabase] = useState();
  const [imageUrl, setImageUrl] = useState(
    `https://res.cloudinary.com/dxd6gnoof/image/upload/v1641837673/no-user-profile-picture-hand-drawn-illustration-53840792_bxrzb8.jpg`
  );
  const [imageFile, setImageFile] = useState();

  const changeUserDetails = async () => {
    let imageId = null;
    if (imageFile) {
      const uploadData = new FormData();
      uploadData.append("file", imageFile);
      const res = await axiosInstance.post(`api/images`, uploadData);
      imageId = res.data;
      setImageUrl(`api/images/${res.imageId}`);
    }

    await axiosInstance.put(`api/users`, {
      username: username,
      email: email,
      imageId: imageId,
    });

    await getUser();
  };

  const getUser = async () => {
    const res = await axiosInstance.get(`api/users/${user.sub}`);
    setUserFromDatabase(res.data);
    setUsername(res.data.username);
    setEmail(res.data.email);
  };

  useEffect(() => {
    getUser();
    if (userFromDatabase && userFromDatabase.imageId !== null) {
      setImageUrl(`api/images/${userFromDatabase.imageId}`);
    }
  }, [open]);

  const showPreview = (e) => {
    if (e.target.files && e.target.files[0]) {
      let imageFile = e.target.files[0];
      const reader = new FileReader();
      reader.onload = (x) => {
        setImageFile(imageFile);
        setImageUrl(x.target.result);
      };
      reader.readAsDataURL(imageFile);
    }
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
            <img src={imageUrl} alt="user-profile-pic" />
          </ImageListItem>
          <Input
            type="file"
            accept="image/*"
            className={"form-control-file"}
            onChange={showPreview}
            id="image-uploader"
          />
          <TextField
            id="outlined-required"
            label="Name"
            defaultValue={`${username}`}
            onChange={(e) => setUsername(e.target.value)}
          />
          <TextField
            id="outlined-required"
            label="Email"
            defaultValue={`${email}`}
            onChange={(e) => setEmail(e.target.value)}
          />
          <Button
            variant="contained"
            sx={{ marginLeft: "106px" }}
            onClick={() => {
              changeUserDetails();
              setOpen(false);
            }}
          >
            Change details
          </Button>
        </Box>
      </Box>
    </Modal>
  );
};

export default ProfileModal;
