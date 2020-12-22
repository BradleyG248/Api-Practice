USE shoestore4;

-- CREATE TABLE polls (
--   id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   img VARCHAR(255),
--   PRIMARY KEY (id)
-- );
-- CREATE TABLE questions (
--   id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id),
--   pollId int NOT NULL,
--   FOREIGN KEY (pollId)
--   REFERENCES polls(id)
--   ON DELETE CASCADE
-- )
CREATE TABLE options (
  id int NOT NULL AUTO_INCREMENT,
  value VARCHAR(255) NOT NULL,
  PRIMARY KEY (id),
  questionId int NOT NULL,
  FOREIGN KEY (questionId)
  REFERENCES questions(id)
  ON DELETE CASCADE
)

-- CREATE TABLE gardens (
--   id int NOT NULL AUTO_INCREMENT,
--   userId VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   description VARCHAR(255),
--   backGround VARCHAR(255),
--   width int NOT NULL,
--   height int NOT NULL,
--   PRIMARY KEY (id)
-- )

-- CREATE TABLE bedtemplates (
--   id int NOT NULL AUTO_INCREMENT,
--   userId VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   width INT,
--   height INT,
--   img VARCHAR(255),
--   PRIMARY KEY (id)
-- )

-- CREATE TABLE groups (
--   id int NOT NULL AUTO_INCREMENT,
--   userId VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   PRIMARY KEY (id)
-- )

-- CREATE TABLE bedgroups (
--   id int NOT NULL AUTO_INCREMENT,
--   userId VARCHAR(255) NOT NULL,
--   bedId int NOT NULL,
--   groupId int NOT NULL,
--   gardenId int NOT NULL,
--   PRIMARY KEY (id),

--   FOREIGN KEY (gardenId)
--     REFERENCES gardens(id)
--     ON DELETE CASCADE,

--     FOREIGN KEY (bedId)
--     REFERENCES beds(id)
--     ON DELETE CASCADE,

--     FOREIGN KEY (groupId)
--     REFERENCES groups(id)
--     ON DELETE CASCADE,

--   UNIQUE(bedId, groupId),
--   UNIQUE(bedId, gardenId)
-- )

-- USE THIS LINE FOR GET KEEPS BY VAULTID
-- g.id as groupId


-- SELECT 
-- b.*,
-- FROM bedgroups bg
-- INNER JOIN beds b ON b.id = bg.bedId 
-- WHERE (bg.userId = @userId AND bg.bedId = @id)


-- INNER JOIN groups g ON g.id = bg.groupId
-- WHERE (bg.groupId = @id AND bg.userId = @userId)

-- Drop your tables
-- DROP TABLE IF EXISTS gardens;
-- DROP TABLE IF EXISTS beds;
-- DROP TABLE IF EXISTS groups;
-- DROP TABLE IF EXISTS bedtemplates;
-- DROP TABLE IF EXISTS bedgroups;

-- SELECT * FROM bed WHERE id = 2