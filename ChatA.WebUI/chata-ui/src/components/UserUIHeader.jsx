import CreateGroupRoom from "./CreateGroupRoom";
import SearchBar from "./SearchBar";
import { makeStyles } from "@mui/styles";

const useStyles = makeStyles(() => ({
  container: {
    padding: "0.625rem 0",
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
