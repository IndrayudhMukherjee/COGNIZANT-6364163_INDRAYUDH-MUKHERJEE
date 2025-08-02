import React, { useState } from 'react';
import BookDetails from './BookDetails';
import BlogDetails from './BlogDetails';
import CourseDetails from './CourseDetails';

function ConditionalRenderer() {
  const [view, setView] = useState('book');

  // Conditional rendering using if-else (JS logic)
  let componentToRender;
  if (view === 'book') componentToRender = <BookDetails />;
  else if (view === 'blog') componentToRender = <BlogDetails />;
  else componentToRender = <CourseDetails />;

  return (
    <div>
      <h1>📚 Blogger App</h1>

      {/* Buttons to change state */}
      <div style={{ marginBottom: '20px' }}>
        <button onClick={() => setView('book')}>Show Book</button>
        <button onClick={() => setView('blog')}>Show Blog</button>
        <button onClick={() => setView('course')}>Show Course</button>
      </div>

      {/* Render selected component */}
      {componentToRender}

      {/* Conditional rendering using ternary operator */}
      <div style={{ marginTop: '30px' }}>
        <h3>🔁 Also showing using ternary:</h3>
        {view === 'blog' ? <p>You're reading a blog post!</p> : <p>This is not a blog.</p>}
      </div>

      {/* Conditional rendering using logical && */}
      {view === 'course' && (
        <p style={{ color: 'green', fontStyle: 'italic' }}>
          ✔️ This is an exquisite course to enroll in!
        </p>
      )}
    </div>
  );
}

export default ConditionalRenderer;
