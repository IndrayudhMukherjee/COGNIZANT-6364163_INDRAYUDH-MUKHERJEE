import React from 'react';

const IndianPlayers = () => {
  const T20players = ['Virat', 'Rohit', 'Pant', 'Hardik'];
  const RanjiPlayers = ['Shaw', 'Iyer', 'Sarfaraz', 'Dhruv'];

  // Merge both
  const allPlayers = [...T20players, ...RanjiPlayers];

  // Destructure into odd and even team
  const oddPlayers = allPlayers.filter((_, idx) => idx % 2 === 0);
  const evenPlayers = allPlayers.filter((_, idx) => idx % 2 !== 0);

  return (
    <div>
      <h2>🇮🇳 Indian Players by Team</h2>
      <div>
        <h3>🏏 Odd Team</h3>
        <ul>{oddPlayers.map((p, i) => <li key={i}>{p}</li>)}</ul>
      </div>
      <div>
        <h3>🏏 Even Team</h3>
        <ul>{evenPlayers.map((p, i) => <li key={i}>{p}</li>)}</ul>
      </div>
    </div>
  );
};

export default IndianPlayers;
