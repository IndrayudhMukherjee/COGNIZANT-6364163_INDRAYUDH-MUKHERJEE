import React, { useState } from 'react';
import GuestPage from './GuestPage';
import UserPage from './UserPage';

function LoginControl() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLoginClick = () => setIsLoggedIn(true);
  const handleLogoutClick = () => setIsLoggedIn(false);

  return (
    <div>
      <h1>✈️ Ticket Booking Made Easy...</h1>
      <div style={{ marginBottom: '20px' }}>
        {isLoggedIn ? (
          <button onClick={handleLogoutClick}>Logout</button>
        ) : (
          <button onClick={handleLoginClick}>Login</button>
        )}
      </div>

      {isLoggedIn ? <UserPage /> : <GuestPage />}
    </div>
  );
}

export default LoginControl;
