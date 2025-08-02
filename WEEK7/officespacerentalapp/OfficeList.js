import React from 'react';

const OfficeList = () => {
  const offices = [
    { name: "WeWork", rent: 45000, address: "Bangalore" },
    { name: "Awfis", rent: 75000, address: "Mumbai" },
    { name: "Smartworks", rent: 60000, address: "Delhi" },
  ];

  return (
    <div style={{ padding: '20px' }}>
      <h1>Available Office Spaces</h1>

      {/* Local Images from Public Folder */}
      <div style={{
        display: 'flex',
        gap: '20px',
        marginBottom: '30px',
        justifyContent: 'center',
        flexWrap: 'wrap'
      }}>
        <img
          src="/office1.jpg"
          alt="WeWork"
          style={{ width: '300px', height: '200px', objectFit: 'cover', borderRadius: '10px' }}
        />
        <img
          src="/office2.jpg"
          alt="AWfis"
          style={{ width: '300px', height: '200px', objectFit: 'cover', borderRadius: '10px' }}
        />
        <img
          src="/office3.jpg"
          alt="Smartworks"
          style={{ width: '300px', height: '200px', objectFit: 'cover', borderRadius: '10px' }}
        />
      </div>

      {/* Office Details */}
      {offices.map((office, index) => (
        <div key={index} style={{
          border: '1px solid #ccc',
          padding: '10px',
          margin: '10px 0',
          borderRadius: '8px'
        }}>
          <h2>{office.name}</h2>
          <p>{office.address}</p>
          <p style={{ color: office.rent < 60000 ? 'red' : 'green' }}>
            Rent: ₹{office.rent}
          </p>
        </div>
      ))}
    </div>
  );
};

export default OfficeList;
