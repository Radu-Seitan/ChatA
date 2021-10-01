const SearchBar = () => (
  <form action="/" method="get">
    <input type="text" id="header-search" placeholder="Search user" name="s" />
    <button className="search-button" type="submit">
      Search
    </button>
  </form>
);

export default SearchBar;
