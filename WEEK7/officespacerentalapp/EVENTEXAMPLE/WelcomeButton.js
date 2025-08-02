import React from 'react';

function WelcomeButton() {
  const sayWelcome = (msg) => {
    alert(msg);
  };

  return (
    <button onClick={() => sayWelcome("IF you are here, Beware...jk")}>
      Say Welcome
    </button>
  );
}

export default WelcomeButton;
