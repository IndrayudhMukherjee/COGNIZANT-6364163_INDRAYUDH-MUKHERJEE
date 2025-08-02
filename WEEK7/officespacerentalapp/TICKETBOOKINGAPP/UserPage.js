import React, { useState } from 'react';
import FlightList from './FlightList';

function UserPage() {
  const [booking, setBooking] = useState({
    name: '',
    flight: '',
  });

  const handleSubmit = (e) => {
    e.preventDefault();
    alert(`Ticket booked for ${booking.name} on ${booking.flight}`);
    setBooking({ name: '', flight: '' });
  };

  return (
    <div>
      <h2>Welcome,Welcome</h2>
      <p>You can now book your tickets below.</p>

      <form onSubmit={handleSubmit} style={{
        display: 'flex',
        flexDirection: 'column',
        gap: '10px',
        maxWidth: '300px',
        margin: '20px auto'
      }}>
        <input
          type="text"
          placeholder="Your Name"
          value={booking.name}
          onChange={(e) => setBooking({ ...booking, name: e.target.value })}
          required
        />
        <input
          type="text"
          placeholder="Flight (e.g., Air India)"
          value={booking.flight}
          onChange={(e) => setBooking({ ...booking, flight: e.target.value })}
          required
        />
        <button type="submit">Book Ticket</button>
      </form>

      <FlightList />
    </div>
  );
}

export default UserPage;
