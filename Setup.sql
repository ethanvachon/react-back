USE finaldatabase2;

-- CREATE TABLE posts
-- (
--   id int AUTO_INCREMENT NOT NULL,
--   time VARCHAR(255) NOT NULL,
--   body VARCHAR(255) NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,

--   PRIMARY KEY(id),

--   FOREIGN KEY(creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE
-- );

-- CREATE TABLE comments
-- (
--   id int AUTO_INCREMENT NOT NULL,
--   postId int NOT NULL,
--   time VARCHAR(255) NOT NULL,
--   body VARCHAR(255) NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,

--   PRIMARY KEY(id),

--   FOREIGN KEY(creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE,

--   FOREIGN KEY(postId)
--     REFERENCES posts(id)
--     ON DELETE CASCADE

-- )