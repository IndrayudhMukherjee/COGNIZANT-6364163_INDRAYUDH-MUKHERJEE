import React, { useState } from 'react';
import ListOfPlayers from './ListOfPlayers';
import IndianPlayers from './IndianPlayers';

const TeamDisplay = () => {
  const [activeTab, setActiveTab] = useState('list'); // 'list' or 'indian'

  return (
    <div>
      <div style={{
        display: 'flex',
        justifyContent: 'center',
        gap: '20px',
        marginBottom: '20px'
      }}>
        <button
          onClick={() => setActiveTab('list')}
          style={{
            padding: '10px 20px',
            backgroundColor: activeTab === 'list' ? '#1976d2' : '#eee',
            color: activeTab === 'list' ? 'white' : 'black',
            border: 'none',
            borderRadius: '8px',
            cursor: 'pointer'
          }}
        >
          All Players
        </button>
        <button
          onClick={() => setActiveTab('indian')}
          style={{
            padding: '10px 20px',
            backgroundColor: activeTab === 'indian' ? '#1976d2' : '#eee',
            color: activeTab === 'indian' ? 'white' : 'black',
            border: 'none',
            borderRadius: '8px',
            cursor: 'pointer'
          }}
        >
          Indian Team (Odd/Even)
        </button>
      </div>

      {activeTab === 'list' ? <ListOfPlayers /> : <IndianPlayers />}
    </div>
  );
};

export default TeamDisplay;
