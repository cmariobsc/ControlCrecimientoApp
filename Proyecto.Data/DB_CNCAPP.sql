use master
if not exists(select * from sys.databases where name='DB_CNCAPP')-- solo existen los objetos sys.databases y sys.sysdatabases
create database DB_CNCAPP
go

use DB_CNCAPP
go

create table Parentesco
(
	IdParentesco			int not null identity(1,1) primary key,
	Descripcion				varchar(50) not null,
)
go

insert into Parentesco values ('Madre')
insert into Parentesco values ('Padre')
insert into Parentesco values ('Abuelo')
insert into Parentesco values ('Abuela')
go

create table Nacionalidad
(
	IdNacionalidad			int not null identity(1,1) primary key,
	Descripcion				varchar(50) not null,
)
go

insert into Nacionalidad values ('Ecuatoriana')
insert into Nacionalidad values ('Colombiana')
insert into Nacionalidad values ('Venezolana')
insert into Nacionalidad values ('Peruana')
go

create table Representante
(
IdRepresentante		int not null primary key,
Identificacion      varchar(10) not null unique,
Nombres			    varchar(100)  not null,
FechaNacimiento     date  not null,
Edad				int  not null,
Direccion			varchar(100)  not null,
Email               varchar(50)  not null,
Telefono1           varchar(10) not null,
Telefono2			varchar(10) null,
Talla		        decimal(2,2) null,
Peso			    int  null,
NHijos			    int  not null,
IdParentesco		int  not null,
IdNacionalidad      int  not null,
foreign key (IdParentesco)references Parentesco,
foreign key (IdNacionalidad) references Nacionalidad,
)
go

create table Children
(
IdChildren		int not null primary key,
Identificacion      varchar(10) null unique,
Nombres			    varchar(100)  not null,
Apellidos			varchar(100)  not null,
FechaNacimiento     date  not null,
Edad				int  not null,
Talla		        decimal(2,2) null,
Peso			    int  null,
IdRepresentante		int  not null,
IdNacionalidad      int  not null,
foreign key (IdRepresentante)references Representante,
foreign key (IdNacionalidad) references Nacionalidad,
)
go

--drop database DB_CNCAPP