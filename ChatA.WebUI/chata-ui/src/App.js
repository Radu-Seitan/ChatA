import './App.css';
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
              <Profile />
            </>
        )
      }
    </>
  );
}

export default App;
