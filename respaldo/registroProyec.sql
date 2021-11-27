-- ----------------------------
-- Estructura de tabla autor
-- ----------------------------
DROP TABLE IF EXISTS `autor`;
CREATE TABLE `autor` (
  `IdAutor` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Estado` tinyint DEFAULT '1',
  PRIMARY KEY (`IdAutor`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb3;

-- ----------------------------
-- Registro de autor
-- ----------------------------
INSERT INTO `autor` VALUES ('1', 'Luciano', '1');
INSERT INTO `autor` VALUES ('2', 'Rudyard Kipling', '1');
INSERT INTO `autor` VALUES ('3', 'Charlotte Perkins Gilman', '1');
INSERT INTO `autor` VALUES ('4', 'Julio Verne', '1');
INSERT INTO `autor` VALUES ('5', 'Apolonio De Rodas', '1');
INSERT INTO `autor` VALUES ('6', 'Emilio Salgari', '1');
INSERT INTO `autor` VALUES ('7', 'Jack London', '1');
INSERT INTO `autor` VALUES ('8', 'H.P. Lovecraft', '1');
INSERT INTO `autor` VALUES ('9', 'Ken Follet', '1');
INSERT INTO `autor` VALUES ('10', 'Miguel De Cervantes', '1');
INSERT INTO `autor` VALUES ('11', 'George R. R. Martin', '1');
INSERT INTO `autor` VALUES ('12', 'Jon Bilbao', '1');
INSERT INTO `autor` VALUES ('13', 'Percival Christopher Wren', '1');
INSERT INTO `autor` VALUES ('14', 'John Boyne', '1');
INSERT INTO `autor` VALUES ('15', 'Herman Melville', '1');
INSERT INTO `autor` VALUES ('16', 'Edebé', '1');
INSERT INTO `autor` VALUES ('17', 'Gabriel García Márquez', '1');

-- ----------------------------
-- Estructura de tabla categoria
-- ----------------------------
DROP TABLE IF EXISTS `categoria`;
CREATE TABLE `categoria` (
  `IdCategoria` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Estado` tinyint DEFAULT '1',
  PRIMARY KEY (`IdCategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;

-- ----------------------------
-- Registro de categoria
-- ----------------------------
INSERT INTO `categoria` VALUES ('1', 'Aventuras', '1');
INSERT INTO `categoria` VALUES ('2', 'Ciencia Ficción', '1');
INSERT INTO `categoria` VALUES ('3', 'Policíaca', '1');
INSERT INTO `categoria` VALUES ('4', 'Terror y Misterio', '1');
INSERT INTO `categoria` VALUES ('5', 'Romántica', '1');
INSERT INTO `categoria` VALUES ('6', 'Humor', '1');
INSERT INTO `categoria` VALUES ('7', 'Poesía', '1');
INSERT INTO `categoria` VALUES ('8', 'Mitología', '1');
INSERT INTO `categoria` VALUES ('9', 'Teatro', '1');
INSERT INTO `categoria` VALUES ('10', 'Cuento', '1');

-- ----------------------------
-- Estructura de tabla compra
-- ----------------------------
DROP TABLE IF EXISTS `compra`;
CREATE TABLE `compra` (
  `IdCompra` int NOT NULL,
  `IdLibro` int NOT NULL,
  `Fecha` date NOT NULL,
  `Cantidad` int NOT NULL,
  `Total` int NOT NULL,
  `IdEmpleado` int NOT NULL,
  `Folio` varchar(30) NOT NULL,
  PRIMARY KEY (`IdCompra`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Registro de compra
-- ----------------------------

-- ----------------------------
-- Estructura de tabla editorial
-- ----------------------------
DROP TABLE IF EXISTS `editorial`;
CREATE TABLE `editorial` (
  `IdEditorial` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Estado` tinyint DEFAULT '1',
  PRIMARY KEY (`IdEditorial`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb3;

-- ----------------------------
-- Registro de editorial
-- ----------------------------
INSERT INTO `editorial` VALUES ('1', 'Alianza Editorial', '1');
INSERT INTO `editorial` VALUES ('2', 'Nordica Libros S.L', '1');
INSERT INTO `editorial` VALUES ('3', 'Guillermo Escolar Editor', '1');
INSERT INTO `editorial` VALUES ('4', 'Alfaguara', '1');
INSERT INTO `editorial` VALUES ('5', 'Ediciones Cátedra', '1');
INSERT INTO `editorial` VALUES ('6', 'Penguin Clasicos', '1');
INSERT INTO `editorial` VALUES ('7', 'Planeta', '1');
INSERT INTO `editorial` VALUES ('8', 'Austral', '1');
INSERT INTO `editorial` VALUES ('9', 'Debolsillo', '1');
INSERT INTO `editorial` VALUES ('10', 'Impedimenta Editorial S.L', '1');
INSERT INTO `editorial` VALUES ('11', 'Valdemar', '1');
INSERT INTO `editorial` VALUES ('12', 'Anaya Infantil Y Juvenil', '1');
INSERT INTO `editorial` VALUES ('13', 'Salamandra', '1');

-- ----------------------------
-- Estructura de tabla entradaproduc
-- ----------------------------
DROP TABLE IF EXISTS `entradaproduc`;
CREATE TABLE `entradaproduc` (
  `IdProd` int NOT NULL,
  `Fecha` date NOT NULL,
  `IdLibro` int NOT NULL,
  `Cantidad` int NOT NULL,
  PRIMARY KEY (`IdProd`),
  KEY `entrada_libro` (`IdLibro`),
  CONSTRAINT `entrada_libro` FOREIGN KEY (`IdLibro`) REFERENCES `libro` (`IdLibro`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Registro de entradaproduc
-- ----------------------------
INSERT INTO `entradaproduc` VALUES ('1', '2021-01-26', '1', '5');
INSERT INTO `entradaproduc` VALUES ('2', '2021-02-14', '2', '7');
INSERT INTO `entradaproduc` VALUES ('3', '2021-02-18', '3', '8');
INSERT INTO `entradaproduc` VALUES ('4', '2021-03-01', '4', '9');
INSERT INTO `entradaproduc` VALUES ('5', '2021-03-15', '5', '8');
INSERT INTO `entradaproduc` VALUES ('6', '2021-03-26', '6', '4');
INSERT INTO `entradaproduc` VALUES ('7', '2021-03-30', '7', '2');
INSERT INTO `entradaproduc` VALUES ('8', '2021-04-15', '8', '7');
INSERT INTO `entradaproduc` VALUES ('9', '2021-04-18', '9', '10');
INSERT INTO `entradaproduc` VALUES ('10', '2021-04-18', '10', '5');
INSERT INTO `entradaproduc` VALUES ('11', '2021-05-16', '11', '5');
INSERT INTO `entradaproduc` VALUES ('12', '2021-05-18', '12', '15');
INSERT INTO `entradaproduc` VALUES ('13', '2021-06-19', '13', '8');
INSERT INTO `entradaproduc` VALUES ('14', '2021-06-26', '14', '7');
INSERT INTO `entradaproduc` VALUES ('15', '2021-07-22', '15', '4');
INSERT INTO `entradaproduc` VALUES ('16', '2021-07-26', '16', '8');
INSERT INTO `entradaproduc` VALUES ('17', '2021-08-15', '17', '7');
INSERT INTO `entradaproduc` VALUES ('18', '2021-08-18', '18', '9');
INSERT INTO `entradaproduc` VALUES ('19', '2021-09-05', '19', '2');
INSERT INTO `entradaproduc` VALUES ('20', '2021-09-25', '20', '4');

-- ----------------------------
-- Estructura de tabla libro
-- ----------------------------
DROP TABLE IF EXISTS `libro`;
CREATE TABLE `libro` (
  `IdLibro` int NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Imagen` longblob,
  `IdAutor` int NOT NULL,
  `IdCategoria` int NOT NULL,
  `IdEditorial` int NOT NULL,
  `Ubicacion` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Ejemplares` int NOT NULL,
  `Estado` tinyint DEFAULT '1',
  `FechaPublicacion` date DEFAULT NULL,
  `Costo` decimal(9,2) NOT NULL,
  `Precio` decimal(9,2) GENERATED ALWAYS AS (Costo*1.16) STORED,
  PRIMARY KEY (`IdLibro`),
  KEY `libro_Autor` (`IdAutor`),
  KEY `libro_Categoria` (`IdCategoria`),
  KEY `libro_Editorial` (`IdEditorial`),
  CONSTRAINT `libro_Autor` FOREIGN KEY (`IdAutor`) REFERENCES `autor` (`IdAutor`),
  CONSTRAINT `libro_Categoria` FOREIGN KEY (`IdCategoria`) REFERENCES `categoria` (`IdCategoria`),
  CONSTRAINT `libro_Editorial` FOREIGN KEY (`IdEditorial`) REFERENCES `editorial` (`IdEditorial`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb3;

-- ----------------------------
-- Registro de libro
-- ----------------------------
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('1', 'Relatos fantasticos', null, '1', '4', '1', null, '1', '1', '2017-01-26', '266.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('2', 'El Hombre Que Pudo Reinar', null, '2', '6', '2', null, '1', '1', '2016-02-08', '435.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('3', 'El país de las mujeres', null, '3', '8', '3', null, '1', '1', '2019-02-14', '357.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('4', 'Veinte mil leguas de viaje submarino', null, '4', '3', '4', null, '2', '1', '2021-09-22', '401.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('5', 'Las argonáuticas', null, '5', '6', '5', null, '2', '1', '2003-06-09', '242.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('6', 'El corsario negro', null, '6', '7', '5', null, '2', '1', '2021-04-29', '380.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('7', 'Kim', null, '2', '7', '6', null, '2', '1', '2015-11-19', '222.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('8', 'De la Tierra a la Luna', null, '4', '2', '7', null, '2', '1', '2019-09-19', '267.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('9', 'Relatos de los Mares del Sur', null, '7', '6', '1', null, '2', '1', '2008-08-07', '230.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('10', 'En las montañas de la locura', null, '8', '6', '8', null, '2', '1', '2021-02-03', '267.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('11', 'Los pilares de la Tierra', null, '9', '8', '9', null, '2', '1', '2021-01-07', '289.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('12', 'Don Quijote de la Mancha', null, '10', '5', '4', null, '2', '1', '2021-10-01', '315.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('13', 'Juego de tronos', null, '11', '8', '7', null, '2', '1', '2019-10-15', '334.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('14', 'La vuelta al mundo en 80 días', null, '4', '3', '6', null, '2', '1', '2017-05-01', '273.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('15', 'Basilisco', null, '12', '5', '10', null, '2', '1', '2020-03-30', '465.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('16', 'El misterio del Agua Azul', null, '13', '3', '11', null, '2', '1', '2007-02-01', '328.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('17', 'Los tigres de Mompracem', null, '6', '3', '12', null, '2', '1', '2011-09-19', '266.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('18', 'El motín de la Bounty', null, '14', '2', '13', null, '2', '1', '2008-09-08', '1200.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('19', 'Miguel Strogoff', null, '4', '6', '12', null, '2', '1', '2004-10-25', '266.00');
INSERT INTO `libro` (IdLibro,Titulo,Imagen,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaPublicacion,Costo) VALUES ('20', 'Moby Dick', null, '15', '6', '6', null, '2', '1', '2020-12-10', '245.00');

-- ----------------------------
-- Estructura de tabla nivel_user
-- ----------------------------
DROP TABLE IF EXISTS `nivel_user`;
CREATE TABLE `nivel_user` (
  `IdNivelUser` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`IdNivelUser`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;

-- ----------------------------
-- Registro de nivel_user
-- ----------------------------
INSERT INTO `nivel_user` VALUES ('1', 'Gerente');
INSERT INTO `nivel_user` VALUES ('2', 'Administrador');
INSERT INTO `nivel_user` VALUES ('3', 'Empleado');

-- ----------------------------
-- Estructura de tabla persona
-- ----------------------------
DROP TABLE IF EXISTS `persona`;
CREATE TABLE `persona` (
  `IdPersona` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Apellido` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Direccion` varchar(50) DEFAULT NULL,
  `Telefono` varchar(10) DEFAULT NULL,
  `Correo` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Usuario` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Password` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `IdNivel` int NOT NULL,
  `Estado` tinyint DEFAULT '1',
  PRIMARY KEY (`IdPersona`),
  KEY `persona_nivel` (`IdNivel`),
  CONSTRAINT `persona_nivel` FOREIGN KEY (`IdNivel`) REFERENCES `nivel_user` (`IdNivelUser`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;

-- ----------------------------
-- Registro de persona
-- ----------------------------
INSERT INTO `persona` VALUES ('1', 'Miguel', 'Sixtega Escribano', 'calle Neptuno #5', '2292111111', 'migna0519@gmail.com', 'mignafix', '12345', '1', '1');
INSERT INTO `persona` VALUES ('2', 'Eduardo', 'Marquez', 'calle Verta #13', '2292222222', 'eduardo22@gmail.com', 'eduardo', '11223', '1', '1');
INSERT INTO `persona` VALUES ('3', 'Randy', 'Olivares', 'calle Norte #25', '2291451227', 'radny@gmail.com', 'randy-oliv25', '147852', '2', '1');
INSERT INTO `persona` VALUES ('4', 'Monserrat', 'Peña', 'calle sur #15', '2291451233', 'monse@gmail.com', 'monse-15', '447722', '2', '1');
INSERT INTO `persona` VALUES ('5', 'David', 'Valenzuela', 'calle Oeste #30', '2291451219', 'daved@gmail.com', 'daved-val30', '154421', '2', '1');
INSERT INTO `persona` VALUES ('6', 'Pedro', 'Flores', 'calle Poniente #11', '2291451201', 'pedro@gmail.com', 'pedro-flo11', '223311', '3', '1');
INSERT INTO `persona` VALUES ('7', 'Claudia', 'Mendez', 'calle Delfin #55', '2291451244', 'claudia@gmail.com', 'claudia-men55', '477852', '3', '1');
INSERT INTO `persona` VALUES ('8', 'Marilu', 'Hernadez', 'calle Tiburon #125', '2291451472', 'marilu@gmail.com', 'mari-her125', '771144', '3', '1');
INSERT INTO `persona` VALUES ('9', 'Adriana', 'Lopez', 'calle Leon #77', '2291451374', 'adri@gmail.com', 'adriana-lop77', '227799', '3', '1');
INSERT INTO `persona` VALUES ('10', 'Julio', 'Sanchez', 'calle Acuario #22', '2291451348', 'julio@gmail.com', 'julio-san22', '785247', '3', '1');

-- ----------------------------
-- Estructura de tabla precompra
-- ----------------------------
DROP TABLE IF EXISTS `precompra`;
CREATE TABLE `precompra` (
  `IdPre` int NOT NULL,
  `IdLibro` int NOT NULL,
  `Precio` int NOT NULL,
  `IdEmpleado` int NOT NULL,
  `Estado` tinyint DEFAULT '1',
  PRIMARY KEY (`IdPre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Registro de precompra
-- ----------------------------

-- ----------------------------
-- Estructura de tabla proveedor
-- ----------------------------
DROP TABLE IF EXISTS `proveedor`;
CREATE TABLE `proveedor` (
  `IdProv` int NOT NULL,
  `IdEditorial` int NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `Telefono` varchar(10) NOT NULL,
  `Direccion` varchar(50) DEFAULT NULL,
  `Correo` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`IdProv`),
  KEY `proveedor_editorial` (`IdEditorial`),
  CONSTRAINT `proveedor_editorial` FOREIGN KEY (`IdEditorial`) REFERENCES `editorial` (`IdEditorial`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Registro de proveedor
-- ----------------------------
INSERT INTO `proveedor` VALUES ('1', '13', 'Rafael Gonzalez', '2293024589', 'calle Laguna #11', 'rafael@gmail.com');
INSERT INTO `proveedor` VALUES ('2', '12', 'ALberto Beltran', '2293026598', 'calle Pinos#22', 'alberto@gmail.com');
INSERT INTO `proveedor` VALUES ('3', '11', 'Miguel Cobos', '2293011589', 'calle Perez #77', 'miguel@gmail.com');
INSERT INTO `proveedor` VALUES ('4', '10', 'Octavio Figueroa', '2222554489', 'calle Santos #72', 'octavio@gmail.com');
INSERT INTO `proveedor` VALUES ('5', '9', 'Leonel Hernández', '2297826589', 'calle Bolivar #254', 'leone@gmail.com');
INSERT INTO `proveedor` VALUES ('6', '8', 'Jualia Perez', '2293026522', 'calle Pascal #5', 'julian@gmail.com');
INSERT INTO `proveedor` VALUES ('7', '7', 'Maria Hernández', '2293011589', 'calle Reyes', 'maria@gmail.com');
INSERT INTO `proveedor` VALUES ('8', '6', 'Araminta Márquez', '2294326589', 'calle Mar', 'araminta@gmail.com');
INSERT INTO `proveedor` VALUES ('9', '5', 'Judith Herrera', '2293011560', 'calle Pez #188', 'judith@gmail.com');
INSERT INTO `proveedor` VALUES ('10', '4', 'Montse Alcaraz', '2293026561', 'calle Agustin #88', 'monse@gmail.com');
INSERT INTO `proveedor` VALUES ('11', '3', 'Maria Ramirez', '2294326562', 'calle Camacho #55', 'maria@gmail.com');
INSERT INTO `proveedor` VALUES ('12', '2', 'Pamela Herrera', '2228026563', 'calle Bacalao #01', 'pamela@gmail.com');
INSERT INTO `proveedor` VALUES ('13', '1', 'Helena Hernández', '2283026564', 'calle Tierra #04', 'helena@gmail.com');

-- ----------------------------
-- View structure for verautor
-- ----------------------------
DROP VIEW IF EXISTS `verautor`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `verautor` AS select `autor`.`IdAutor` AS `IdAutor`,`autor`.`Nombre` AS `Nombre`,(case when (`autor`.`Estado` = 1) then 'Activo' else 'Inactivo' end) AS `Estado` from `autor` ;

-- ----------------------------
-- View structure for vercategoria
-- ----------------------------
DROP VIEW IF EXISTS `vercategoria`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vercategoria` AS select `categoria`.`IdCategoria` AS `IdCategoria`,`categoria`.`Nombre` AS `Nombre`,(case when (`categoria`.`Estado` = 1) then 'Activo' else 'Inactivo' end) AS `Estado` from `categoria` ;

-- ----------------------------
-- View structure for vereditorial
-- ----------------------------
DROP VIEW IF EXISTS `vereditorial`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vereditorial` AS select `editorial`.`IdEditorial` AS `IdEditorial`,`editorial`.`Nombre` AS `Nombre`,(case when (`editorial`.`Estado` = 1) then 'Activo' else 'Inactivo' end) AS `Estado` from `editorial` ;

-- ----------------------------
-- View structure for verentrada
-- ----------------------------
DROP VIEW IF EXISTS `verentrada`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `verentrada` AS select `entradaproduc`.`IdProd` AS `IdProd`,`entradaproduc`.`Fecha` AS `Fecha`,`libro`.`Titulo` AS `Titulo`,`entradaproduc`.`Cantidad` AS `Cantidad` from (`entradaproduc` join `libro` on((`entradaproduc`.`IdLibro` = `libro`.`IdLibro`))) ;

-- ----------------------------
-- View structure for verlibro
-- ----------------------------
DROP VIEW IF EXISTS `verlibro`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `verlibro` AS select `libro`.`IdLibro` AS `IdLibro`,`libro`.`Titulo` AS `Titulo`,`autor`.`Nombre` AS `Autor`,`categoria`.`Nombre` AS `Categoria`,`editorial`.`Nombre` AS `Editorial`,`libro`.`Ubicacion` AS `Ubicacion`,`libro`.`Ejemplares` AS `Ejemplares`,(case when (`libro`.`Estado` = 1) then 'Activo' else 'Inactivo' end) AS `Estado`,`libro`.`FechaPublicacion` AS `FechaPublicacion`,`libro`.`Costo` AS `Costo`,`libro`.`Precio` AS `Precio` from (((`libro` join `autor` on((`autor`.`IdAutor` = `libro`.`IdAutor`))) join `categoria` on((`categoria`.`IdCategoria` = `libro`.`IdCategoria`))) join `editorial` on((`editorial`.`IdEditorial` = `libro`.`IdEditorial`))) order by `libro`.`IdLibro` ;

-- ----------------------------
-- View structure for verpersona
-- ----------------------------
DROP VIEW IF EXISTS `verpersona`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `verpersona` AS select `persona`.`IdPersona` AS `IdPersona`,`persona`.`Nombre` AS `Nombre`,`persona`.`Apellido` AS `Apellido`,`persona`.`Direccion` AS `Direccion`,`persona`.`Telefono` AS `Telefono`,`persona`.`Correo` AS `Correo`,`persona`.`Usuario` AS `Usuario`,`nivel_user`.`Nombre` AS `Nivel`,(case when (`persona`.`Estado` = 1) then 'Activo' else 'Inactivo' end) AS `Estado` from (`persona` join `nivel_user` on((`persona`.`IdNivel` = `nivel_user`.`IdNivelUser`))) order by `persona`.`IdPersona` ;

-- ----------------------------
-- View structure for verprecompra
-- ----------------------------
DROP VIEW IF EXISTS `verprecompra`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `verprecompra` AS select `precompra`.`IdPre` AS `IdPre`,`libro`.`Titulo` AS `Titulo`,`precompra`.`Precio` AS `Precio`,`persona`.`Nombre` AS `Nombre`,(case when (`precompra`.`Estado` = 1) then 'Activo' else 'Inactivo' end) AS `Estado` from ((`precompra` join `libro`) join `persona`) ;
