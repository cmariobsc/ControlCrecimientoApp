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
insert into Parentesco values ('T�o')
insert into Parentesco values ('T�a')
go

create table Sexo
(
	IdSexo					int not null identity(1,1) primary key,
	Descripcion				varchar(50) not null,
)

insert into Sexo values ('Masculino')
insert into Sexo values ('Femenino')
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
	Descripcion				varchar(50) not null,
	CodigoArea				varchar(2) not null
)

insert into Provincia values ('Azuay', '07')
insert into Provincia values ('Bol�var', '03')
insert into Provincia values ('Ca�ar', '07')
insert into Provincia values ('Carchi', '06')
insert into Provincia values ('Chimborazo', '03')
insert into Provincia values ('Cotopaxi', '03')
insert into Provincia values ('El Oro', '07')
insert into Provincia values ('Esmeraldas', '06')
insert into Provincia values ('Gal�pagos', '05')
insert into Provincia values ('Guayas', '04')
insert into Provincia values ('Imbabura', '06')
insert into Provincia values ('Loja', '07')
insert into Provincia values ('Los R�os', '05')
insert into Provincia values ('Manab�', '05')
insert into Provincia values ('Morona Santiago', '07')
insert into Provincia values ('Napo', '06')
insert into Provincia values ('Orellana', '06')
insert into Provincia values ('Pastaza', '03')
insert into Provincia values ('Pichincha', '02')
insert into Provincia values ('Santa Elena', '04')
insert into Provincia values ('Santo Domingo', '02')
insert into Provincia values ('Sucumb�os', '06')
insert into Provincia values ('Tungurahua', '03')
insert into Provincia values ('Zamora Chinchipe', '07')
go

create table Ciudad
(
	IdCiudad				int not null identity(1,1) primary key,
	Descripcion				varchar(50) not null,
	IdProvincia				int  not null
	foreign key (IdProvincia) references Provincia,
)

insert into Ciudad values ('Guayaquil', 10)
insert into Ciudad values ('Quito', 19)
insert into Ciudad values ('Dur�n', 10)
insert into Ciudad values ('Milagro', 10)
go

create table Usuario
(
IdUsuario			int				not null primary key,
Usuario				varchar(20)		not null,
Contrasenia			binary(64)		not null,
Nombres			    varchar(100)	not null,
Apellidos			varchar(100)	not null,
Email				varchar(50)		not null,
Habilitado			bit				not null,
FechaCreacion		date			not null
)

create table Representante
(
IdRepresentante		int				not null primary key,
Identificacion      varchar(10)		not null,
Nombres			    varchar(100)	not null,
Apellidos			varchar(100)	not null,
FechaNacimiento     date			null,
Edad				int				null,
Direccion			varchar(100)	null,
Email               varchar(50)		not null,
Telefono1           varchar(10)		null,
Telefono2			varchar(10)		null,
Talla		        decimal(6,2)	null,
Peso			    int				null,
NHijos			    int				null,
FechaCreacion		date			not null,
FechaModificacion	date			not null,
IdUsuario			int				not null,
IdParentesco		int				null,
IdNacionalidad      int				null,
IdProvincia			int				null,
IdCiudad			int				null,
foreign key (IdUsuario) references Usuario,
foreign key (IdParentesco) references Parentesco,
foreign key (IdNacionalidad) references Nacionalidad,
foreign key (IdProvincia) references Provincia,
foreign key (IdCiudad) references Ciudad
,
)
go

