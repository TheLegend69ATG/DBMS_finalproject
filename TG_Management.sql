use Laboratory
go
create or alter trigger tg_CheckInsertandUpdateMem
on MemberInfo for insert, update
as
begin
	if ((select count(Name) from MemberInfo where Name=(select Name from inserted))>1) 
	begin
		raiserror('The name adready existed!', 16, 1)
		rollback
	end
	if ((select count(Email) from MemberInfo where Email= (select Email from inserted))>1) 
	begin
		raiserror('The e-mail adready existed!', 16, 1)
		rollback
	end
	if ((select count(Phone) from MemberInfo where Phone=(select Phone from inserted))>1) 
	begin
		raiserror('The phone number adready existed!', 16, 1)
		rollback
	end
	if ((select Email from inserted) not like '%@gmail.com') 
	begin
		raiserror('Wrong e-mail format!', 16, 1)
		rollback
	end
	if ((select Phone from inserted) not like '+84_________') 
	begin
		raiserror('Wrong phone number format!', 16, 1)
		rollback
	end
end
go
create or alter trigger tg_CheckUpdatePass
on LoginInfo for update
as
begin
	declare @pass varchar(20)=(select Password from inserted)
	if(len(@pass)<8) 
	begin
		raiserror('The password must be longer than 8 characters!', 16, 1)
	end
end
go