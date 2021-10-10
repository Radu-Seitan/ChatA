import CreateGroupRoom from "./CreateGroupRoom";
import SearchBar from "./SearchBar";
import { makeStyles } from "@mui/styles";

const useStyles = makeStyles(() => ({
  container: {
    backgroundColor: "#edeba0",
    paddingTop: "0.625rem",
  },
}));

const UserUIHeader = () => {
  const styles = useStyles();
  return (
    <div className={styles.container}>
      <SearchBar />
      <CreateGroupRoom />
    </div>
  );
};

export default UserUIHeader;
