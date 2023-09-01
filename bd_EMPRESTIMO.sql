create database bdEmprestimo1;
use bdEmprestimo1;

create table tbUsuario(
codUsu int primary key auto_increment,
nomeUsu varchar(50)
);

create table tbLivro(
codLivro int primary key auto_increment,
nomeLivro varchar (50),
imagemLivro varchar (255)
);

create table tbEmprestimo(
codEmp int primary key auto_increment,
dataEmp varchar (20),
dataDev varchar (20),
codUsu int references tbUsuario(codUsu)
);

create table itensEmp(
codItem int primary key auto_increment,
codEmp int references tbEmprestimo(codEmp),
codLivro int references tbLivro(codLivro)
);

insert into tbUsuario values (default, 'Beatriz'),(default,'Gabriel');
select * from tbUsuario;

select * from tbLivro;

