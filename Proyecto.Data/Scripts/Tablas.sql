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
insert into Parentesco values ('Tío')
insert into Parentesco values ('Tía')
go

create table Nacionalidad
(
	IdNacionalidad			int not null identity(1,1) primary key,
	Descripcion				varchar(50) not null
)
go

insert into Nacionalidad values ('Ecuatoriana')
insert into Nacionalidad values ('Colombiana')
insert into Nacionalidad values ('Venezolana')
insert into Nacionalidad values ('Peruana')
go

create table Provincia
(
	IdProvincia				int not null identity(1,1) primary key,
	Descripcion				varchar(50) not null
)

insert into Provincia values ('Guayas')
insert into Provincia values ('Pichincha')
go

create table Ciudad
(
	IdCiudad				int not null identity(1,1) primary key,
	Descripcion				varchar(50) not null,
	IdProvincia				int  not null
	foreign key (IdProvincia) references Provincia,
)

insert into Ciudad values ('Guayaquil', 1)
insert into Ciudad values ('Quito', 2)
insert into Ciudad values ('Durán', 1)
insert into Ciudad values ('Milagro', 1)
go

create table Usuario
(
IdUsuario			int not null identity(1,1) primary key,
Usuario				varchar(20) not null,
Contrasenia			binary(64) NOT NULL,
Nombres			    varchar(100)  not null,
Apellidos			varchar(100)  not null,
Email				varchar(50)  not null,
Habilitado			bit not null,
FechaCreacion		date  not null
)

EXEC dbo.SP_RegistrarUsuario 'admin', '123456', 'Carlos Mario', 'Gonzalez Luna', 'cmario1982@hotmail.com';  
GO

create table Representante
(
IdRepresentante		int not null identity(1,1) primary key,
Identificacion      varchar(10) not null unique,
Nombres			    varchar(100)  not null,
Apellidos			varchar(100)  not null,
FechaNacimiento     date  not null,
Edad				int  not null,
Direccion			varchar(100)  not null,
Email               varchar(50)  not null,
Telefono1           varchar(10) not null,
Telefono2			varchar(10) null,
Talla		        decimal(6,2) null,
Peso			    int  null,
NHijos			    int  not null,
FechaCreacion		date  not null,
FechaModificacion	date  not null,
IdUsuario			int  not null,
IdParentesco		int  not null,
IdNacionalidad      int  not null,
IdProvincia			int  not null,
IdCiudad			int  not null,
foreign key (IdUsuario) references Usuario,
foreign key (IdParentesco) references Parentesco,
foreign key (IdNacionalidad) references Nacionalidad,
foreign key (IdProvincia) references Provincia,
foreign key (IdCiudad) references Ciudad
,
)
go

insert into Representante values ('0928133099', 'Carlos', 'Gonzalez', GETDATE(), 27, 'Muey', 'cmario1982@hotmail.com', 
									'0996368611',NULL, 1.75, 65, 1, GETDATE(), GETDATE(), 1, 2, 1, 1, 1)

create table Children
(
IdChildren			int not null identity(1,1) primary key,
Identificacion      varchar(10) null unique,
Nombres			    varchar(100)  not null,
Apellidos			varchar(100)  not null,
FechaNacimiento     date  not null,
Edad				int  not null,
Talla		        decimal(2,2) null,
Peso			    int  null,
FechaCreacion		date  not null,
FechaModificacion	date  not null,
IdRepresentante		int  not null,
IdNacionalidad      int  not null,
foreign key (IdRepresentante) references Representante,
foreign key (IdNacionalidad) references Nacionalidad,
)
go

--drop table Catalogo
--drop table Parentesco
--drop table Nacionalidad
--drop table Provincia
--drop table Ciudad
--drop table Usuario
--drop table Representante
--drop table children

--drop database DB_CNCAPP