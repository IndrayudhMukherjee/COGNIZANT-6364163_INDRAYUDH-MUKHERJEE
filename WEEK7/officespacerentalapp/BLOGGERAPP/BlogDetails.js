const BlogDetails = () => {
  const blogs = [
    {
      title: 'Demystifying React Lifecycle',
      author: 'DevWeekly',
      emoji: '🔁',
      snippet: 'Understanding component mounting, updating, and unmounting phases.',
    },
    {
      title: 'How I Refactored 1000 Lines of JS',
      author: 'CodeCraft',
      emoji: '🛠️',
      snippet: 'A journey through linting, abstraction, and the magic of reusable functions.',
    },
    {
      title: 'CSS Grid vs Flexbox: When to Use What',
      author: 'PixelNerd',
      emoji: '🎨',
      snippet: 'A visual breakdown of layout strategies in modern CSS.',
    },
    {
      title: 'Satyajit Ray: The Tech Enthusiast',
      author: 'RayBlogs',
      emoji: '🎬',
      snippet: 'A look at how the filmmaker’s mind would fit into today’s creative coding world.',
    },
    {
      title: 'Building a Blog App with React',
      author: 'Frontend Fuel',
      emoji: '🚀',
      snippet: 'Step-by-step guide to building and deploying your own blog system with ReactJS.',
    },
  ];

  return (
    <div>
      <h2>📝 Blog Central</h2>
      {blogs.map((blog, index) => (
        <div key={index} style={{
          border: '1px solid #ccc',
          padding: '12px',
          marginBottom: '12px',
          borderRadius: '10px',
          backgroundColor: '#f4f4f4'
        }}>
          <h3>{blog.emoji} {blog.title}</h3>
          <p><strong>Author:</strong> {blog.author}</p>
          <p><em>{blog.snippet}</em></p>
        </div>
      ))}
    </div>
  );
};

export default BlogDetails;
