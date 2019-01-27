create table [dbo].[companyPerformer]
(
[comPID] int identity(1,1) not null,
[name] nvarchar(50) not null,
[address] nvarchar(50) not null,
[email] nvarchar(50) null,
[WebSite] nvarchar(200) null,
primary key ([comPID] asc)
);