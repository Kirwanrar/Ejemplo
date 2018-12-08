create database Egresados;
use Egresados;

create table escuelas(
idesc int auto_increment,
nombre varchar(20),
cantiCur int,
Direccion varchar(40),
codpost int,
localidad varchar(40),
provincia varchar(40),
borrado boolean not null,
constraint pk_escuela primary key(idesc)
);

create table curso(
idcurso int auto_increment,
nombre varchar(60),
cantiIntegr int,
idesc int,
borrado boolean not null,
cantiLiberados int,
constraint pk_curso primary key(idcurso),
constraint fk_curso_idescul foreign key (idesc) references escuelas(idesc)
);

create table responsables(
idres int auto_increment,
nombre varchar(10),
apellido varchar(10),
dni varchar(10),
direccion varchar(40),
telefono int,
borrado boolean not null,
Acompañante boolean not null,
constraint pk_responsables primary key(idres)
);

create table alumno(
idalum int auto_increment,
nombre varchar(10),
apellido varchar(10),
dni varchar(10),
idcurso int,
idrespon int,
liberado boolean,
estado varchar (20),
borrado boolean not null,
Menuespecial boolean not null,
constraint pk_alumno primary key(idalum),
constraint fk_alumno_idrespon foreign key(idrespon) references responsables(idres),
constraint fk_alumno_idcurso foreign key(idcurso) references curso(idcurso)
);



create table transporte(
idtran int auto_increment,
estado varchar(10),
cantiAs int,
matricula varchar(50),
marca varchar(50),
Descripcion varchar(500),
precio_persona int,
disponible boolean,
borrado boolean not null,
constraint pk_transporte primary key(idtran)
);

create table destino(
iddestino int auto_increment,
nombre varchar(20),
provincia varchar(20),
borrado boolean not null,
constraint pk_destino primary key(iddestino)
);

create table hotel(
idhotel int auto_increment,
nombre varchar(20),
direccion varchar(40),
telefono int,
estrellas int,
iddesti int,
precio_persona int,
borrado boolean not null,
constraint pk_hotel primary key(idhotel),
constraint fk_hotel_iddesti foreign key(iddesti) references destino(iddestino)
);

create table habitacion(
idhab int auto_increment,
tipoCamas varchar(20),
cantiPerson int,
cantiCamas int,
idhotel int,
constraint pk_habitacion primary key(idhab),
constraint fk_habitacion_idhotel foreign key(idhotel) references hotel(idhotel)
);

create table conductor(
idconduc int auto_increment,
nombre varchar(20),
apellido varchar(20),
dni varchar(10),
telefono int,
direccion varchar(50),
borrado boolean not null,
constraint pk_conductor primary key(idconduc) 
);

create table transchofer(
idtranscho int auto_increment,
idtrans int,
idconduc int,
constraint pk_transchofer primary key(idtranscho),
constraint fk_transchofer_idtrans foreign key(idtrans) references transporte(idtran),
constraint fk_transchofer_idconduc foreign key(idconduc) references conductor(idconduc)
);

create table historialmedico(
idhistorial int auto_increment,
idalum int,
gruposangui varchar(50),
enfermedad varchar(50),
operado boolean,
alergias varchar(50),
tratamiento varchar(50),
obrasocial varchar(50),
borrado boolean not null,
constraint pk_historialmedico primary key(idhistorial),
constraint fk_historialmedico_idalum foreign key(idalum) references alumno(idalum)
);

create table excursiones(
idexcur int auto_increment,
lugar varchar(20),
HoraDelDia time,
actividad varchar(30),
iddesti int,
precio_persona int,
borrado boolean not null,
constraint pk_excursiones primary key(idexcur),
constraint fk_excursiones_iddesti foreign key(iddesti) references destino(iddestino)
);

create table cuotas(
idcuotas int auto_increment,
NroCuota int,
fechaPago varchar(20),
estado varchar(20),
idrespon int,
fechaVenci varchar(20),
borrado boolean not null,
constraint pk_cuotas primary key(idcuotas),
constraint fk_cuotas_idrespon foreign key(idrespon) references responsables(idres)
);


