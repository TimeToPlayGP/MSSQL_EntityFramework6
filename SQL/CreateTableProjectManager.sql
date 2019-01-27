create table [dbo].[projectManager]
(
[pmID] int identity(1,1) not null,
[surname] nvarchar(20) not null,
[name] nvarchar(20) not null,
[middlename] nvarchar(20) not null,
[email] nvarchar(50) null,
primary key ([pmID] asc)
);