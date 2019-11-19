create table dealeat.tCustomer
(
	CustomerId int,

	constraint PK_tCustomer primary key(CustomerId),
	constraint FK_dealeat_tCustomer_tUser foreign key(CustomerId) references dealeat.tUser(UserId)
);