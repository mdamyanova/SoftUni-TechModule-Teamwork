#bYte me Database overview
Database name: **bYteMe**

**Tables:**

1. **Users**
 * columns: 
    * Id (int, auto increment, unique)
    * Username (varchar(50), not null)
    * FullName (nvarchar(100), not null)
    * PasswordHash (varbinary(64), not null) 
    * ProfilePhoto (image, not null) 
    * Biography (ntext)
    * Likes (uint) 
    * Dislikes (uint)
2. **Photos – _relationship with user_**
 * columns: 
    * PhotoId (int, auto increment, unique)
    * Photo (image, not null)
    * Description (ntext, not null)
3. **Posts – _relationship with user_**
 *	columns: 
    * Id (int, auto increment, not null)
    * AuthorId (int, auto increment, not null, relationship with Users Id)
    * Title (nvarchar(200), not null)
    * Content (ntext, not null)
    * Date (datetime, not null)
4. **Orders**
 *	columns: 
    *	Id (int, auto increment, not null) 
    *	Photo (image, not null)
    *	Description (ntext, not null)
    *	RequiredDislikes (uint, not null)
