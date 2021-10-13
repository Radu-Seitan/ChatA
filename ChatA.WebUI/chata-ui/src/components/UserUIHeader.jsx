import CreateGroupRoom from "./CreateGroupRoom";
import SearchBar from "./SearchBar";
import { makeStyles } from "@mui/styles";

const useStyles = makeStyles(() => ({
  container: {
    paddingTop: "0.625rem",
  },
}));

const UserUIHeader = ({ setRerender, rerender }) => {
  const styles = useStyles();
  return (
    <div className={styles.container}>
      <SearchBar setRerender={setRerender} rerender={rerender} />
      <CreateGroupRoom setRerender={setRerender} rerender={rerender} />
    </div>
  );
};

export default UserUIHeader;
