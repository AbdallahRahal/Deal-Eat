create table dealeat.tFeedback
(
	FeedbackId int identity(0, 1),
	Note int,
	Feedback nvarchar(255) collate Latin1_General_100_CI_AS not null,
	[Date] date,
	CustomerId  int not null,
	RestaurantId int not null,

	constraint PK_dealeat_tFeedback primary key(FeedbackId),
	constraint FK_dealeat_tFeedback_tRestaurant foreign key(RestaurantId) references dealeat.tRestaurant(RestaurantId),
	constraint FK_dealeat_tFeedback_tCustomer foreign key(CustomerId) references dealeat.tCustomer(CustomerId)
);