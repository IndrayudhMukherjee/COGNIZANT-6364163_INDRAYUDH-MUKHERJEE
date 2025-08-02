
 

const CourseDetails = () => {
  const courses = [
    {
      title: 'Full Stack Web Development',
      institution: 'IIT Madras - Online',
      emoji: '💻',
      duration: '6 months',
    },
    {
      title: 'Fashion Design and Technology',
      institution: 'NIFT Delhi',
      emoji: '🧵',
      duration: '4 years',
    },
    {
      title: 'Acting and Theatre Arts',
      institution: 'National School of Drama (NSD)',
      emoji: '🎭',
      duration: '3 years',
    },
    {
      title: 'Product Design',
      institution: 'National Institute of Design (NID)',
      emoji: '🎨',
      duration: '4 years',
    },
    {
      title: 'Screenwriting & Filmmaking',
      institution: 'Film and Television Institute of India (FTII)',
      emoji: '✍️',
      duration: '2 years',
    },
  ];

  return (
    <div>
      <h2>🎓 Explore Courses</h2>
      {courses.map((course, index) => (
        <div key={index} style={{
          border: '1px solid #ccc',
          padding: '12px',
          marginBottom: '12px',
          borderRadius: '10px',
          backgroundColor: '#eef7ff'
        }}>
          <h3>{course.emoji} {course.title}</h3>
          <p><strong>Institution:</strong> {course.institution}</p>
          <p><strong>Duration:</strong> {course.duration}</p>
        </div>
      ))}
    </div>
  );
};

export default CourseDetails;
