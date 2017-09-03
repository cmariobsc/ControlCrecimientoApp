use master
if not exists(select * from sys.databases where name='DB_CNCAPP')-- solo existen los objetos sys.databases y sys.sysdatabases
create database DB_CNCAPP
go