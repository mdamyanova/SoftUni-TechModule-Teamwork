/*TODO: FIND IMAGES FROM INTERNET:*/ 

INSERT [dbo].[Users] ([Username], [FullName], [PasswordHash], [ProfilePhoto], [Biography], [Likes], [Dislikes]) 
VALUES ('grape', 'Grozdan Shekerov', HASHBYTES('SHA2_256', 'tainamaina'), 
	(SELECT * FROM OPENROWSET (BULK '', SINGLE_BLOB) AS ProfilePhoto),
	 'Hi, my name is Grozdan Shekerov. I know Java and I have a lots of money. 
	 I don\' have to make money anymore. 
	 I\'m looking for my soulmate to have a garden together and make wine.', 
	 null, null)

INSERT [dbo].[Users] ([Username], [FullName], [PasswordHash], [ProfilePhoto], [Biography], [Likes], [Dislikes]) 
VALUES ('gosho', 'Georgi Petrev', HASHBYTES('SHA2_256', 'shakalaka'), 
	(SELECT * FROM OPENROWSET (BULK '', SINGLE_BLOB) AS ProfilePhoto),
	 'If you are looking for passionate and intelligent bulgarian developer, stop looking and just stare at me. 
	 I am here for you and I am gonna take you at home.',
	 null, null)

INSERT [dbo].[Users] ([Username], [FullName], [PasswordHash], [ProfilePhoto], [Biography], [Likes], [Dislikes]) 
VALUES ('pie123', 'Varadina Koleva', HASHBYTES('SHA2_256', 'wtf'), 
	(SELECT * FROM OPENROWSET (BULK '', SINGLE_BLOB) AS ProfilePhoto),
	'I am one ambitious woman, 23 years old. I hope here I\'ll find my prince and together we can start building our castle. 
	 Don\'t hesitate to connect with me', 
	 null, null)

INSERT [dbo].[Users] ([Username], [FullName], [PasswordHash], [ProfilePhoto], [Biography], [Likes], [Dislikes]) 
VALUES ('classy_dev', 'John Todorov', HASHBYTES('SHA2_256', 'littleJohny'), 
	(SELECT * FROM OPENROWSET (BULK '', SINGLE_BLOB) AS ProfilePhoto),
	 'My mother is american and my father is from Mezdra, Bulgaria. 
	 I live in Sofia and I really like girls with interests in web development.',
	 null, null)

INSERT [dbo].[Users] ([Username], [FullName], [PasswordHash], [ProfilePhoto], [Biography], [Likes], [Dislikes]) 
VALUES ('sladura18', 'Kawaki Gazawaki', HASHBYTES('SHA2_256', 'sladura18'), 
	(SELECT * FROM OPENROWSET (BULK '', SINGLE_BLOB) AS ProfilePhoto),
	 'I\'ve found this bulgarian site, but I\'m from China. 
	 Nevermind, I hope here will be my beauty queen. I am tired of looking for love. 
	 Hope this is the last searching and I will be able to be happy.', 
	 null, null)

INSERT [dbo].[Users] ([Username], [FullName], [PasswordHash], [ProfilePhoto], [Biography], [Likes], [Dislikes]) 
VALUES ('choo9', 'Choo Koo Koo', HASHBYTES('SHA2_256', 'koko'), 
	(SELECT * FROM OPENROWSET (BULK '', SINGLE_BLOB) AS ProfilePhoto),
	 'I am Choo Koo Koo, girl from China, 19 years old. 
	 I have no bugs, only features. Looking for someone to write code with.',
	  null, null)

INSERT [dbo].[Users] ([Username], [FullName], [PasswordHash], [ProfilePhoto], [Biography], [Likes], [Dislikes]) 
VALUES ('sasheto0o', 'Alexandra Ivanova', HASHBYTES('SHA2_256', 'mathlover'), 
	(SELECT * FROM OPENROWSET (BULK '', SINGLE_BLOB) AS ProfilePhoto),
	 'Здравейте, аз уча в СУ. Понякога ми става скучно от всичкото това учене и тази математика. 
	 Тук искам да прекарвам свободното си време. Нямам никакви проблеми от ученето, не съм зубър и не мечтая за принца от приказките. 
	 Надявам се да намеря моята 1/2, за да станем едно цяло. :)', 
	 null, null)

INSERT [dbo].[Users] ([Username], [FullName], [PasswordHash], [ProfilePhoto], [Biography], [Likes], [Dislikes]) 
VALUES ('hacker', 'Sebastian Mitrokolev', HASHBYTES('SHA2_256', 'hack'), 
	(SELECT * FROM OPENROWSET (BULK '', SINGLE_BLOB) AS ProfilePhoto),
	 'I am hacker. Thug life.',  
	 null, null)

INSERT [dbo].[Users] ([Username], [FullName], [PasswordHash], [ProfilePhoto], [Biography], [Likes], [Dislikes]) 
VALUES ('ouzo134', 'Alexis Stavakis', HASHBYTES('SHA2_256', 'ouzo134'), 
	(SELECT * FROM OPENROWSET (BULK '', SINGLE_BLOB) AS ProfilePhoto),
	 'zanimavam se s sait4eta ala bala i obicham jenite da mi otkazvat za6toto tqhnoto NE na moq ezik e DA', 
	 null, null)

INSERT [dbo].[Users] ([Username], [FullName], [PasswordHash], [ProfilePhoto], [Biography], [Likes], [Dislikes]) 
VALUES ('desperate_wife', 'Korneliya Nailova', HASHBYTES('SHA2_256', 'ihatemyman'), 
	(SELECT * FROM OPENROWSET (BULK '', SINGLE_BLOB) AS ProfilePhoto),
	 'Ruby developer in Panaguyrishte. I am here for new adventures.', 
	 null, null)