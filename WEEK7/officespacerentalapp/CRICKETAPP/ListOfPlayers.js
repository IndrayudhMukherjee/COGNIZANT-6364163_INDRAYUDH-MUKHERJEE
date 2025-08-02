import React from 'react';

const ListOfPlayers = () => {
  const players = [
    { name: 'Virat Kohli', score: 85 },
    { name: 'Rohit Sharma', score: 68 },
    { name: 'Shubman Gill', score: 74 },
    { name: 'MS Dhoni', score: 45 },
    { name: 'Hardik Pandya', score: 90 },
    { name: 'Rishabh Pant', score: 60 },
    { name: 'Jasprit Bumrah', score: 30 },
    { name: 'Ravindra Jadeja', score: 88 },
    { name: 'Suryakumar Yadav', score: 71 },
    { name: 'Shreyas Iyer', score: 66 },
    { name: 'Kuldeep Yadav', score: 39 },
  ];

  // Filter players scoring below 70
  const lowScorers = players.filter(player => player.score < 70);

  return (
    <div>
      <h2>🏏 List of Players</h2>
      <ul>
        {players.map((player, index) => (
          <li key={index}>
            {player.name} - {player.score}
          </li>
        ))}
      </ul>
      <h3>⛔ Players who scored below 70:</h3>
      <ul>
        {lowScorers.map((player, index) => (
          <li key={index}>
            {player.name} - {player.score}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ListOfPlayers;