create table Children
(
IdChildren			int not null primary key,
Identificacion      varchar(10) null,
Nombres			    varchar(100)  not null,
Apellidos			varchar(100)  not null,
FechaNacimiento     date  not null,
EdadAnios			int  not null,
EdadMeses			int  not null,
EdadTotalMeses		int  not null,
Talla		        decimal(6,2) not null,
Peso			    decimal(6,2) not null,
IMC					decimal(6,2) not null,
DetalleIMC			varchar(100)  not null,
PerimCefalico		decimal(6,2) not null,
PerimMedioBrazo		decimal(6,2) not null,
Observaciones		varchar(100) null,
FechaCreacion		date  not null,
FechaModificacion	date  not null,
IdSexo			    int  not null,
IdRepresentante		int  not null,
IdNacionalidad      int  not null,
foreign key (IdSexo) references Sexo,
foreign key (IdRepresentante) references Representante,
foreign key (IdNacionalidad) references Nacionalidad,
)
go

create table HistorialChildren
(
IdHistorialChildren		int not null identity(1,1) primary key,
EdadAnios				int  not null,
EdadMeses				int  not null,
EdadTotalMeses			int  not null,
Talla					decimal(6,2) not null,
Peso					decimal(6,2) not null,
IMC						decimal(6,2) not null,
DetalleIMC				varchar(100)  not null,
PerimCefalico			decimal(6,2) not null,
PerimMedioBrazo			decimal(6,2) not null,
Observaciones			varchar(100) null,
FechaCreacion			date  not null,
FechaModificacion		date  not null,
IdChildren				int  not null,
foreign key (IdChildren) references Children
)
go

create table OMSTallaxEdadMasculino
(
Meses					int  not null,
L						decimal(10,5) not null,
M						decimal(10,5) not null,
S						decimal(10,5) not null,
SD						decimal(10,5) not null,
SD3neg					decimal(10,5) not null,
SD2neg					decimal(10,5) not null,
SD1neg					decimal(10,5) not null,
SD0						decimal(10,5) not null,
SD1						decimal(10,5) not null,
SD2						decimal(10,5) not null,
SD3						decimal(10,5) not null,
)
go

create table OMSTallaxEdadFemenino
(
Meses					int  not null,
L						decimal(10,5) not null,
M						decimal(10,5) not null,
S						decimal(10,5) not null,
SD						decimal(10,5) not null,
SD3neg					decimal(10,5) not null,
SD2neg					decimal(10,5) not null,
SD1neg					decimal(10,5) not null,
SD0						decimal(10,5) not null,
SD1						decimal(10,5) not null,
SD2						decimal(10,5) not null,
SD3						decimal(10,5) not null,
)
go

create table OMSPesoxEdadMasculino
(
Meses					int  not null,
L						decimal(10,5) not null,
M						decimal(10,5) not null,
S						decimal(10,5) not null,
SD3neg					decimal(10,5) not null,
SD2neg					decimal(10,5) not null,
SD1neg					decimal(10,5) not null,
SD0						decimal(10,5) not null,
SD1						decimal(10,5) not null,
SD2						decimal(10,5) not null,
SD3						decimal(10,5) not null,
)
go

create table OMSPesoxEdadFemenino
(
Meses					int  not null,
L						decimal(10,5) not null,
M						decimal(10,5) not null,
S						decimal(10,5) not null,
SD3neg					decimal(10,5) not null,
SD2neg					decimal(10,5) not null,
SD1neg					decimal(10,5) not null,
SD0						decimal(10,5) not null,
SD1						decimal(10,5) not null,
SD2						decimal(10,5) not null,
SD3						decimal(10,5) not null,
)
go

create table OMSIMCxEdadMasculino
(
Meses					int  not null,
L						decimal(10,5) not null,
M						decimal(10,5) not null,
S						decimal(10,5) not null,
SD3neg					decimal(10,5) not null,
SD2neg					decimal(10,5) not null,
SD1neg					decimal(10,5) not null,
SD0						decimal(10,5) not null,
SD1						decimal(10,5) not null,
SD2						decimal(10,5) not null,
SD3						decimal(10,5) not null,
)
go

