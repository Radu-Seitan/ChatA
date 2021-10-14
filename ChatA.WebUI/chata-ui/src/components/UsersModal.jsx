import Box from "@mui/material/Box";
import Modal from "@mui/material/Modal";
import Typography from "@mui/material/Typography";
import ExitToAppIcon from "@mui/icons-material/ExitToApp";
import UserInModal from "./UserInModal";

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
        <ExitToAppIcon onClick={() => setOpen(false)} />
        {renderUsers()}
      </Box>
    </Modal>
  );
};

export default UsersModal;
