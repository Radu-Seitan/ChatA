import './App.css';
import LogoutButton from './components/LogoutButton';
import Profile from './components/Profile';
import { useAuth0 } from '@auth0/auth0-react';

function App() {
  const { isLoading, isAuthenticated, loginWithRedirect} = useAuth0();

  if (isLoading) return (
    <div>Loading...</div>
  )
  if (!isAuthenticated) {
    loginWithRedirect()
  }
  return (
    <>
      {
        isAuthenticated && (
            <>
              <LogoutButton />
              <Profile />
            </>
        )
      }
    </>
  );
}

export default App;
