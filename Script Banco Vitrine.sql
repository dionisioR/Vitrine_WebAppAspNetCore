create database vitrine_csharp;

use vitrine_csharp;

create table usuarios(
usuarioid int primary key auto_increment,
nome varchar(180),
email varchar(180),
senha text
)engine=innoDb;

create table produtos(
produtoid int primary key auto_increment,
nome varchar(180),
descricao text,
preco decimal(10,2),
ativo tinyint,
usuarioid int not null,
foreign key (usuarioid) references usuarios(usuarioid)
)engine=innoDb;

create table imagens(
imagemid int primary key auto_increment,
nome varchar(180),
produtoid int not null,
foreign key(produtoid) references produtos(produtoid)
)engine = InnoDB;
