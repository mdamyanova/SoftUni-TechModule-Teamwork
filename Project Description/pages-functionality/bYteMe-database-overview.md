#bYte me Database overview
Database name: **bYteMe**

![Database Screenshot](https://github.com/mdamyanova/SoftwareTechnologies-Teamwork-Project/blob/master/Project%20Description/pages-functionality/bYteMe-database-diagram.jpg)

**Tables:**

1. **Users**
 * Columns: 
    * Id (int, auto increment, unique)
    * Username (varchar(50), not null)
    * FullName (nvarchar(100), not null)
    * PasswordHash (varbinary(64), not null) 
    * ProfilePhoto (varbinary(MAX), not null) 
    * Biography (ntext) - _checking for null_
    * Likes (int) - _checking for positive number, if it's null - 0_
    * Dislikes (int) - _checking for positive number, if it's null - 0_
2. **Photos – _relationship with user_**
 * Columns: 
    * AuthorId (int) 
    * PhotoId (int, auto increment, unique)
    * Photo (varbinary(MAX), not null)
    * Description (ntext) - _checking for null_
3. **Posts – _relationship with user_**
 *	Columns: 
    * Id (int, auto increment, not null)
    * AuthorId (int, auto increment, not null, relationship with Users Id)
    * Title (nvarchar(200), not null)
    * Body (ntext, not null)
    * Date (datetime, not null)
4. **Orders**
 *	Columns: 
    *	OrderId (int, auto increment, not null) 
    *	Photo (varbinary(MAX), not null)
    *	Description (ntext, not null)
    *	RequiredDislikes (int, not null)