create table OMSIMCxEdadFemenino
(
Meses					int  not null,
L						decimal(10,5) not null,
M						decimal(10,5) not null,
S						decimal(10,5) not null,
SD3neg					decimal(10,5) not null,
SD2neg					decimal(10,5) not null,
SD1neg					decimal(10,5) not null,
SD0						decimal(10,5) not null,
SD1						decimal(10,5) not null,
SD2						decimal(10,5) not null,
SD3						decimal(10,5) not null,
)
go

create table OMSPCxEdadMasculino
(
Meses					int  not null,
L						decimal(10,5) not null,
M						decimal(10,5) not null,
S						decimal(10,5) not null,
SD						decimal(10,5) not null,
SD3neg					decimal(10,5) not null,
SD2neg					decimal(10,5) not null,
SD1neg					decimal(10,5) not null,
SD0						decimal(10,5) not null,
SD1						decimal(10,5) not null,
SD2						decimal(10,5) not null,
SD3						decimal(10,5) not null,
)
go

create table OMSPCxEdadFemenino
(
Meses					int  not null,
L						decimal(10,5) not null,
M						decimal(10,5) not null,
S						decimal(10,5) not null,
SD						decimal(10,5) not null,
SD3neg					decimal(10,5) not null,
SD2neg					decimal(10,5) not null,
SD1neg					decimal(10,5) not null,
SD0						decimal(10,5) not null,
SD1						decimal(10,5) not null,
SD2						decimal(10,5) not null,
SD3						decimal(10,5) not null,
)
go

create table OMSPMBxEdadMasculino
(
Meses					int  not null,
L						decimal(10,5) not null,
M						decimal(10,5) not null,
S						decimal(10,5) not null,
SD3neg					decimal(10,5) not null,
SD2neg					decimal(10,5) not null,
SD1neg					decimal(10,5) not null,
SD0						decimal(10,5) not null,
SD1						decimal(10,5) not null,
SD2						decimal(10,5) not null,
SD3						decimal(10,5) not null,
)
go

create table OMSPMBxEdadFemenino
(
Meses					int  not null,
L						decimal(10,5) not null,
M						decimal(10,5) not null,
S						decimal(10,5) not null,
SD3neg					decimal(10,5) not null,
SD2neg					decimal(10,5) not null,
SD1neg					decimal(10,5) not null,
SD0						decimal(10,5) not null,
SD1						decimal(10,5) not null,
SD2						decimal(10,5) not null,
SD3						decimal(10,5) not null,
)
go

create table Doctor
(
IdDoctor				int not null identity(1,1) primary key,
Nombre					varchar(100) null,
Especialidad			varchar(100) null,
LugarTrabajo			varchar(100) null,
IdProvincia				int	null,
IdCiudad				int	null,
DIreccion				varchar(100) null,
Email					varchar(50)	not null
)

insert into Doctor values ('Mario Alberto Proa�o Baca', 'Pediatra', 'Cl�nica San Francisco', 10, 1, 'Cdla Kennedy Norte Av. Andrade Coello y Juan Rolando', 'cmario1982@gmail.com')
insert into Doctor values ('Mildred Alexandra Tamariz Gutierrez', 'Obstetriz', 'Hospital Universitario', 10, 1, 'V�a Perimetral & Calle 24A', 'milyomos2085@gmail.com')
go

--drop table Parentesco
--drop table Sexo
--drop table Nacionalidad
--drop table Provincia
--drop table Ciudad
--drop table Usuario
--drop table Representante
--drop table Children
--drop table HistorialChildren
--drop table OMSTallaxEdadMasculino
--drop table OMSTallaxEdadFemenino
--drop table OMSPesoxEdadMasculino
--drop table OMSPesoxEdadFemenino
--drop table OMSIMCxEdadMasculino
--drop table OMSIMCxEdadFemenino
--drop table OMSPCxEdadMasculino
--drop table OMSPCxEdadFemenino
--drop table OMSPMBxEdadMasculino
--drop table OMSPMBxEdadFemenino


--drop database DB_CNCAPP