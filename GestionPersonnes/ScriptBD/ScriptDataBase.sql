--drop database gestion_personne
--go

create database gestion_personne
go

use gestion_personne
go

create table personne
(
	id int,
	nom varchar(50) not null,
	postnom varchar(50),
	prenom varchar(50),
	sexe varchar(1) default 'M' not null,
	constraint pk_personne primary key(id),
	constraint uk_personne unique(nom,postnom,prenom)
)
go

create table telephone 
(
	id int,
	id_proprietaire int not null,
	initial varchar(4) not null,
	numero varchar(9) not null,
	constraint pk_telephone primary key(id),
	constraint fk_personne_telephone 
	foreign key(id_proprietaire) references personne(id)
)
go

create table adresse
(
	id int,
	quartier varchar(50),
	commune varchar(50),
	ville varchar(50),
	pays varchar(50) not null,
	constraint pk_adresse primary key(id)
)
go

create table domicile
(
	id int,
	id_personne int not null,
	id_adresse int not null,
	avenue varchar(50),
	numero_avenue int,
	constraint pk_domicile primary key(id),
	constraint fk_personne_domicile foreign key(id_personne)
	references personne(id),
	constraint fk_addresse_domicile foreign key(id_adresse)
	references adresse(id)
)
go
