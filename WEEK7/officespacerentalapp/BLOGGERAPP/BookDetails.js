const BookDetails = () => {
  const books = [
    {
      title: 'Inferno',
      author: 'Dante Alighieri',
      emoji: '🔥',
    },
    {
      title: 'Harry Potter and the Prisoner of Azkaban',
      author: 'J.K. Rowling',
      emoji: '🧙‍♂️',
    },
    {
      title: 'Feluda: Sonar Kella',
      author: 'Satyajit Ray',
      emoji: '🕵️‍♂️',
    },
    {
      title: 'Feluda: Joi Baba Felunath',
      author: 'Satyajit Ray',
      emoji: '🔍',
    },
    {
      title: 'Harry Potter and the Half-Blood Prince',
      author: 'J.K. Rowling',
      emoji: '🧪',
    }
  ];

  return (
    <div>
      <h2>📘 Book Nerds Assemble</h2>
      {books.map((book, index) => (
        <div key={index} style={{
          border: '1px solid #ccc',
          padding: '10px',
          marginBottom: '10px',
          borderRadius: '8px',
          backgroundColor: '#f9f9f9'
        }}>
          <h3>{book.emoji} {book.title}</h3>
          <p>Author: {book.author}</p>
        </div>
      ))}
    </div>
  );
};

export default BookDetails;
