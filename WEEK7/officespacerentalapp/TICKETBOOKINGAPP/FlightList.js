import React from 'react';
import flights from './flightData';

function FlightList() {
  return (
    <div>
      <h3>Available Flights</h3>
      <div style={{
        display: 'flex',
        flexWrap: 'wrap',
        gap: '20px',
        justifyContent: 'center'
      }}>
        {flights.map((flight) => (
          <div key={flight.id} style={{
            border: '1px solid #ccc',
            borderRadius: '10px',
            padding: '10px',
            width: '250px',
            textAlign: 'center',
            backgroundColor: '#f9f9f9'
          }}>
            <img
              src={flight.image}
              alt={flight.airline}
              style={{ width: '100%', borderRadius: '10px' }}
            />
            <h4>{flight.airline}</h4>
            <p>{flight.from} ➝ {flight.to}</p>
            <p>🕒 {flight.time}</p>
          </div>
        ))}
      </div>
    </div>
  );
}

export default FlightList;
