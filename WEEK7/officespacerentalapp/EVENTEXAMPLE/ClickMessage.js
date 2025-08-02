import React from 'react';

function ClickMessage() {
  const handleClick = (e) => {
    alert("yayyya!!!!I was clicked!");
    console.log("Synthetic and aesthetic Event:", e);
  };

  return <button onClick={handleClick}>Click Me</button>;
}

export default ClickMessage;
