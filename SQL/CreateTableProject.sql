create table [dbo].[project]
(
[projID] int identity(1,1) not null,
[name] nvarchar(50) not null,
[dateStart] date not null,
[dateFinish] date not null,
[priority] int not null
CHECK ([priority] >= 0),
[comment] text null,
primary key ([projID] asc),
[id_projM] int not null,
[id_comP] int not null,
[id_comC] int not null,
foreign key ([id_projM]) REFERENCES [dbo].[projectManager]([pmID]),
foreign key ([id_comP]) REFERENCES [dbo].[companyPerformer]([comPID]),
foreign key ([id_comC]) REFERENCES [dbo].[companyCustomer]([comCID])
);