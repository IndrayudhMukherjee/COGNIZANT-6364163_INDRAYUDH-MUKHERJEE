import React from 'react';
import Counter from './components/Counter';
import WelcomeButton from './components/WelcomeButton';
import ClickMessage from './components/ClickMessage';
import CurrencyConvertor from './components/CurrencyConvertor';

function App() {
  return (
    <div>
      <h1>Currency ALL the wayfun</h1>
      <Counter />
      <WelcomeButton />
      <ClickMessage />
      <CurrencyConvertor />
    </div>
  );
}

export default App;
