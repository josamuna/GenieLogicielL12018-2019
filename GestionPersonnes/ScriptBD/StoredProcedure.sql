--Insert or Update personne
create procedure sp_insert_personne
	@id int,@nom varchar(50),@postnom varchar(50),
	@prenom varchar(50),@sexe varchar(1)
as
begin
	if not exists(select * from personne where id=@id)
		insert into personne(id,nom,postnom,prenom,sexe) values 
		(@id,@nom,@postnom,@prenom,@sexe)
	else
		update personne set nom=@nom,postnom=@postnom,prenom=@prenom,
		sexe=@sexe where id=@id
end
go

--Delete personne
create procedure sp_delete_personne
	@id int
as
begin
	if exists(select * from personne where id=@id)
		delete from personne where id=@id
end
go

--Select all personne
create procedure sp_select_personnes
as
begin 
	select id,nom,postnom,prenom,sexe from personne order by nom asc
end
go

--Select one personne
create procedure sp_select_personne
	@id int
as
begin
	select id,nom,postnom,prenom,sexe from personne 
	where id=@id
end
go

--Insert or Update telephone
create procedure sp_insert_telephone
	@id int,@id_proprietaire int,@initial varchar(4),
	@numero varchar(9)
as
begin
	if not exists(select * from telephone where id=@id)
		insert into telephone(id,id_proprietaire,initial,numero) values 
		(@id,@id_proprietaire,@initial,@numero)
	else
		update telephone set id_proprietaire=@id_proprietaire,
		initial=@initial,numero=@numero where id=@id
end
go

--Delete telephone
create procedure sp_delete_telephone
	@id int
as
begin
	if exists(select * from telephone where id=@id)
		delete from telephone where id=@id
end
go

--Select all telephone
create procedure sp_select_telephones
as
begin
	select id,id_proprietaire,initial,numero from telephone order by numero asc
end
go

--Select all telephone of personne
create procedure sp_select_telephones_personne
	@id_personne int	
as
begin
	select id,id_proprietaire,initial,numero
	from telephone where id_proprietaire=@id_personne
	order by numero asc
end
go

--Select one telephone
create procedure sp_select_telephone
	@id int
as
begin
	select id,id_proprietaire,initial,numero from telephone
	where id=@id
end
go

--Stored Procedure for report of persons
create procedure sp_liste_personnes
as
begin
	select personne.id,personne.nom + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') as nom,
	personne.sexe,telephone.id as idtel,telephone.initial + telephone.numero as numero
	from personne
	left outer join telephone 
	on personne.id=telephone.id_proprietaire
end
go

--Test Insert and Update
exec sp_insert_personne 1,'Isamuna','Nkembo','Josue','M'
exec sp_insert_personne 2,'Mataba','Kyole','Stephanie','F'
exec sp_insert_personne 3,'Arakandi','sefu','Eva','M'
select * from personne

exec sp_insert_telephone 1,1,'+250','785623146'
exec sp_insert_telephone 2,1,'+243','850001263'
exec sp_insert_telephone 3,2,'+243','985645235'
exec sp_insert_telephone 4,3,'+243','815790584'
exec sp_insert_telephone 5,3,'+242','808256231'
select * from telephone

--Test delete
--exec sp_delete_telephone 1
--select * from telephone

--exec sp_delete_personne 3
--select * from personne

--Test Select all
exec sp_select_personnes

exec sp_select_telephones

--Test Select One
exec sp_select_personne 3

exec sp_select_telephone 4

exec sp_select_telephones_personne 2

--Test Select report
exec sp_liste_personnes

