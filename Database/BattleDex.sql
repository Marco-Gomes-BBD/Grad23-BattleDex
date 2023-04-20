USE master
GO

CREATE DATABASE BattleDexDB;
GO

USE BattleDexDB
GO

CREATE TABLE images(
    id          INT IDENTITY(1,1)   NOT NULL,
    file_path   NVARCHAR(260)       NOT NULL,
    CONSTRAINT pk_images PRIMARY KEY CLUSTERED (id ASC)
)
GO

CREATE TABLE tags(
    id      INT IDENTITY(1,1)   NOT NULL,
    tag     VARCHAR(50)         NOT NULL,
    CONSTRAINT pk_tags PRIMARY KEY CLUSTERED (id ASC)
)
GO

CREATE TABLE images_tags(
    id          INT IDENTITY(1,1)   NOT NULL,
    image_id    INT                 NOT NULL,
    tag_id      INT                 NOT NULL,
    CONSTRAINT pk_images_tags   PRIMARY KEY CLUSTERED (id ASC),
    CONSTRAINT fk_tag_image     FOREIGN KEY (image_id)  REFERENCES images(id),
    CONSTRAINT fk_image_tag     FOREIGN KEY (tag_id)    REFERENCES tags(id)
)
GO

-- CREATE TABLE slideshows(
--     id              INT IDENTITY(1,1)   NOT NULL,
--     topic           VARCHAR(120)        NOT NULL,
--     image_sequence  VARCHAR(50)         NULL,
--     duration        INT                 NOT NULL,
--     CONSTRAINT pk_slideshow PRIMARY KEY CLUSTERED (id ASC)
-- )
-- GO

-- CREATE TABLE slideshows_tags(
--     id              INT IDENTITY(1,1)   NOT NULL,
--     slideshow_id    INT                 NOT NULL,
--     tag_id          INT                 NOT NULL,
--     CONSTRAINT pk_slideshows_tags   PRIMARY KEY CLUSTERED (id ASC),
--     CONSTRAINT fk_tag_slideshow     FOREIGN KEY (slideshow_id)  REFERENCES slideshows(id),
--     CONSTRAINT fk_slideshow_tag     FOREIGN KEY (tag_id)        REFERENCES tags(id)
-- )
-- GO

-- CREATE TABLE slideshows_images(
--     id              INT IDENTITY(1,1)   NOT NULL,
--     slideshow_id    INT                 NOT NULL,
--     image_id        INT                 NOT NULL,
--     CONSTRAINT pk_slideshows_images PRIMARY KEY CLUSTERED (id ASC),
--     CONSTRAINT fk_image_slideshow   FOREIGN KEY (slideshow_id)  REFERENCES slideshows(id),
--     CONSTRAINT fk_slideshow_image   FOREIGN KEY (image_id)      REFERENCES images(id)
-- )
-- GO