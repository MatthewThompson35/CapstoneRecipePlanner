CREATE DATABASE  IF NOT EXISTS `capstone` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `capstone`;
-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: capstone
-- ------------------------------------------------------
-- Server version	8.0.32

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
-- Table structure for table `ingredient`
--

DROP TABLE IF EXISTS `ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingredient` (
  `username` varchar(45) NOT NULL,
  `ingredientName` varchar(45) NOT NULL,
  `quantity` int NOT NULL,
  `ingredientID` int NOT NULL AUTO_INCREMENT,
  `measurement` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`ingredientID`),
  KEY `fk_ingredient_login_idx` (`username`),
  CONSTRAINT `fk_ingredient_login` FOREIGN KEY (`username`) REFERENCES `login` (`username`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=963 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredient`
--

LOCK TABLES `ingredient` WRITE;
/*!40000 ALTER TABLE `ingredient` DISABLE KEYS */;
INSERT INTO `ingredient` VALUES ('destiny','egg',5,1,'Count'),('global','cheese',12,3,'Count'),('global','bacon',4,4,'Count'),('global','Oranges',11,6,'Count'),('global','water',121,7,'Oz'),('destiny','flour',40,902,'G'),('testinglogin','Milk',1,917,'Oz'),('addinguser','milk',2,918,'Oz'),('testt','Water',1,919,'Oz'),('global','egg',4,938,'Count'),('global','Lucky Charms',21,940,'COUNT'),('global','milk',5,941,'OZ'),('global','Orange',123,954,'COUNT'),('global','aa',12,955,'COUNT'),('global','ab',1,956,'COUNT'),('global','bb',1,957,'COUNT'),('global','cc',1,958,'COUNT'),('global','aaaaaaa',2,962,'COUNT');
/*!40000 ALTER TABLE `ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `login` (
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login`
--

LOCK TABLES `login` WRITE;
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` VALUES ('a','8277e0910d750195b448797616e091ad'),('addinguser','c4ca4238a0b923820dcc509a6f75849b'),('admin','202cb962ac59075b964b07152d234b70'),('b','92eb5ffee6ae2fec3ad71c777531578f'),('d','0cc175b9c0f1b6a831c399e269772661'),('destiny','21232f297a57a5a743894a0e4a801fc3'),('g','b2f5ff47436671b6e533d8dc3614845d'),('global','ee11cbb19052e40b07aac0ca060c23ee'),('k','363b122c528f54df4a0446b6bab05515'),('newUser','14a88b9d2f52c55b5fbcf9c5d9c11875'),('s','0cc175b9c0f1b6a831c399e269772661'),('test','14a88b9d2f52c55b5fbcf9c5d9c11875'),('testinglogin','098f6bcd4621d373cade4e832627b4f6'),('tests','098f6bcd4621d373cade4e832627b4f6'),('testt','098f6bcd4621d373cade4e832627b4f6'),('user','c20ad4d76fe97759aa27a0c99bff6710');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `planned_recipe`
--

DROP TABLE IF EXISTS `planned_recipe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `planned_recipe` (
  `recipeID` int NOT NULL,
  `dayOfTheWeek` varchar(50) NOT NULL,
  `mealType` varchar(45) NOT NULL,
  `dateUsed` date NOT NULL,
  PRIMARY KEY (`recipeID`,`mealType`,`dateUsed`),
  CONSTRAINT `fk_recipe_plannedRecipe` FOREIGN KEY (`recipeID`) REFERENCES `recipe` (`recipeID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `planned_recipe`
--

LOCK TABLES `planned_recipe` WRITE;
/*!40000 ALTER TABLE `planned_recipe` DISABLE KEYS */;
INSERT INTO `planned_recipe` VALUES (1,'Monday','Breakfast','2023-03-06'),(1,'Monday','Breakfast','2023-03-13'),(1,'Tuesday','Breakfast','2023-03-21'),(1,'Wednesday','Breakfast','2023-03-22'),(1,'Monday','Lunch','2023-03-06'),(2,'Sunday','Breakfast','2023-03-05'),(2,'Tuesday','Breakfast','2023-03-07'),(2,'Saturday','Breakfast','2023-03-11'),(2,'Tuesday','Breakfast','2023-03-14'),(2,'Saturday','Breakfast','2023-03-18'),(2,'Monday','Breakfast','2023-03-20'),(2,'Sunday','Dinner','2023-03-12'),(2,'Thursday','Dinner','2023-03-16'),(2,'Friday','Dinner','2023-03-17'),(2,'Saturday','Dinner','2023-03-18'),(2,'Wednesday','Lunch','2023-03-15'),(2,'Thursday','Lunch','2023-03-16'),(3,'Wednesday','Lunch','2023-03-08');
/*!40000 ALTER TABLE `planned_recipe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe`
--

DROP TABLE IF EXISTS `recipe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipe` (
  `recipeID` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`recipeID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe`
--

LOCK TABLES `recipe` WRITE;
/*!40000 ALTER TABLE `recipe` DISABLE KEYS */;
INSERT INTO `recipe` VALUES (1,'Scrambled Eggs','Two scrambled eggs w/ cheese'),(2,'Bowl of Lucky Charms','A bowl of delicious Lucky Charms and milk'),(3,'Eggs Scrambled','Two scrambled eggs w/ cheese');
/*!40000 ALTER TABLE `recipe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe_ingredient`
--

DROP TABLE IF EXISTS `recipe_ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipe_ingredient` (
  `recipeID` int NOT NULL,
  `ingredientName` varchar(45) NOT NULL,
  `quantity` int NOT NULL,
  `measurement` varchar(45) NOT NULL,
  PRIMARY KEY (`recipeID`,`ingredientName`),
  CONSTRAINT `fk_recipe_recipeIngredient` FOREIGN KEY (`recipeID`) REFERENCES `recipe` (`recipeID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_ingredient`
--

LOCK TABLES `recipe_ingredient` WRITE;
/*!40000 ALTER TABLE `recipe_ingredient` DISABLE KEYS */;
INSERT INTO `recipe_ingredient` VALUES (1,'cheese',1,'COUNT'),(1,'egg',2,'COUNT'),(2,'Lucky Charms',20,'G'),(2,'milk',5,'OZ'),(3,'cheese',1,'COUNT'),(3,'egg',35,'COUNT');
/*!40000 ALTER TABLE `recipe_ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe_step`
--

DROP TABLE IF EXISTS `recipe_step`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipe_step` (
  `recipeID` int NOT NULL,
  `stepNumber` int NOT NULL,
  `stepDescription` varchar(200) NOT NULL,
  PRIMARY KEY (`recipeID`,`stepNumber`),
  CONSTRAINT `fk_recipe_recipeStep` FOREIGN KEY (`recipeID`) REFERENCES `recipe` (`recipeID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_step`
--

LOCK TABLES `recipe_step` WRITE;
/*!40000 ALTER TABLE `recipe_step` DISABLE KEYS */;
INSERT INTO `recipe_step` VALUES (1,1,'Crack both eggs into a bowl'),(1,2,'Whisk eggs together for 30 seconds'),(1,3,'Heat pan on the stove'),(1,4,'Pour whisked eggs into heated pan'),(1,5,'Continue to stir eggs in pan for 1 minute'),(1,6,'Place a piece of cheese on top of eggs and begin to mix in to eggs'),(1,7,'Once eggs reach desired texture remove from heat and place eggs on plate'),(2,1,'Pour cereal into bowl'),(2,2,'Pour milk into bowl'),(2,3,'Grab a spoon and enjoy'),(3,1,'Crack both eggs into a bowl'),(3,2,'Whisk eggs together for 30 seconds'),(3,3,'Heat pan on the stove'),(3,4,'Pour whisked eggs into heated pan'),(3,5,'Continue to stir eggs in pan for 1 minute'),(3,6,'Place a piece of cheese on top of eggs and begin to mix in to eggs');
/*!40000 ALTER TABLE `recipe_step` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe_tag`
--

DROP TABLE IF EXISTS `recipe_tag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipe_tag` (
  `recipeID` int NOT NULL,
  `tagName` varchar(100) NOT NULL,
  PRIMARY KEY (`recipeID`,`tagName`),
  CONSTRAINT `fk_recipe_recipeTag` FOREIGN KEY (`recipeID`) REFERENCES `recipe` (`recipeID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_tag`
--

LOCK TABLES `recipe_tag` WRITE;
/*!40000 ALTER TABLE `recipe_tag` DISABLE KEYS */;
INSERT INTO `recipe_tag` VALUES (1,'cool'),(1,'simple'),(2,'cool'),(3,'cool');
/*!40000 ALTER TABLE `recipe_tag` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-12 23:11:39
CREATE DATABASE  IF NOT EXISTS `capstone_tests` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `capstone_tests`;
-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: capstone_tests
-- ------------------------------------------------------
-- Server version	8.0.32

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
-- Table structure for table `ingredient`
--

DROP TABLE IF EXISTS `ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingredient` (
  `username` varchar(45) NOT NULL,
  `ingredientName` varchar(45) NOT NULL,
  `quantity` int NOT NULL,
  `ingredientID` int NOT NULL AUTO_INCREMENT,
  `measurement` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ingredientID`),
  KEY `fk_ingredient_login_idx_idx` (`username`),
  CONSTRAINT `fk_ingredient_login_idx` FOREIGN KEY (`username`) REFERENCES `login` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredient`
--

LOCK TABLES `ingredient` WRITE;
/*!40000 ALTER TABLE `ingredient` DISABLE KEYS */;
INSERT INTO `ingredient` VALUES ('global','Lucky Charms',30,1,'G'),('global','milk',8,2,'OZ'),('global','Flour',2,11,'G'),('global','Flour',2,12,'G'),('global','Flour',2,13,'G');
/*!40000 ALTER TABLE `ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `login` (
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login`
--

LOCK TABLES `login` WRITE;
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` VALUES ('global','ee11cbb19052e40b07aac0ca060c23ee');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `planned_recipe`
--

DROP TABLE IF EXISTS `planned_recipe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `planned_recipe` (
  `recipeID` int NOT NULL,
  `dayOfTheWeek` varchar(50) NOT NULL,
  `mealType` varchar(45) NOT NULL,
  `dateUsed` date NOT NULL,
  PRIMARY KEY (`recipeID`,`mealType`,`dateUsed`),
  CONSTRAINT `fk_recipe_plannedRecipe` FOREIGN KEY (`recipeID`) REFERENCES `recipe` (`recipeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `planned_recipe`
--

LOCK TABLES `planned_recipe` WRITE;
/*!40000 ALTER TABLE `planned_recipe` DISABLE KEYS */;
/*!40000 ALTER TABLE `planned_recipe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe`
--

DROP TABLE IF EXISTS `recipe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipe` (
  `recipeID` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`recipeID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe`
--

LOCK TABLES `recipe` WRITE;
/*!40000 ALTER TABLE `recipe` DISABLE KEYS */;
INSERT INTO `recipe` VALUES (1,'Bowl of Lucky Charms','A bowl of delicious Lucky Charms and milk');
/*!40000 ALTER TABLE `recipe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe_ingredient`
--

DROP TABLE IF EXISTS `recipe_ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipe_ingredient` (
  `recipeID` int NOT NULL,
  `ingredientName` varchar(45) NOT NULL,
  `quantity` int NOT NULL,
  `measurement` varchar(45) NOT NULL,
  PRIMARY KEY (`recipeID`,`ingredientName`),
  CONSTRAINT `fk_recipe_recipeIngredient` FOREIGN KEY (`recipeID`) REFERENCES `recipe` (`recipeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_ingredient`
--

LOCK TABLES `recipe_ingredient` WRITE;
/*!40000 ALTER TABLE `recipe_ingredient` DISABLE KEYS */;
INSERT INTO `recipe_ingredient` VALUES (1,'Lucky Charms',20,'G'),(1,'milk',5,'OZ');
/*!40000 ALTER TABLE `recipe_ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe_step`
--

DROP TABLE IF EXISTS `recipe_step`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipe_step` (
  `recipeID` int NOT NULL,
  `stepNumber` int NOT NULL,
  `stepDescription` varchar(200) NOT NULL,
  PRIMARY KEY (`recipeID`,`stepNumber`),
  CONSTRAINT `fk_recipe_recipeStep` FOREIGN KEY (`recipeID`) REFERENCES `recipe` (`recipeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_step`
--

LOCK TABLES `recipe_step` WRITE;
/*!40000 ALTER TABLE `recipe_step` DISABLE KEYS */;
INSERT INTO `recipe_step` VALUES (1,1,'Pour cereal into bowl'),(1,2,'Pour milk into bowl'),(1,3,'Grab a spoon and enjoy');
/*!40000 ALTER TABLE `recipe_step` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe_tag`
--

DROP TABLE IF EXISTS `recipe_tag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipe_tag` (
  `recipeID` int NOT NULL,
  `tagName` varchar(100) NOT NULL,
  PRIMARY KEY (`recipeID`,`tagName`),
  CONSTRAINT `fk_recipe_recipeTag` FOREIGN KEY (`recipeID`) REFERENCES `recipe` (`recipeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_tag`
--

LOCK TABLES `recipe_tag` WRITE;
/*!40000 ALTER TABLE `recipe_tag` DISABLE KEYS */;
/*!40000 ALTER TABLE `recipe_tag` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-12 23:11:39
