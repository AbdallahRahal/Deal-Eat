create table dealeat.tRestaurant_Bracket
(
	Restaurant_BracketId int identity(0, 1),
	RestaurantId int not null,
	BracketId int not null,

	constraint PK_dealeat_tRestaurant_Bracket primary key(Restaurant_BracketId),
	constraint FK_dealeat_tRestaurant_Bracket_tRestaurant foreign key(RestaurantId) references dealeat.tRestaurant(RestaurantId),
	constraint FK_dealeat_tRestaurant_Bracket_tBracket foreign key(BracketId) references dealeat.tBracket(BracketId)
);
--insert into dealeat.tRestaurant_Bracket(RestaurantId, BracketId) values(0, 0);