create table coordinador(
idcoor int auto_increment,
nombre varchar(10),
apellido varchar(10),
dni varchar(10),
telefono int,
Direccion varchar(30),
borrado boolean not null,
constraint pk_coordinador primary key(idcoor)
);

create table paquete(
idpack int auto_increment,
iddesti int,
idhotel int,
borrado boolean not null,
constraint pk_paquete primary key(idpack),
constraint fk_paquete_iddesti foreign key(iddesti) references destino(iddestino),
constraint fk_paquete_idhotel foreign key(idhotel) references hotel(idhotel)
);

create table paquexcu(
idpaque int auto_increment,
idpack int,
idexc int,
fecha date,
borrado boolean not null,
constraint pk_paquexcu primary key(idpaque),
constraint fk_paquexcu_idpack foreign key(idpack) references paquete(idpack),
constraint fk_paquexcu_idexc foreign key(idexc) references excursiones(idexcur)
);


create table contrato(
idcontra int auto_increment,
idpack int,
montoTotal float,
idcur int,
estado varchar(50),
borrado boolean not null,
constraint pk_contrato primary key(idcontra),
constraint fk_contrato_idpack foreign key (idpack) references paquete(idpack),
constraint fk_contrato_idcur foreign key (idcur) references curso(idcurso)
);


create table viaje (
idviaje int auto_increment,
idcontrato int,
idtranscho int,
duracion varchar(70),
estado varchar(50),
cancelado boolean not null,
constraint pk_viaje primary key(idviaje),
constraint fk_paquete_idtranscho foreign key(idtranscho) references transchofer(idtranscho),
constraint fk_viaje_idcontra foreign key (idcontrato) references contrato(idcontra)
);

create table almanaque(
idalma int auto_increment,
idviaje int,
fechadeinicio date,
fechadellegada date,
disponible boolean,
constraint pk_almanaque primary key(idalma),
constraint fk_almanaque_idviaje foreign key(idviaje) references viaje(idviaje)
);


create table recibo(
idreci int auto_increment,
fecha date,
concepto varchar(50), /*¿por que se esta pagando?*/
monto float,
idrespon int,
idcuota int,
constraint pk_recibo primary key(idreci),
constraint fk_recibo_idrespon foreign key(idrespon) references responsables(idres),
constraint fk_recibo_idcuota foreign key(idcuota) references cuotas(idcuotas)
);


 create table viajeCoor(
 idvc int auto_increment,
 idviaje int,
 idcoor int,
 constraint pk_viajeCoor primary key(idvc),
 constraint fk_viajeCoor_idviaje foreign key(idviaje) references viaje(idviaje),
 constraint fk_viajeCoor_idcoor foreign key(idcoor) references coordinador(idcoor)
 );


create table acompañanteViaje(
idacom int auto_increment,
idrespon int,
idviaje int,
constraint pk_acompañanteviaje primary key(idacom),
constraint fk_acompañanteViaje_idrespon foreign key(idrespon) references responsables(idres),
constraint fk_acompañanteViaje_idviaje foreign key(idviaje) references viaje(idviaje)
);



create table contratofirma(
idcontrafirm int auto_increment,
idcontrato int,
idrespon int,
borrado boolean not null,
constraint pk_contratofirma primary key(idcontrafirm),
constraint fk_contratofirma_idrespon foreign key(idrespon) references responsables(idres),
constraint fk_contratofirma_idcontrato foreign key(idcontrato) references contrato(idcontra)
);

create table ganancias(
idganancia int auto_increment,
mes varchar(30),
año int,
monto float,
constraint pk_ganancias primary key(idganancia)
);

create table usuario(
id int auto_increment,
nombre varchar(40),
contraseña varchar(50),
permiso varchar(40),
constraint pk_usuario primary key(id)
);

insert into usuario values('',"admin123","12345","administrador");
