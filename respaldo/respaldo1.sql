CREATE DATABASE  IF NOT EXISTS `proyecto` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `proyecto`;
-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: localhost    Database: proyecto
-- ------------------------------------------------------
-- Server version	8.0.26

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `autor`
--

DROP TABLE IF EXISTS `autor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `autor` (
  `IdAutor` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Estado` tinyint DEFAULT '1',
  PRIMARY KEY (`IdAutor`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `autor`
--

LOCK TABLES `autor` WRITE;
/*!40000 ALTER TABLE `autor` DISABLE KEYS */;
INSERT INTO `autor` VALUES (1,'Luciano',1),(2,'Rudyard Kipling',1),(3,'Charlotte Perkins Gilman',1),(4,'Julio Verne',1),(5,'Apolonio De Rodas',1),(6,'Emilio Salgari',1),(7,'Jack London',1),(8,'H.P. Lovecraft',1),(9,'Ken Follet',1),(10,'Miguel De Cervantes',1),(11,'George R. R. Martin',1),(12,'Jon Bilbao',1),(13,'Percival Christopher Wren',1),(14,'John Boyne',1),(15,'Herman Melville',1),(16,'Edebé',1),(17,'Gabriel García Márquez',1);
/*!40000 ALTER TABLE `autor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categoria` (
  `IdCategoria` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Estado` tinyint DEFAULT '1',
  PRIMARY KEY (`IdCategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (1,'Aventuras',1),(2,'Ciencia Ficción',1),(3,'Policíaca',1),(4,'Terror y Misterio',1),(5,'Romántica',1),(6,'Humor',1),(7,'Poesía',1),(8,'Mitología',1),(9,'Teatro',1),(10,'Cuento',1),(11,'Terror',1);
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `compra`
--

DROP TABLE IF EXISTS `compra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compra`
--

LOCK TABLES `compra` WRITE;
/*!40000 ALTER TABLE `compra` DISABLE KEYS */;
/*!40000 ALTER TABLE `compra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `editorial`
--

DROP TABLE IF EXISTS `editorial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `editorial` (
  `IdEditorial` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Estado` tinyint DEFAULT '1',
  PRIMARY KEY (`IdEditorial`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `editorial`
--

LOCK TABLES `editorial` WRITE;
/*!40000 ALTER TABLE `editorial` DISABLE KEYS */;
INSERT INTO `editorial` VALUES (1,'Alianza Editorial',1),(2,'Nordica Libros S.L',1),(3,'Guillermo Escolar Editor',1),(4,'Alfaguara',1),(5,'Ediciones Cátedra',1),(6,'Penguin Clasicos',1),(7,'Planeta',1),(8,'Austral',1),(9,'Debolsillo',1),(10,'Impedimenta Editorial S.L',1),(11,'Valdemar',1),(12,'Anaya Infantil Y Juvenil',1),(13,'Salamandra',1),(14,'México',1);
/*!40000 ALTER TABLE `editorial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entradaproduc`
--

DROP TABLE IF EXISTS `entradaproduc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `entradaproduc` (
  `IdProd` int NOT NULL,
  `Fecha` date NOT NULL,
  `IdLibro` int NOT NULL,
  `Cantidad` int NOT NULL,
  PRIMARY KEY (`IdProd`),
  KEY `entrada_libro` (`IdLibro`),
  CONSTRAINT `entrada_libro` FOREIGN KEY (`IdLibro`) REFERENCES `libro` (`IdLibro`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entradaproduc`
--

LOCK TABLES `entradaproduc` WRITE;
/*!40000 ALTER TABLE `entradaproduc` DISABLE KEYS */;
INSERT INTO `entradaproduc` VALUES (1,'2021-01-26',1,5),(2,'2021-02-14',2,7),(3,'2021-02-18',3,8),(4,'2021-03-01',4,9),(5,'2021-03-15',5,8),(6,'2021-03-26',6,4),(7,'2021-03-30',7,2),(8,'2021-04-15',8,7),(9,'2021-04-18',9,10),(10,'2021-04-18',10,5),(11,'2021-05-16',11,5),(12,'2021-05-18',12,15),(13,'2021-06-19',13,8),(14,'2021-06-26',14,7),(15,'2021-07-22',15,4),(16,'2021-07-26',16,8),(17,'2021-08-15',17,7),(18,'2021-08-18',18,9),(19,'2021-09-05',19,2),(20,'2021-09-25',20,4);
/*!40000 ALTER TABLE `entradaproduc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `libro`
--

DROP TABLE IF EXISTS `libro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
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
  `Precio` decimal(9,2) GENERATED ALWAYS AS ((`Costo` * 1.16)) STORED,
  PRIMARY KEY (`IdLibro`),
  KEY `libro_Autor` (`IdAutor`),
  KEY `libro_Categoria` (`IdCategoria`),
  KEY `libro_Editorial` (`IdEditorial`),
  CONSTRAINT `libro_Autor` FOREIGN KEY (`IdAutor`) REFERENCES `autor` (`IdAutor`),
  CONSTRAINT `libro_Categoria` FOREIGN KEY (`IdCategoria`) REFERENCES `categoria` (`IdCategoria`),
  CONSTRAINT `libro_Editorial` FOREIGN KEY (`IdEditorial`) REFERENCES `editorial` (`IdEditorial`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `libro`
--

LOCK TABLES `libro` WRITE;
/*!40000 ALTER TABLE `libro` DISABLE KEYS */;
INSERT INTO `libro` (`IdLibro`, `Titulo`, `Imagen`, `IdAutor`, `IdCategoria`, `IdEditorial`, `Ubicacion`, `Ejemplares`, `Estado`, `FechaPublicacion`, `Costo`) VALUES (1,'Relatos fantasticos',NULL,1,4,1,NULL,1,1,'2017-01-26',266.00),(2,'El Hombre Que Pudo Reinar',NULL,2,6,2,NULL,1,1,'2016-02-08',435.00),(3,'El país de las mujeres',NULL,3,8,3,NULL,1,1,'2019-02-14',357.00),(4,'Veinte mil leguas de viaje submarino',NULL,4,3,4,NULL,2,1,'2021-09-22',401.00),(5,'Las argonáuticas',NULL,5,6,5,NULL,2,1,'2003-06-09',242.00),(6,'El corsario negro',NULL,6,7,5,NULL,2,1,'2021-04-29',380.00),(7,'Kim',NULL,2,7,6,NULL,2,1,'2015-11-19',222.00),(8,'De la Tierra a la Luna',NULL,4,2,7,NULL,2,1,'2019-09-19',267.00),(9,'Relatos de los Mares del Sur',NULL,7,6,1,NULL,2,1,'2008-08-07',230.00),(10,'En las montañas de la locura',NULL,8,6,8,NULL,2,1,'2021-02-03',267.00),(11,'Los pilares de la Tierra',NULL,9,8,9,NULL,2,1,'2021-01-07',289.00),(12,'Don Quijote de la Mancha',NULL,10,5,4,NULL,2,1,'2021-10-01',315.00),(13,'Juego de tronos',NULL,11,8,7,NULL,2,1,'2019-10-15',334.00),(14,'La vuelta al mundo en 80 días',NULL,4,3,6,NULL,2,1,'2017-05-01',273.00),(15,'Basilisco',NULL,12,5,10,NULL,2,1,'2020-03-30',465.00),(16,'El misterio del Agua Azul',NULL,13,3,11,NULL,2,1,'2007-02-01',328.00),(17,'Los tigres de Mompracem',NULL,6,3,12,NULL,2,1,'2011-09-19',266.00),(18,'El motín de la Bounty',NULL,14,2,13,NULL,2,1,'2008-09-08',1200.00),(19,'Miguel Strogoff',NULL,4,6,12,NULL,2,1,'2004-10-25',266.00),(20,'Moby Dick',NULL,15,6,6,NULL,2,1,'2020-12-10',245.00);
/*!40000 ALTER TABLE `libro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nivel_user`
--

DROP TABLE IF EXISTS `nivel_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nivel_user` (
  `IdNivelUser` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`IdNivelUser`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nivel_user`
--

LOCK TABLES `nivel_user` WRITE;
/*!40000 ALTER TABLE `nivel_user` DISABLE KEYS */;
INSERT INTO `nivel_user` VALUES (1,'Gerente'),(2,'Administrador'),(3,'Empleado'),(4,'Cubre Turno');
/*!40000 ALTER TABLE `nivel_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `persona`
--

DROP TABLE IF EXISTS `persona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persona`
--

LOCK TABLES `persona` WRITE;
/*!40000 ALTER TABLE `persona` DISABLE KEYS */;
INSERT INTO `persona` VALUES (1,'Miguel','Sixtega Escribano','calle Neptuno #5','2292111111','migna0519@gmail.com','mignafix','12345',1,1),(2,'Eduardo','Marquez','calle Verta #13','2292222222','eduardo22@gmail.com','eduardo','11223',1,1),(3,'Randy','Olivares','calle Norte #25','2291451227','radny@gmail.com','randy-oliv25','147852',2,1),(4,'Monserrat','Peña','calle sur #15','2291451233','monse@gmail.com','monse-15','447722',2,1),(5,'David','Valenzuela','calle Oeste #30','2291451219','daved@gmail.com','daved-val30','154421',2,1),(6,'Pedro','Flores','calle Poniente #11','2291451201','pedro@gmail.com','pedro-flo11','223311',3,1),(7,'Claudia','Mendez','calle Delfin #55','2291451244','claudia@gmail.com','claudia-men55','477852',3,1),(8,'Marilu','Hernadez','calle Tiburon #125','2291451472','marilu@gmail.com','mari-her125','771144',3,1),(9,'Adriana','Lopez','calle Leon #77','2291451374','adri@gmail.com','adriana-lop77','227799',3,1),(10,'Julio','Sanchez','calle Acuario #22','2291451348','julio@gmail.com','julio-san22','785247',3,1);
/*!40000 ALTER TABLE `persona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `precompra`
--

DROP TABLE IF EXISTS `precompra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `precompra` (
  `IdPre` int NOT NULL,
  `IdLibro` int NOT NULL,
  `Precio` int NOT NULL,
  `IdEmpleado` int NOT NULL,
  `Estado` tinyint DEFAULT '1',
  PRIMARY KEY (`IdPre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `precompra`
--

LOCK TABLES `precompra` WRITE;
/*!40000 ALTER TABLE `precompra` DISABLE KEYS */;
/*!40000 ALTER TABLE `precompra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedor`
--

DROP TABLE IF EXISTS `proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (1,13,'Rafael Gonzalez','2293024589','calle Laguna #11','rafael@gmail.com'),(2,12,'ALberto Beltran','2293026598','calle Pinos#22','alberto@gmail.com'),(3,11,'Miguel Cobos','2293011589','calle Perez #77','miguel@gmail.com'),(4,10,'Octavio Figueroa','2222554489','calle Santos #72','octavio@gmail.com'),(5,9,'Leonel Hernández','2297826589','calle Bolivar #254','leone@gmail.com'),(6,8,'Jualia Perez','2293026522','calle Pascal #5','julian@gmail.com'),(7,7,'Maria Hernández','2293011589','calle Reyes','maria@gmail.com'),(8,6,'Araminta Márquez','2294326589','calle Mar','araminta@gmail.com'),(9,5,'Judith Herrera','2293011560','calle Pez #188','judith@gmail.com'),(10,4,'Montse Alcaraz','2293026561','calle Agustin #88','monse@gmail.com'),(11,3,'Maria Ramirez','2294326562','calle Camacho #55','maria@gmail.com'),(12,2,'Pamela Herrera','2228026563','calle Bacalao #01','pamela@gmail.com'),(13,1,'Helena Hernández','2283026564','calle Tierra #04','helena@gmail.com');
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `verautor`
--

DROP TABLE IF EXISTS `verautor`;
/*!50001 DROP VIEW IF EXISTS `verautor`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `verautor` AS SELECT 
 1 AS `IdAutor`,
 1 AS `Nombre`,
 1 AS `Estado`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vercategoria`
--

DROP TABLE IF EXISTS `vercategoria`;
/*!50001 DROP VIEW IF EXISTS `vercategoria`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vercategoria` AS SELECT 
 1 AS `IdCategoria`,
 1 AS `Nombre`,
 1 AS `Estado`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vereditorial`
--

DROP TABLE IF EXISTS `vereditorial`;
/*!50001 DROP VIEW IF EXISTS `vereditorial`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vereditorial` AS SELECT 
 1 AS `IdEditorial`,
 1 AS `Nombre`,
 1 AS `Estado`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `verentrada`
--

DROP TABLE IF EXISTS `verentrada`;
/*!50001 DROP VIEW IF EXISTS `verentrada`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `verentrada` AS SELECT 
 1 AS `IdProd`,
 1 AS `Fecha`,
 1 AS `Titulo`,
 1 AS `Cantidad`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `verlibro`
--

DROP TABLE IF EXISTS `verlibro`;
/*!50001 DROP VIEW IF EXISTS `verlibro`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `verlibro` AS SELECT 
 1 AS `IdLibro`,
 1 AS `Titulo`,
 1 AS `Autor`,
 1 AS `Categoria`,
 1 AS `Editorial`,
 1 AS `Ubicacion`,
 1 AS `Ejemplares`,
 1 AS `Estado`,
 1 AS `FechaPublicacion`,
 1 AS `Costo`,
 1 AS `Precio`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `verpersona`
--

DROP TABLE IF EXISTS `verpersona`;
/*!50001 DROP VIEW IF EXISTS `verpersona`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `verpersona` AS SELECT 
 1 AS `IdPersona`,
 1 AS `Nombre`,
 1 AS `Apellido`,
 1 AS `Direccion`,
 1 AS `Telefono`,
 1 AS `Correo`,
 1 AS `Usuario`,
 1 AS `Nivel`,
 1 AS `Estado`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `verprecompra`
--

DROP TABLE IF EXISTS `verprecompra`;
/*!50001 DROP VIEW IF EXISTS `verprecompra`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `verprecompra` AS SELECT 
 1 AS `IdPre`,
 1 AS `Titulo`,
 1 AS `Precio`,
 1 AS `Nombre`,
 1 AS `Estado`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'proyecto'
--

--
-- Dumping routines for database 'proyecto'
--

--
-- Final view structure for view `verautor`
--

/*!50001 DROP VIEW IF EXISTS `verautor`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `verautor` AS select `autor`.`IdAutor` AS `IdAutor`,`autor`.`Nombre` AS `Nombre`,(case when (`autor`.`Estado` = 1) then 'Activo' else 'Inactivo' end) AS `Estado` from `autor` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vercategoria`
--

/*!50001 DROP VIEW IF EXISTS `vercategoria`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vercategoria` AS select `categoria`.`IdCategoria` AS `IdCategoria`,`categoria`.`Nombre` AS `Nombre`,(case when (`categoria`.`Estado` = 1) then 'Activo' else 'Inactivo' end) AS `Estado` from `categoria` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vereditorial`
--

/*!50001 DROP VIEW IF EXISTS `vereditorial`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vereditorial` AS select `editorial`.`IdEditorial` AS `IdEditorial`,`editorial`.`Nombre` AS `Nombre`,(case when (`editorial`.`Estado` = 1) then 'Activo' else 'Inactivo' end) AS `Estado` from `editorial` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `verentrada`
--

/*!50001 DROP VIEW IF EXISTS `verentrada`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `verentrada` AS select `entradaproduc`.`IdProd` AS `IdProd`,`entradaproduc`.`Fecha` AS `Fecha`,`libro`.`Titulo` AS `Titulo`,`entradaproduc`.`Cantidad` AS `Cantidad` from (`entradaproduc` join `libro` on((`entradaproduc`.`IdLibro` = `libro`.`IdLibro`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `verlibro`
--

/*!50001 DROP VIEW IF EXISTS `verlibro`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `verlibro` AS select `libro`.`IdLibro` AS `IdLibro`,`libro`.`Titulo` AS `Titulo`,`autor`.`Nombre` AS `Autor`,`categoria`.`Nombre` AS `Categoria`,`editorial`.`Nombre` AS `Editorial`,`libro`.`Ubicacion` AS `Ubicacion`,`libro`.`Ejemplares` AS `Ejemplares`,(case when (`libro`.`Estado` = 1) then 'Activo' else 'Inactivo' end) AS `Estado`,`libro`.`FechaPublicacion` AS `FechaPublicacion`,`libro`.`Costo` AS `Costo`,`libro`.`Precio` AS `Precio` from (((`libro` join `autor` on((`autor`.`IdAutor` = `libro`.`IdAutor`))) join `categoria` on((`categoria`.`IdCategoria` = `libro`.`IdCategoria`))) join `editorial` on((`editorial`.`IdEditorial` = `libro`.`IdEditorial`))) order by `libro`.`IdLibro` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `verpersona`
--

/*!50001 DROP VIEW IF EXISTS `verpersona`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `verpersona` AS select `persona`.`IdPersona` AS `IdPersona`,`persona`.`Nombre` AS `Nombre`,`persona`.`Apellido` AS `Apellido`,`persona`.`Direccion` AS `Direccion`,`persona`.`Telefono` AS `Telefono`,`persona`.`Correo` AS `Correo`,`persona`.`Usuario` AS `Usuario`,`nivel_user`.`Nombre` AS `Nivel`,(case when (`persona`.`Estado` = 1) then 'Activo' else 'Inactivo' end) AS `Estado` from (`persona` join `nivel_user` on((`persona`.`IdNivel` = `nivel_user`.`IdNivelUser`))) order by `persona`.`IdPersona` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `verprecompra`
--

/*!50001 DROP VIEW IF EXISTS `verprecompra`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `verprecompra` AS select `precompra`.`IdPre` AS `IdPre`,`libro`.`Titulo` AS `Titulo`,`precompra`.`Precio` AS `Precio`,`persona`.`Nombre` AS `Nombre`,(case when (`precompra`.`Estado` = 1) then 'Activo' else 'Inactivo' end) AS `Estado` from ((`precompra` join `libro`) join `persona`) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-11-17 23:35:10
