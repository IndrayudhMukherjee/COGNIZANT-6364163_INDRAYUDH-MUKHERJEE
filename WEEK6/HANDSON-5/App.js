// src/App.js
import React from 'react';
import CohortDetails from './CohortDetails';

function App() {
  const cohorts = [
    {
      name: "Full stack web development with python and react",
      status: "Ongoing",
      startDate: "2025-06-01",
      endDate: "2025-08-01"
    },
    {
      name: "agentic ai bootcamp",
      status: "Completed",
      startDate: "2025-01-01",
      endDate: "2025-03-01"
    }
  ];

  return (
    <div>
      {cohorts.map((c, i) => (
        <CohortDetails key={i} cohort={c} />
      ))}
    </div>
  );
}

export default App;
