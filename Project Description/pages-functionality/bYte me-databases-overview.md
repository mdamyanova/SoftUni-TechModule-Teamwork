#bYte me Databases overview
**Tables:**

1. **User**
 * columns: id, username, full name, password hash, profile photo, bio, likes count, dislikes count
2. **Photos – _relationship with user_**
 *	columns: id, photo, description
3. **Posts – _relationship with user_**
 *	columns: id, post title, post content, date
4. **Orders**
 *	columns: photo of product, description, required dislikes
