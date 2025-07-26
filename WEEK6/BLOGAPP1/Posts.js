import React, { Component } from 'react';
import Post from './Post';

class Posts extends Component {
  constructor() {
    super();
    this.state = {
      posts: [
        {
          id: 1,
          title: '☔ Bangalore Weather Vibes',
          body: 'It was sunny at 9am, raining by 11am, and sunny again at 2pm! Typical Namma Bengaluru weather.'
        },
        {
          id: 2,
          title: '🛵 Silk Board Traffic Chronicles',
          body: 'What started as a quick 5km ride turned into an epic 1-hour journey. Shoutout to all the office goers making it through the jam 🙌.'
        },
        {
          id: 3,
          title: '☕ Filter Coffee vs Cold Brew',
          body: 'Bangalore’s startup crowd loves their cold brew, but nothing beats a strong darshini-style filter coffee on a rainy day!'
        },
        {
          id: 4,
          title: '🏞️ Cubbon Park Morning Bliss',
          body: 'Fresh air, heritage trees, and yoga aunties doing pranayama – Cubbon Park is Bangalore’s green heart. A must-visit!'
        },
        {
          id: 5,
          title: '🎸 MG Road to Brigade Vibes',
          body: 'Weekend scenes at Church Street are just chef’s kiss. Bookstores, chai, and live guitar = Bangalore magic.'
        }
      ],
      error: null
    };
  }

  componentDidCatch(error, info) {
    alert('Something went wrong: ' + error);
  }

  render() {
    return (
      <div style={{ padding: '20px', fontFamily: 'Segoe UI' }}>
        <h2>🌇 Namma Bengaluru Blog Feed</h2>
        <p>Live updates from the garden city 🌿 | Powered by React ⚛️</p>
        {this.state.posts.map(post => (
          <Post key={post.id} title={post.title} body={post.body} />
        ))}
      </div>
    );
  }
}

export default Posts;
