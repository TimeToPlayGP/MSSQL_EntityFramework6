create table [dbo].[projectEmployee]
(
[id_proj] int not null,
[id_comP] int not null,
foreign key ([id_proj]) REFERENCES [dbo].[project]([projID]),
foreign key ([id_comP]) REFERENCES [dbo].[employee]([empID]),
primary key ([id_proj],[id_comP] asc),
);