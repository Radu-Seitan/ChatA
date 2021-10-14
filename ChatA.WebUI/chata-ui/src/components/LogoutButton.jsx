import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { Button } from "@mui/material";

const LogoutButton = () => {
  const { logout } = useAuth0();
  return (
    <Button
      variant="contained"
      className="logout-button"
      onClick={() => logout()}
      sx={{
        backgroundColor: "#fff",
        color: "#1976d2",
        "&:hover": {
          backgroundColor: "#eeeeee",
          borderColor: "#eeeeee",
        },
      }}
    >
      Log Out
    </Button>
  );
};

export default LogoutButton;
