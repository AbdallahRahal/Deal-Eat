create table dealeat.tFeedback
(
	FeedbackId int identity(0, 1),
	Note int collate Latin1_General_100_CI_AS not null,
	Feedback varchar(300) collate Latin1_General_100_CI_AS not null,
	UserId  int not null,
	RestaurantId int not null,

	constraint PK_dealeat_tFeedback primary key(FeedbackId),
	constraint FK_dealeat_tFeedback_tRestaurant foreign key(RestaurantId) references dealeat.tRestaurant(RestaurantId),
	constraint FK_dealeat_tFeedback_tUser foreign key(UserId) references dealeat.tUser(UserId)
);
insert into dealeat.tFeedback(Note, Feedback) values(0, N'N.A.');