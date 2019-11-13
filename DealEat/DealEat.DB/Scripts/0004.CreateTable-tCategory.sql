create table dealeat.tCategory
(
	CategoryId int identity(0, 1),
	[Name] nvarchar(45) collate Latin1_General_100_CI_AS not null,

	constraint PK_dealeat_tCategory primary key(CategoryId),
	constraint CK_tCategory_Name check([Name] in ('Africain','Américain','Burger','Espagnol','Halal','Italien','Méditerranéen','Sandwich','Thaï','Ailes de poulet','Asiatique','Canadien','Fast Food','Hawaïen','Japonais','Mexicain','Pizza','Street Food','Turc','Alcool','Bar Restaurant','Chinois','Français','Healthy','Libanais','Oriental','Poulet','Sushi','Vegan','Desserts','Pain','Glace et yaourt glacé','Indien','Marocain','Pâtes','Salade','Végétarien'))
);
--insert into dealeat.tCategory([Name]) values('CategoryName');