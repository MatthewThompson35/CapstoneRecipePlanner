-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: capstone_tests
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Current Database: `capstone_tests`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `capstone_tests` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `capstone_tests`;

--
-- Table structure for table `ingredient`
--

DROP TABLE IF EXISTS `ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingredient` (
  `ingredientID` int NOT NULL,
  `username` varchar(45) NOT NULL,
  `quantity` int NOT NULL,
  PRIMARY KEY (`ingredientID`,`username`),
  KEY `fk_ingredient_login_idx` (`username`),
  CONSTRAINT `fk_ingredient_ingredientInfo` FOREIGN KEY (`ingredientID`) REFERENCES `ingredient_info` (`ingredientID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_ingredient_login` FOREIGN KEY (`username`) REFERENCES `login` (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredient`
--

LOCK TABLES `ingredient` WRITE;
/*!40000 ALTER TABLE `ingredient` DISABLE KEYS */;
INSERT INTO `ingredient` VALUES (11,'global',2);
/*!40000 ALTER TABLE `ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredient_info`
--

DROP TABLE IF EXISTS `ingredient_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingredient_info` (
  `ingredientID` int NOT NULL AUTO_INCREMENT,
  `ingredientName` varchar(45) NOT NULL,
  `measurementType` varchar(15) NOT NULL,
  PRIMARY KEY (`ingredientID`)
) ENGINE=InnoDB AUTO_INCREMENT=60 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredient_info`
--

LOCK TABLES `ingredient_info` WRITE;
/*!40000 ALTER TABLE `ingredient_info` DISABLE KEYS */;
INSERT INTO `ingredient_info` VALUES (1,'cheese','COUNT'),(2,'egg','COUNT'),(3,'lucky charms','G'),(4,'milk','OZ'),(9,'water','OZ'),(10,'bacon','COUNT'),(11,'flour','G'),(12,'orange','COUNT'),(13,'lemon','COUNT'),(14,'banana','COUNT'),(17,'bread','COUNT'),(18,'ham','COUNT'),(49,'fddsfsdf','COUNT'),(50,'test','G'),(51,'sdfsd','OZ'),(52,'jkasj22','COUNT'),(53,'test1','COUNT'),(54,'testShopping','G'),(55,'testPantry','COUNT'),(56,'newIngredient','measurementType'),(57,'New Ingredient','cups'),(58,'Test Ingredient','OZ'),(59,'sugar','TSP');
/*!40000 ALTER TABLE `ingredient_info` ENABLE KEYS */;
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
INSERT INTO `login` VALUES ('admin','202cb962ac59075b964b07152d234b70'),('destiny','21232f297a57a5a743894a0e4a801fc3'),('global','ee11cbb19052e40b07aac0ca060c23ee'),('test','12312'),('user','c20ad4d76fe97759aa27a0c99bff6710');
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
  `username` varchar(50) NOT NULL,
  PRIMARY KEY (`recipeID`,`mealType`,`dateUsed`,`username`),
  KEY `fk_login_plannedRecipe_idx` (`username`),
  CONSTRAINT `fk_login_plannedRecipe` FOREIGN KEY (`username`) REFERENCES `login` (`username`),
  CONSTRAINT `fk_recipe_plannedRecipe` FOREIGN KEY (`recipeID`) REFERENCES `recipe` (`recipeID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `planned_recipe`
--

LOCK TABLES `planned_recipe` WRITE;
/*!40000 ALTER TABLE `planned_recipe` DISABLE KEYS */;
INSERT INTO `planned_recipe` VALUES (1,'Monday','Breakfast','2023-04-03','global'),(2,'Monday','Lunch','2023-04-03','global'),(3,'Friday','Lunch','2023-03-24','global'),(3,'Monday','Lunch','2023-04-10','global');
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
  PRIMARY KEY (`recipeID`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe`
--

LOCK TABLES `recipe` WRITE;
/*!40000 ALTER TABLE `recipe` DISABLE KEYS */;
INSERT INTO `recipe` VALUES (1,'Scrambled Eggs','Two scrambled eggs w/ cheese'),(2,'Bowl of Lucky Charms','A bowl of delicious Lucky Charms and milk'),(3,'Ham and Cheese Sandwich','A simple sandwich for on-the-go');
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
  `ingredientID` int NOT NULL,
  `quantity` int NOT NULL,
  `measurement` varchar(45) NOT NULL,
  PRIMARY KEY (`recipeID`,`ingredientID`),
  KEY `fk_recipeIngredient_ingredientInfo_idx` (`ingredientID`),
  CONSTRAINT `a` FOREIGN KEY (`recipeID`) REFERENCES `recipe` (`recipeID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_recipeIngredient_ingredientInfo` FOREIGN KEY (`ingredientID`) REFERENCES `ingredient_info` (`ingredientID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_ingredient`
--

LOCK TABLES `recipe_ingredient` WRITE;
/*!40000 ALTER TABLE `recipe_ingredient` DISABLE KEYS */;
INSERT INTO `recipe_ingredient` VALUES (1,1,1,'COUNT'),(1,2,2,'COUNT'),(1,57,2,'cups'),(2,3,20,'G'),(2,4,4,'OZ'),(3,1,1,'COUNT'),(3,17,2,'COUNT'),(3,18,1,'COUNT');
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
INSERT INTO `recipe_step` VALUES (1,1,'Crack both eggs into a bowl'),(1,2,'Whisk eggs together for 30 seconds'),(1,3,'Heat pan on the stove'),(1,4,'Pour whisked eggs into heated pan'),(1,5,'Continue to stir eggs in pan for 1 minute'),(1,6,'Place a piece of cheese on top of eggs and begin to mix in to eggs'),(1,7,'Once eggs reach desired texture remove from heat and place eggs on plate'),(2,1,'Pour cereal into bowl'),(2,2,'Pour milk into bowl'),(2,3,'Grab a spoon and enjoy'),(3,1,'Place 2 piece of bread on a plate'),(3,2,'Put 2 pieces of ham on one piece of bread'),(3,3,'Put a piece of cheese on the other piece of bread'),(3,4,'Press the two pieces of bread together and enjoy');
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
INSERT INTO `recipe_tag` VALUES (1,'breakfast'),(1,'simple'),(1,'vegetarian'),(2,'breakfast'),(2,'simple'),(3,'lunch'),(3,'simple');
/*!40000 ALTER TABLE `recipe_tag` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shared_recipe`
--

DROP TABLE IF EXISTS `shared_recipe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shared_recipe` (
  `sender_username` varchar(50) NOT NULL,
  `receiver_username` varchar(50) NOT NULL,
  `recipeID` int NOT NULL,
  PRIMARY KEY (`sender_username`,`receiver_username`,`recipeID`),
  KEY `fk_login_sharedRecipe_idx` (`receiver_username`),
  KEY `fk_recipe_sharedRecipe_idx` (`recipeID`),
  CONSTRAINT `fk_login_sharedRecipe` FOREIGN KEY (`receiver_username`) REFERENCES `login` (`username`),
  CONSTRAINT `fk_recipe_sharedRecipe` FOREIGN KEY (`recipeID`) REFERENCES `recipe` (`recipeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shared_recipe`
--

LOCK TABLES `shared_recipe` WRITE;
/*!40000 ALTER TABLE `shared_recipe` DISABLE KEYS */;
INSERT INTO `shared_recipe` VALUES ('global','global',3);
/*!40000 ALTER TABLE `shared_recipe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shopping_list`
--

DROP TABLE IF EXISTS `shopping_list`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shopping_list` (
  `ingredientID` int NOT NULL,
  `username` varchar(45) NOT NULL,
  `quantity` int NOT NULL,
  PRIMARY KEY (`ingredientID`,`username`),
  KEY `fk_login_shoppingList_idx` (`username`),
  CONSTRAINT `fk_ingredientInfo_shoppingList` FOREIGN KEY (`ingredientID`) REFERENCES `ingredient_info` (`ingredientID`),
  CONSTRAINT `fk_login_shoppingList` FOREIGN KEY (`username`) REFERENCES `login` (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shopping_list`
--

LOCK TABLES `shopping_list` WRITE;
/*!40000 ALTER TABLE `shopping_list` DISABLE KEYS */;
/*!40000 ALTER TABLE `shopping_list` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Current Database: `capstone`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `capstone` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `capstone`;

--
-- Table structure for table `ingredient`
--

DROP TABLE IF EXISTS `ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingredient` (
  `ingredientID` int NOT NULL,
  `username` varchar(45) NOT NULL,
  `quantity` int NOT NULL,
  PRIMARY KEY (`ingredientID`,`username`),
  KEY `fk_ingredient_login_idx` (`username`),
  CONSTRAINT `fk_ingredient_ingredientInfo` FOREIGN KEY (`ingredientID`) REFERENCES `ingredient_info` (`ingredientID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_ingredient_login` FOREIGN KEY (`username`) REFERENCES `login` (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredient`
--

LOCK TABLES `ingredient` WRITE;
/*!40000 ALTER TABLE `ingredient` DISABLE KEYS */;
INSERT INTO `ingredient` VALUES (1,'admin',8),(1,'global',70),(2,'global',31),(3,'admin',49),(3,'global',29),(4,'admin',27),(4,'global',65),(9,'global',102),(10,'global',12),(11,'admin',4),(11,'global',9),(12,'global',2),(13,'global',5),(14,'global',6),(17,'global',34),(18,'global',18),(54,'global',244),(55,'global',32323);
/*!40000 ALTER TABLE `ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredient_info`
--

DROP TABLE IF EXISTS `ingredient_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingredient_info` (
  `ingredientID` int NOT NULL AUTO_INCREMENT,
  `ingredientName` varchar(45) NOT NULL,
  `measurementType` varchar(15) NOT NULL,
  PRIMARY KEY (`ingredientID`)
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredient_info`
--

LOCK TABLES `ingredient_info` WRITE;
/*!40000 ALTER TABLE `ingredient_info` DISABLE KEYS */;
INSERT INTO `ingredient_info` VALUES (1,'cheese','COUNT'),(2,'egg','COUNT'),(3,'lucky charms','G'),(4,'milk','OZ'),(9,'water','OZ'),(10,'bacon','COUNT'),(11,'flour','G'),(12,'orange','COUNT'),(13,'lemon','COUNT'),(14,'banana','COUNT'),(17,'bread','COUNT'),(18,'ham','COUNT'),(49,'fddsfsdf','COUNT'),(50,'test','G'),(51,'sdfsd','OZ'),(52,'jkasj22','COUNT'),(53,'test1','COUNT'),(54,'testShopping','G'),(55,'testPantry','COUNT');
/*!40000 ALTER TABLE `ingredient_info` ENABLE KEYS */;
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
INSERT INTO `login` VALUES ('admin','202cb962ac59075b964b07152d234b70'),('destiny','21232f297a57a5a743894a0e4a801fc3'),('global','ee11cbb19052e40b07aac0ca060c23ee'),('newUser','14a88b9d2f52c55b5fbcf9c5d9c11875'),('testuser1','testpassword1'),('testuser2','testpassword2'),('user','c20ad4d76fe97759aa27a0c99bff6710');
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
  `username` varchar(50) NOT NULL,
  PRIMARY KEY (`recipeID`,`mealType`,`dateUsed`,`username`),
  KEY `fk_login_plannedRecipe_idx` (`username`),
  CONSTRAINT `fk_login_plannedRecipe` FOREIGN KEY (`username`) REFERENCES `login` (`username`),
  CONSTRAINT `fk_recipe_plannedRecipe` FOREIGN KEY (`recipeID`) REFERENCES `recipe` (`recipeID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `planned_recipe`
--

LOCK TABLES `planned_recipe` WRITE;
/*!40000 ALTER TABLE `planned_recipe` DISABLE KEYS */;
INSERT INTO `planned_recipe` VALUES (1,'Monday','Breakfast','2023-04-03','global'),(2,'Monday','Lunch','2023-04-03','global'),(3,'Friday','Lunch','2023-03-24','global'),(3,'Monday','Lunch','2023-04-10','global');
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
  PRIMARY KEY (`recipeID`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe`
--

LOCK TABLES `recipe` WRITE;
/*!40000 ALTER TABLE `recipe` DISABLE KEYS */;
INSERT INTO `recipe` VALUES (1,'Scrambled Eggs','Two scrambled eggs w/ cheese'),(2,'Bowl of Lucky Charms','A bowl of delicious Lucky Charms and milk'),(3,'Ham and Cheese Sandwich','A simple sandwich for on-the-go');
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
  `ingredientID` int NOT NULL,
  `quantity` int NOT NULL,
  `measurement` varchar(45) NOT NULL,
  PRIMARY KEY (`recipeID`,`ingredientID`),
  KEY `fk_recipeIngredient_ingredientInfo_idx` (`ingredientID`),
  CONSTRAINT `fk_recipeIngredient_ingredientInfo` FOREIGN KEY (`ingredientID`) REFERENCES `ingredient_info` (`ingredientID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_ingredient`
--

LOCK TABLES `recipe_ingredient` WRITE;
/*!40000 ALTER TABLE `recipe_ingredient` DISABLE KEYS */;
INSERT INTO `recipe_ingredient` VALUES (1,1,1,'COUNT'),(1,2,2,'COUNT'),(2,3,20,'G'),(2,4,4,'OZ'),(3,1,1,'COUNT'),(3,17,2,'COUNT'),(3,18,1,'COUNT');
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
INSERT INTO `recipe_step` VALUES (1,1,'Crack both eggs into a bowl'),(1,2,'Whisk eggs together for 30 seconds'),(1,3,'Heat pan on the stove'),(1,4,'Pour whisked eggs into heated pan'),(1,5,'Continue to stir eggs in pan for 1 minute'),(1,6,'Place a piece of cheese on top of eggs and begin to mix in to eggs'),(1,7,'Once eggs reach desired texture remove from heat and place eggs on plate'),(2,1,'Pour cereal into bowl'),(2,2,'Pour milk into bowl'),(2,3,'Grab a spoon and enjoy'),(3,1,'Place 2 piece of bread on a plate'),(3,2,'Put 2 pieces of ham on one piece of bread'),(3,3,'Put a piece of cheese on the other piece of bread'),(3,4,'Press the two pieces of bread together and enjoy');
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
INSERT INTO `recipe_tag` VALUES (1,'breakfast'),(1,'simple'),(1,'vegetarian'),(2,'breakfast'),(2,'simple'),(3,'lunch'),(3,'simple');
/*!40000 ALTER TABLE `recipe_tag` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shared_recipe`
--

DROP TABLE IF EXISTS `shared_recipe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shared_recipe` (
  `sender_username` varchar(50) NOT NULL,
  `receiver_username` varchar(50) NOT NULL,
  `recipeID` int NOT NULL,
  PRIMARY KEY (`sender_username`,`receiver_username`,`recipeID`),
  KEY `fk_login_sharedRecipe_idx` (`receiver_username`),
  KEY `fk_recipe_sharedRecipe_idx` (`recipeID`),
  CONSTRAINT `fk_login_sharedRecipe` FOREIGN KEY (`receiver_username`) REFERENCES `login` (`username`),
  CONSTRAINT `fk_recipe_sharedRecipe` FOREIGN KEY (`recipeID`) REFERENCES `recipe` (`recipeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shared_recipe`
--

LOCK TABLES `shared_recipe` WRITE;
/*!40000 ALTER TABLE `shared_recipe` DISABLE KEYS */;
INSERT INTO `shared_recipe` VALUES ('destiny','global',1),('global','admin',1),('global','admin',2),('global','destiny',2),('global','global',2),('global','global',3);
/*!40000 ALTER TABLE `shared_recipe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shopping_list`
--

DROP TABLE IF EXISTS `shopping_list`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shopping_list` (
  `ingredientID` int NOT NULL,
  `username` varchar(45) NOT NULL,
  `quantity` int NOT NULL,
  PRIMARY KEY (`ingredientID`,`username`),
  KEY `fk_login_shoppingList_idx` (`username`),
  CONSTRAINT `fk_ingredientInfo_shoppingList` FOREIGN KEY (`ingredientID`) REFERENCES `ingredient_info` (`ingredientID`),
  CONSTRAINT `fk_login_shoppingList` FOREIGN KEY (`username`) REFERENCES `login` (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shopping_list`
--

LOCK TABLES `shopping_list` WRITE;
/*!40000 ALTER TABLE `shopping_list` DISABLE KEYS */;
INSERT INTO `shopping_list` VALUES (4,'global',7);
/*!40000 ALTER TABLE `shopping_list` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-04-05  0:24:23
