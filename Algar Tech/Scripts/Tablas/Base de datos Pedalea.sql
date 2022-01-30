CREATE DATABASE PEDALEA
USE PEDALEA

CREATE TABLE TALLA (
ID_TALLA INT IDENTITY NOT NULL,
TALLA VARCHAR(2) NOT NULL
CONSTRAINT PK_ID_TALLA PRIMARY KEY ([ID_TALLA])
)

CREATE TABLE COLOR (
ID_COLOR INT IDENTITY NOT NULL,
COLOR VARCHAR(20) NOT NULL,
CONSTRAINT PK_ID_COLOR PRIMARY KEY ([ID_COLOR])
)

CREATE TABLE TIPO_DEPARTAMENTO (
ID_TIPO_DEPARTAMENTO INT IDENTITY NOT NULL,
DEPARTAMENTO VARCHAR(50) NOT NULL,
CONSTRAINT PK_ID_TIPO_DEPARTAMENTO PRIMARY KEY ([ID_TIPO_DEPARTAMENTO])
)

CREATE TABLE PRODUCTO (
ID_PRODUCTO INT IDENTITY NOT NULL,
NOMBRE VARCHAR(50) NOT NULL,
PRECIO NUMERIC(18, 2) NOT NULL,
ID_TALLA INT NOT NULL,
ID_COLOR INT NOT NULL,
ID_TIPO_DEPARTAMENTO INT NOT NULL,
CONSTRAINT PK_ID_PRODUCTO PRIMARY KEY ([ID_PRODUCTO]),
CONSTRAINT FK_TALLA FOREIGN KEY (ID_TALLA) REFERENCES TALLA (ID_TALLA),
CONSTRAINT FK_COLOR FOREIGN KEY (ID_COLOR) REFERENCES COLOR (ID_COLOR),
CONSTRAINT FK_TIPO_DEPARTAMENTO FOREIGN KEY (ID_TIPO_DEPARTAMENTO) REFERENCES TIPO_DEPARTAMENTO (ID_TIPO_DEPARTAMENTO)
)

CREATE TABLE PLAN_SEPARE (
ID_PLAN_SEPARE INT IDENTITY NOT NULL,
PLAN_SEPARE VARCHAR(50) NOT NULL,
CONSTRAINT PK_ID_PLAN_SEPARE PRIMARY KEY ([ID_PLAN_SEPARE])
)

CREATE TABLE PROMOCIONES (
ID_PROMOCION INT IDENTITY NOT NULL,
PORCENTAJE NUMERIC(18, 2) NOT NULL,
CONSTRAINT PK_ID_PROMOCION PRIMARY KEY ([ID_PROMOCION])
)

CREATE TABLE CLIENTE (
ID_CLIENTE INT IDENTITY NOT NULL,
CEDULA VARCHAR(20) NOT NULL,
NOMBRE VARCHAR(50) NOT NULL,
DIRECCION VARCHAR(100) NOT NULL,
CONSTRAINT PK_ID_CLIENTE PRIMARY KEY ([ID_CLIENTE])
)

CREATE TABLE COMPRA (
ID_COMPRA INT IDENTITY NOT NULL,
FECHA DATETIME NOT NULL,
VALOR NUMERIC(18, 2) NOT NULL,
ID_PLAN_SEPARE INT NOT NULL,
ID_PROMOCION INT NOT NULL,
ID_CLIENTE INT NOT NULL,
CONSTRAINT PK_ID_COMPRA PRIMARY KEY ([ID_COMPRA]),
CONSTRAINT FK_PLAN_SEPARE FOREIGN KEY (ID_PLAN_SEPARE) REFERENCES PLAN_SEPARE (ID_PLAN_SEPARE),
CONSTRAINT FK_PROMOCION FOREIGN KEY (ID_PROMOCION) REFERENCES PROMOCIONES (ID_PROMOCION),
CONSTRAINT FK_CLIENTE FOREIGN KEY (ID_CLIENTE) REFERENCES CLIENTE (ID_CLIENTE)
)

CREATE TABLE DETALLE_COMPRA (
ID_DETALLE_COMPRA INT IDENTITY NOT NULL,
CANTIDAD INT NOT NULL,
ID_COMPRA INT NOT NULL,
ID_PRODUCTO INT NOT NULL,
CONSTRAINT PK_ID_DETALLE_COMPRA PRIMARY KEY ([ID_DETALLE_COMPRA]),
CONSTRAINT FK_COMPRA FOREIGN KEY (ID_COMPRA) REFERENCES COMPRA (ID_COMPRA),
CONSTRAINT FK_PRODUCTO FOREIGN KEY (ID_PRODUCTO) REFERENCES PRODUCTO (ID_PRODUCTO)
)
