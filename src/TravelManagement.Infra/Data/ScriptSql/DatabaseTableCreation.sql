IF DB_ID('TravelTestDB') IS NOT NULL
   DROP DATABASE TravelTestDB;

CREATE DATABASE TravelTestDB;

USE TravelTestDB;

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users' AND TABLE_TYPE = 'BASE TABLE')
	DROP TABLE Users;

CREATE TABLE Users (
       Id                             uniqueidentifier     NOT NULL     PRIMARY KEY                  DEFAULT NEWID(),
       FullName                       varchar(100)         NOT NULL,
	   Email                          varchar(255)         NOT NULL,
       [Password]                     varchar(MAX)         NOT NULL,
	   CreatedAt                      datetimeoffset(7)    NOT NULL                                  DEFAULT GETUTCDATE(),
       UpdatedAt                      datetimeoffset(7)        NULL,
);	
