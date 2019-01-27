create table [dbo].[companyCustomer]
(
[comCID] int identity(1,1) not null,
[name] nvarchar(50) not null,
[address] nvarchar(50) not null,
[email] nvarchar(50) null,
primary key ([comCID] asc)
);