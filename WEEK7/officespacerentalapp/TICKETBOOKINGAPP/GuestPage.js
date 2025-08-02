import React from 'react';
import FlightList from './FlightList';

function GuestPage() {
  return (
    <div>
      <h2>Welcome Ladies and Gentlemen</h2>
      <p>You can browse flight details below. Login to book tickets.</p>
      <FlightList />
    </div>
  );
}

export default GuestPage;
