import React from 'react';
import '../Stylesheets/mystyle.css';

function CalculateScore({ name, school, total, goal }) {
  const average = (total / goal).toFixed(2);
  return (
    <div className="score-box">
      <h3>{name}</h3>
      <p>School: {school}</p>
      <p>Total: {total}</p>
      <p>Goal: {goal}</p>
      <p>Average: {average}</p>
    </div>
  );
}

export default CalculateScore;
