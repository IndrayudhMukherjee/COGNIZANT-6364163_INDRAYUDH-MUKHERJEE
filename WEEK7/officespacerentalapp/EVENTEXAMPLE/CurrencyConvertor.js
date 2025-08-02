import React, { useState } from 'react';

function CurrencyConvertor() {
  const [rupees, setRupees] = useState('');
  const [euro, setEuro] = useState('');

  const handleSubmit = () => {
    const converted = (parseFloat(rupees) / 100).toFixed(2);
    setEuro(converted);
  };

  return (
    <div>
      <input
        type="number"
        value={rupees}
        onChange={(e) => setRupees(e.target.value)}
        placeholder="Enter amount in INR"
      />
      <button onClick={handleSubmit}>Convert</button>
      <p>Euro: €{euro}</p>
    </div>
  );
}

export default CurrencyConvertor;
