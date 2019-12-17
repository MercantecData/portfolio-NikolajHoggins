-- MySQL dump 10.13  Distrib 8.0.18, for osx10.14 (x86_64)
--
-- Host: localhost    Database: learnmysql
-- ------------------------------------------------------
-- Server version	8.0.18

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `addresses`
--

DROP TABLE IF EXISTS `addresses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `addresses` (
  `ADDR_ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_ID` int(11) DEFAULT NULL,
  `Address` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `City` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ZipCode` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Country` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`ADDR_ID`),
  KEY `User_ID` (`User_ID`),
  CONSTRAINT `addresses_ibfk_1` FOREIGN KEY (`User_ID`) REFERENCES `users` (`ID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `addresses`
--

LOCK TABLES `addresses` WRITE;
/*!40000 ALTER TABLE `addresses` DISABLE KEYS */;
INSERT INTO `addresses` VALUES (1,1,'Hans Tausens Vej 22','Viborg','8800','Denmark'),(2,2,'Marinavejen 18','Randers','8900','Denmark'),(3,3,'Slåenhaven 81','Viborg','8800','Denmark'),(4,4,'139  Rowland Rd','ORCOP','HR2 3PX','England'),(5,5,'Højbovej 27','Copenhagen','1113','Denmark'),(6,6,'Slåenhaven 16','Viborg','8800','Denmark'),(7,7,'Viborgvej 73','Viborg','8800','Denmark'),(8,7,'Degnehøjvej 98','Silkeborg','8600','Denamrk'),(9,8,'Mellemvej 87','Aablorg','9029','Denmark'),(10,9,'Marinavejen 50','Randers','8900','Denmark'),(11,10,'Normansvej 1','Randers','8900','Denamrk');
/*!40000 ALTER TABLE `addresses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `getallinfo_bymostrevenue`
--

DROP TABLE IF EXISTS `getallinfo_bymostrevenue`;
/*!50001 DROP VIEW IF EXISTS `getallinfo_bymostrevenue`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `getallinfo_bymostrevenue` AS SELECT 
 1 AS `Order ID`,
 1 AS `Kunde ID`,
 1 AS `Kunde Navn`,
 1 AS `Vej Navn`,
 1 AS `By`,
 1 AS `Land`,
 1 AS `Produkt Navn`,
 1 AS `Pris`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `getallinfo_byorderid`
--

DROP TABLE IF EXISTS `getallinfo_byorderid`;
/*!50001 DROP VIEW IF EXISTS `getallinfo_byorderid`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `getallinfo_byorderid` AS SELECT 
 1 AS `Order ID`,
 1 AS `Kunde ID`,
 1 AS `Kunde Navn`,
 1 AS `Vej Navn`,
 1 AS `By`,
 1 AS `Land`,
 1 AS `Produkt Navn`,
 1 AS `Pris`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `Order_ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_ID` int(11) DEFAULT NULL,
  `ADDR_ID` int(11) DEFAULT NULL,
  `PROD_ID` int(11) NOT NULL,
  PRIMARY KEY (`Order_ID`),
  KEY `User_ID` (`User_ID`),
  KEY `ADDR_ID` (`ADDR_ID`),
  KEY `fk_PROD_ID` (`PROD_ID`),
  CONSTRAINT `fk_PROD_ID` FOREIGN KEY (`PROD_ID`) REFERENCES `products` (`Prod_ID`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`User_ID`) REFERENCES `users` (`ID`) ON DELETE CASCADE,
  CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`ADDR_ID`) REFERENCES `addresses` (`ADDR_ID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,1,1,1),(2,2,2,10),(3,1,1,10),(4,1,1,2),(5,3,3,4),(6,7,7,8),(7,7,8,8),(8,10,11,10);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `ordersin_randers`
--

DROP TABLE IF EXISTS `ordersin_randers`;
/*!50001 DROP VIEW IF EXISTS `ordersin_randers`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `ordersin_randers` AS SELECT 
 1 AS `Order_ID`,
 1 AS `Produkt`,
 1 AS `Pris`,
 1 AS `Kunde email`,
 1 AS `Vej Navn`,
 1 AS `By`,
 1 AS `PostNummer`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `ordersin_viborg`
--

DROP TABLE IF EXISTS `ordersin_viborg`;
/*!50001 DROP VIEW IF EXISTS `ordersin_viborg`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `ordersin_viborg` AS SELECT 
 1 AS `Order_ID`,
 1 AS `Produkt`,
 1 AS `Pris`,
 1 AS `Kunde email`,
 1 AS `Vej Navn`,
 1 AS `By`,
 1 AS `PostNummer`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `Prod_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Prod_Name` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Prod_Description` varchar(320) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Prod_Stock` int(11) DEFAULT NULL,
  `Prod_Price` double DEFAULT NULL,
  PRIMARY KEY (`Prod_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Audi R8','Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper. Lorem Ipsum ',10,3100000),(2,'Audi RS7','Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper. Lorem Ipsum ',34,1800000),(3,'Audi A2','Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper. Lorem Ipsum ',100000,10),(4,'Audi A5','Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper. Lorem Ipsum ',54,700000),(5,'Audi A6','Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper. Lorem Ipsum ',47,974000),(6,'Audi RS3','Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper. Lorem Ipsum ',12,1100000),(7,'Audi A1','Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper. Lorem Ipsum ',42,250000),(8,'Audi A7','Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper. Lorem Ipsum ',32,650000),(9,'Audi A4','Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper. Lorem Ipsum ',67,350000),(10,'Audi TT','Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper. Lorem Ipsum ',12,1500000);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Email` varchar(320) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `First_Name` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Last_Name` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'johncena123','johncena@mail.dk','John','Cena'),(2,'shootinhoops123','lebronjames@mail.dk','Lebron','James'),(3,'anomalygaming','anomaly@mail.dk','Anomaly','swede'),(4,'nikolaj1234','nikolajhoggins@mail.dk','Nikolaj','Hoggins'),(5,'magvib','magnusnielsen@mail.dk','Magnus','Nielsen'),(6,'comegetmebbq123','jonesbbqandfootmassage@mail.dk','Jones','BBQ'),(7,'TheGoldenTurd','donaldtrump@thewhitehouse.com','Donald','Trump'),(8,'HahaFunnyUsername','Theonly@gmail.com','First','Last'),(9,'FxckFace','Jeppevad@gmail.com','Jeppe','Vad'),(10,'SomeBlackGuy','barackobama@thewhitehouse.com','Obama','Care');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Final view structure for view `getallinfo_bymostrevenue`
--

/*!50001 DROP VIEW IF EXISTS `getallinfo_bymostrevenue`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`phpmyadminuser`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `getallinfo_bymostrevenue` AS select `o`.`Order_ID` AS `Order ID`,`u`.`ID` AS `Kunde ID`,`u`.`First_Name` AS `Kunde Navn`,`a`.`Address` AS `Vej Navn`,`a`.`City` AS `By`,`a`.`Country` AS `Land`,`p`.`Prod_Name` AS `Produkt Navn`,`p`.`Prod_Price` AS `Pris` from (((`orders` `o` join `products` `p` on((`p`.`Prod_ID` = `o`.`PROD_ID`))) join `users` `u` on((`u`.`ID` = `o`.`User_ID`))) join `addresses` `a` on((`a`.`ADDR_ID` = `o`.`ADDR_ID`))) order by `p`.`Prod_Price` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `getallinfo_byorderid`
--

/*!50001 DROP VIEW IF EXISTS `getallinfo_byorderid`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`phpmyadminuser`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `getallinfo_byorderid` AS select `o`.`Order_ID` AS `Order ID`,`u`.`ID` AS `Kunde ID`,`u`.`First_Name` AS `Kunde Navn`,`a`.`Address` AS `Vej Navn`,`a`.`City` AS `By`,`a`.`Country` AS `Land`,`p`.`Prod_Name` AS `Produkt Navn`,`p`.`Prod_Price` AS `Pris` from (((`orders` `o` join `products` `p` on((`p`.`Prod_ID` = `o`.`PROD_ID`))) join `users` `u` on((`u`.`ID` = `o`.`User_ID`))) join `addresses` `a` on((`a`.`ADDR_ID` = `o`.`ADDR_ID`))) order by `o`.`Order_ID` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `ordersin_randers`
--

/*!50001 DROP VIEW IF EXISTS `ordersin_randers`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`phpmyadminuser`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `ordersin_randers` AS select `o`.`Order_ID` AS `Order_ID`,`p`.`Prod_Name` AS `Produkt`,`p`.`Prod_Price` AS `Pris`,`u`.`Email` AS `Kunde email`,`a`.`Address` AS `Vej Navn`,`a`.`City` AS `By`,`a`.`ZipCode` AS `PostNummer` from (((`orders` `o` join `addresses` `a` on((`a`.`ADDR_ID` = `o`.`ADDR_ID`))) join `products` `p` on((`p`.`Prod_ID` = `o`.`PROD_ID`))) join `users` `u` on((`u`.`ID` = `o`.`User_ID`))) where (`a`.`ZipCode` = '8900') */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `ordersin_viborg`
--

/*!50001 DROP VIEW IF EXISTS `ordersin_viborg`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`phpmyadminuser`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `ordersin_viborg` AS select `o`.`Order_ID` AS `Order_ID`,`p`.`Prod_Name` AS `Produkt`,`p`.`Prod_Price` AS `Pris`,`u`.`Email` AS `Kunde email`,`a`.`Address` AS `Vej Navn`,`a`.`City` AS `By`,`a`.`ZipCode` AS `PostNummer` from (((`orders` `o` join `addresses` `a` on((`a`.`ADDR_ID` = `o`.`ADDR_ID`))) join `products` `p` on((`p`.`Prod_ID` = `o`.`PROD_ID`))) join `users` `u` on((`u`.`ID` = `o`.`User_ID`))) where (`a`.`ZipCode` = '8800') */;
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

-- Dump completed on 2019-11-27  9:58:34
