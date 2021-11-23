CREATE DATABASE trekkingadventurescr;

USE trekkingadventurescr;

CREATE TABLE TOURS (
	id INTEGER AUTO_INCREMENT NOT NULL,
	nombre VARCHAR(1000) NOT NULL,
	precio DECIMAL NOT NULL,
	descripcion_breve VARCHAR(1000) NOT NULL,
    descripcion_completa VARCHAR(8000) NOT NULL,
    fecha_registro DATETIME NOT NULL,
    tour_destacado BIT NOT NULL,
	CONSTRAINT PK_TOURS PRIMARY KEY (id)
);

SELECT *  FROM TOURS;

INSERT INTO TOURS (nombre, precio, descripcion_breve, descripcion_completa, fecha_registro, tour_destacado)
VALUES ('Tour 1', 500, 'Este es un super tour', 'descripcion completita', NOW(), 1);

INSERT INTO TOURS (nombre, precio, descripcion_breve, descripcion_completa, fecha_registro, tour_destacado)
VALUES ('Tour 2', 400, 'Este es un tour genial', 'descripcion completaza', NOW(), 0);

INSERT INTO TOURS (nombre, precio, descripcion_breve, descripcion_completa, fecha_registro, tour_destacado)
VALUES ('Tour 3', 350, 'Este es un gran tour', 'descripcion completisima', NOW(), 1);

INSERT INTO TOURS (nombre, precio, descripcion_breve, descripcion_completa, fecha_registro, tour_destacado)
VALUES ('Tour 4', 630, 'Este es un buen tour', 'descripcion completilla', NOW(), 1);

INSERT INTO TOURS (nombre, precio, descripcion_breve, descripcion_completa, fecha_registro, tour_destacado)
VALUES ('Tour 5', 510, 'Este es un tour balato', 'descripcion re completa', NOW(), 0);

SELECT @@VERSION