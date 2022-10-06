CREATE TABLE CashFlow (
	Id bigint NOT NULL IDENTITY(1,1) PRIMARY KEY,
    DateCreated DateTime NOT NULL,
    Value float NOT NULL,
	DataTransaction DateTime NOT NULL,
	UserId int NOT NULL
); 