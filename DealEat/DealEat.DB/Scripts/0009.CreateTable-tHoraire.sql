create table dealeat.tHoraire
(
	HoraireId int identity(0, 1),
	[Day] nvarchar(45) collate Latin1_General_100_CI_AS not null,
	OuvertureMatin TIME,
	FermetureMatin TIME,  
	OuvertureAprem TIME,
	FermetureAprem TIME,
	RestaurantId int not null,

	constraint PK_dealeat_tHoraire primary key(HoraireId),
	constraint FK_dealeat_tHoraire_tRestaurant foreign key(RestaurantId) references dealeat.tRestaurant(RestaurantId),
	constraint CK_tCategory_Name check([Name] in ('Lundi','Mardi','Mercredi','Jeudi','Vendredi','Samedi','Dimanche'))
);