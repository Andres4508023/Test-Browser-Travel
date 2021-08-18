create database Travel
go

use Travel
go

create table autores(
IdAutor int identity (1,1) primary key,
nombres varchar(45),
Apellidos varchar(45)
)

insert into autores(nombres, Apellidos)
values
('Gabriel', 'Garcia Marquez'),
('German','Castro Caycedo'),
('Rafael','Pombo')


create table Autores_Has_Libros(
IdAutorLibro int identity (1,1) primary key,
Id_Autor int,
Id_Libro int 
)

insert into Autores_Has_Libros(Id_Autor, Id_Libro)
values
(1,1),
(2,2),
(3,3)


create table Libros(
IdLibro int identity(1,1) primary key,
IdEditorial int,
Titulo varchar(45),
Sinopsis varchar(45),
NPaginas varchar(45)
)

insert into Libros(IdEditorial, Titulo, Sinopsis, NPaginas)
values 
(1, 'Cien Años de soledad', 'Drama', '547'),
(2, 'La bruja', 'Terror', '380'),
(3, 'Los mejores cuentos', 'Infantil', '547')

create table Editoriales(
IdEditorial int identity(1,1) primary key,
Nombre varchar(45),
Sede varchar(45)
)

insert into Editoriales(Nombre, Sede)
values
('Oveja negra', 'Bogota'),
('Planeta', 'Cali'),
('Grupo Zeta', 'Bogota')


