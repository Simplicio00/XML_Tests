create database ExperimentoENTERPRISE


go

create table SETOR_ENTERPRISE(
	Id int primary key identity,
	Staff int,
	Status_Setor bit default 1
)

go

use ExperimentoENTERPRISE


go

insert into SETOR_ENTERPRISE(Staff)
	values(12),(15)

go

create table FUNCIONARIO_ENTERPRISE
(
	id int primary key identity,
	Nome varchar(100) not null
)

GO

insert into FUNCIONARIO_ENTERPRISE(Nome)
	values('Josué Pereira'),('Pedro Augusto'),('Marcos Lopes'),('Felipe Gonzaga')