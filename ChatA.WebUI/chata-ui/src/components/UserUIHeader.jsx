import CreateGroupRoom from "./CreateGroupRoom";
import SearchBar from "./SearchBar";
import { makeStyles } from "@mui/styles";
import { Box } from "@mui/system";

const useStyles = makeStyles(() => ({
  container: {
    padding: "0.625rem 0",
    position: "sticky",
    top: "0",
    backgroundColor: "rgb(232, 240, 254)",
    zIndex: "9999",
  },
}));

const UserUIHeader = ({ setRerender, rerender }) => {
  const styles = useStyles();
  return (
    <Box className={styles.container}>
      <SearchBar setRerender={setRerender} rerender={rerender} />
      <CreateGroupRoom setRerender={setRerender} rerender={rerender} />
    </Box>
  );
};

export default UserUIHeader;
