-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: dnd
-- ------------------------------------------------------
-- Server version	8.0.31

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
-- Table structure for table `armor`
--

DROP TABLE IF EXISTS `armor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `armor` (
  `id_armor` int NOT NULL AUTO_INCREMENT,
  `id_typea` int DEFAULT NULL,
  `name_armor` varchar(100) DEFAULT NULL,
  `desc_armor` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_armor`),
  KEY `id_typea` (`id_typea`),
  CONSTRAINT `armor_ibfk_1` FOREIGN KEY (`id_typea`) REFERENCES `type_armor` (`id_typea`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `armor`
--

LOCK TABLES `armor` WRITE;
/*!40000 ALTER TABLE `armor` DISABLE KEYS */;
INSERT INTO `armor` VALUES (1,1,'Стеганый','11+ЛОВ'),(2,2,'Шкурный','12+ЛОВ (макс. 2)'),(3,3,'Колечный','14'),(4,4,'Щит','+2');
/*!40000 ALTER TABLE `armor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `char_list`
--

DROP TABLE IF EXISTS `char_list`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `char_list` (
  `id_prof` int DEFAULT NULL,
  `id_char` int DEFAULT NULL,
  KEY `id_prof` (`id_prof`),
  KEY `id_char` (`id_char`),
  CONSTRAINT `char_list_ibfk_1` FOREIGN KEY (`id_prof`) REFERENCES `profile` (`id_prof`),
  CONSTRAINT `char_list_ibfk_2` FOREIGN KEY (`id_char`) REFERENCES `hero` (`id_char`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `char_list`
--

LOCK TABLES `char_list` WRITE;
/*!40000 ALTER TABLE `char_list` DISABLE KEYS */;
INSERT INTO `char_list` VALUES (1,9),(1,10),(4,11);
/*!40000 ALTER TABLE `char_list` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classes`
--

DROP TABLE IF EXISTS `classes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `classes` (
  `id_class` int NOT NULL AUTO_INCREMENT,
  `name_class` varchar(50) DEFAULT NULL,
  `desc_class` varchar(2000) DEFAULT NULL,
  `hitpoint` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_class`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classes`
--

LOCK TABLES `classes` WRITE;
/*!40000 ALTER TABLE `classes` DISABLE KEYS */;
INSERT INTO `classes` VALUES (1,'Воин','Опытный гладиатор сражается на арене и хорошо знает, как использовать свои трезубец и сеть, чтобы опрокинуть противника и обойти его, вызывая ликование публики и получая тактическое преимущество. Меч его противника вспыхивает голубым светом и испускает сверкающую молнию. Все эти герои - воины. Представители, возможно, самого разнообразного класса в мире D&D. Странствующие рыцари, военачальники-завоеватели, королевские чемпионы, элитная пехота, бронированные наёмники и короли разбоя - будучи воинами, все они мастерски владеют оружием, доспехами, и приёмами ведения боя. А еще они хорошо знакомы со смертью - они несут её сами, и часто смотрят в её холодные глаза. Инструменты: Нет; Спасброски: Сила, Телосложение; Навыки: Выберите два навыка из следующих: Акробатика, Атлетика, Восприятие, Выживание, Запугивание, История, Проницательность, Уход за животными','1к10+Телосложение');
/*!40000 ALTER TABLE `classes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `devotion`
--

DROP TABLE IF EXISTS `devotion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `devotion` (
  `id_devotion` int NOT NULL AUTO_INCREMENT,
  `desc_devotion` varchar(300) DEFAULT NULL,
  `id_history` int DEFAULT NULL,
  PRIMARY KEY (`id_devotion`),
  KEY `id_history` (`id_history`),
  CONSTRAINT `devotion_ibfk_1` FOREIGN KEY (`id_history`) REFERENCES `history` (`id_history`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devotion`
--

LOCK TABLES `devotion` WRITE;
/*!40000 ALTER TABLE `devotion` DISABLE KEYS */;
INSERT INTO `devotion` VALUES (1,'Я пойду на любой риск, лишь бы заслужить признание семьи.',1),(2,'Союз моего дома с другой благородной семьёй нужно поддерживать любой ценой.',1),(3,'Нет никого важнее других членов моей семьи.',1),(4,'Я влюблён в наследницу семейства, презираемого моей роднёй.',1),(5,'Моя преданность правителю непоколебима.',1),(6,'Обыватели должны считать меня своим героем.',1);
/*!40000 ALTER TABLE `devotion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equip_his`
--

DROP TABLE IF EXISTS `equip_his`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equip_his` (
  `id_equip` int NOT NULL AUTO_INCREMENT,
  `equipment` varchar(300) DEFAULT NULL,
  `id_history` int DEFAULT NULL,
  PRIMARY KEY (`id_equip`),
  KEY `id_history` (`id_history`),
  CONSTRAINT `equip_his_ibfk_1` FOREIGN KEY (`id_history`) REFERENCES `history` (`id_history`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equip_his`
--

LOCK TABLES `equip_his` WRITE;
/*!40000 ALTER TABLE `equip_his` DISABLE KEYS */;
INSERT INTO `equip_his` VALUES (1,'Благородный:Комплект отличной одежды, кольцо-печатка, свиток с генеалогическим древом, кошелёк с 25 зм;',1);
/*!40000 ALTER TABLE `equip_his` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hero`
--

DROP TABLE IF EXISTS `hero`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hero` (
  `id_char` int NOT NULL AUTO_INCREMENT,
  `name_c` varchar(100) DEFAULT NULL,
  `age` int DEFAULT NULL,
  `height` int DEFAULT NULL,
  `eye` varchar(50) DEFAULT NULL,
  `skin` varchar(50) DEFAULT NULL,
  `hair` varchar(50) DEFAULT NULL,
  `id_class` int DEFAULT NULL,
  `id_race` int DEFAULT NULL,
  `id_history` int DEFAULT NULL,
  `id_stat` int DEFAULT NULL,
  `trait` varchar(300) DEFAULT NULL,
  `ideal` varchar(300) DEFAULT NULL,
  `devotion` varchar(300) DEFAULT NULL,
  `weakness` varchar(300) DEFAULT NULL,
  `id_world` int DEFAULT NULL,
  `bio` varchar(1000) DEFAULT NULL,
  `equipment` varchar(2000) DEFAULT NULL,
  `abilites` varchar(2000) DEFAULT NULL,
  `date_create` date DEFAULT NULL,
  PRIMARY KEY (`id_char`),
  KEY `id_class` (`id_class`),
  KEY `id_race` (`id_race`),
  KEY `id_history` (`id_history`),
  KEY `id_world` (`id_world`),
  KEY `id_stat` (`id_stat`),
  CONSTRAINT `hero_ibfk_1` FOREIGN KEY (`id_class`) REFERENCES `classes` (`id_class`),
  CONSTRAINT `hero_ibfk_2` FOREIGN KEY (`id_race`) REFERENCES `race` (`id_race`),
  CONSTRAINT `hero_ibfk_3` FOREIGN KEY (`id_history`) REFERENCES `history` (`id_history`),
  CONSTRAINT `hero_ibfk_4` FOREIGN KEY (`id_world`) REFERENCES `worldview` (`id_world`),
  CONSTRAINT `hero_ibfk_5` FOREIGN KEY (`id_stat`) REFERENCES `stat` (`id_stat`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hero`
--

LOCK TABLES `hero` WRITE;
/*!40000 ALTER TABLE `hero` DISABLE KEYS */;
INSERT INTO `hero` VALUES (9,'tstst',16,60,'','','',1,2,1,8,'Несмотря на благородное рождение, я не ставлю себя выше народа. У всех нас течёт одинаковая кровь.','Власть. Если соберу много власти, никто не посмеет указывать мне, что делать.','Моя преданность правителю непоколебима.','Я втайне считаю всех ниже себя.',1,'','\r\nБлагородный:Комплект отличной одежды, кольцо-печатка, свиток с генеалогическим древом, кошелёк с 25 зм;\r\nБоевой посох(Простое рукопашное оружие, 1к6 дробящий урон, Универсальное (1к8))\r\nСтеганый(Лёгкий доспех, 11+ЛОВ)','\r\nВладение бронёй(Воин): Лёгкий доспех\r\nВладение бронёй(Воин): Средний доспех\r\nВладение бронёй(Воин): Тяжёлый доспех\r\nВладение бронёй(Воин): Щит\r\nВладение оружием(Воин): Простое рукопашное оружие\r\nВладение оружием(Воин): Простое дальнобойное оружие\r\nВладение оружием(Воин): Воинское рукопашное оружие\r\nВладение оружием(Воин): Воинское дальнобойное оружие','2023-03-28'),(10,'dmndchm',16,152,'mghcm','mchmg','mcgmh',1,1,1,9,'Я много трачу на то, чтобы выглядеть потрясающе, и по последнему слову моды.','Семья. Настоящая кровь гуще.','Я влюблён в наследницу семейства, презираемого моей роднёй.','Я втайне считаю всех ниже себя.',2,'','\r\nБлагородный:Комплект отличной одежды, кольцо-печатка, свиток с генеалогическим древом, кошелёк с 25 зм;','\r\nВладение бронёй(Воин): Лёгкий доспех\r\nВладение бронёй(Воин): Средний доспех\r\nВладение бронёй(Воин): Тяжёлый доспех\r\nВладение бронёй(Воин): Щит\r\nВладение оружием(Воин): Простое рукопашное оружие\r\nВладение оружием(Воин): Простое дальнобойное оружие\r\nВладение оружием(Воин): Воинское рукопашное оружие\r\nВладение оружием(Воин): Воинское дальнобойное оружие','2023-03-28'),(11,'йцу',116,80,'ййцу','йцу','йцу',1,2,1,10,'Несмотря на благородное рождение, я не ставлю себя выше народа. У всех нас течёт одинаковая кровь.','Ответственность. Я должен уважать тех, кто выше меня, а те, кто ниже меня, должны уважать меня.','Я влюблён в наследницу семейства, презираемого моей роднёй.','Я часто навлекаю позор на свою семью словами и действиями.',4,'йцуйцу','\r\nБлагородный:Комплект отличной одежды, кольцо-печаткошелёк с 25 зм;\r\nАлебарда(Воинское рукопашное оружие, 1к10 рубящий урон, Двуручное, досягаемость, тяжёлое)\r\nШкурный(Средний доспех, 12+ЛОВ (макс. 2))','\r\nВладение бронёй(Воин): Лёгкий доспех\r\nВладение бронёй(Воин): Средний доспех\r\nВладение бронёй(Воин): Тяжёлый доспех\r\nВладение бронёй(Воин): Щит\r\nВладение оружием(Воин): Простое рукопашное оружие\r\nВладение оружием(Воин): Простое дальнобойное оружие\r\nВладение оружием(Воин): Воинское рукопашное оружие\r\nВладение оружием(Воин): Воинское дальнобойное оружие','2023-03-29');
/*!40000 ALTER TABLE `hero` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `history`
--

DROP TABLE IF EXISTS `history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `history` (
  `id_history` int NOT NULL AUTO_INCREMENT,
  `desc_history` varchar(1000) DEFAULT NULL,
  `name_history` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_history`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `history`
--

LOCK TABLES `history` WRITE;
/*!40000 ALTER TABLE `history` DISABLE KEYS */;
INSERT INTO `history` VALUES (1,'Вы знаете, что такое богатство, власть и привилегии. У вас благородный титул, а ваша семья владеет землями, собирает налоги, и обладает серьёзным политическим влиянием. Вы можете быть изнеженным аристократом, незнакомым с работой и неудобствами, бывшим торговцем, только-только получившим титул, или лишённым наследства негодяем с гипертрофированным чувством собственного права. Или же вы можете быть честным, трудолюбивым землевладельцем, искренне заботящимся о тех, кто живёт и трудится на его земле, ощущая за них ответственность. Владение навыками: История, Убеждение. Владение инструментами: Один игровой набор. Языки: Один на ваш выбор','Благородный');
/*!40000 ALTER TABLE `history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ideal`
--

DROP TABLE IF EXISTS `ideal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ideal` (
  `id_ideal` int NOT NULL AUTO_INCREMENT,
  `desc_ideal` varchar(300) DEFAULT NULL,
  `id_history` int DEFAULT NULL,
  PRIMARY KEY (`id_ideal`),
  KEY `id_history` (`id_history`),
  CONSTRAINT `ideal_ibfk_1` FOREIGN KEY (`id_history`) REFERENCES `history` (`id_history`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ideal`
--

LOCK TABLES `ideal` WRITE;
/*!40000 ALTER TABLE `ideal` DISABLE KEYS */;
INSERT INTO `ideal` VALUES (1,'Уважение. Уважение - мой долг. Кем бы ты ни был, к другим нужно относиться с уважением, невзирая на их происхождение.',1),(2,'Ответственность. Я должен уважать тех, кто выше меня, а те, кто ниже меня, должны уважать меня.',1),(3,'Независимость. Я должен доказать, что справлюсь и без заботы своей семьи.',1),(4,'Власть. Если соберу много власти, никто не посмеет указывать мне, что делать.',1),(5,'Семья. Настоящая кровь гуще.',1),(6,'Благородный долг. Я должен защищать тех, кто ниже меня, и заботиться о них.',1);
/*!40000 ALTER TABLE `ideal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log`
--

DROP TABLE IF EXISTS `log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `log` (
  `id_log` int NOT NULL AUTO_INCREMENT,
  `log` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_log`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log`
--

LOCK TABLES `log` WRITE;
/*!40000 ALTER TABLE `log` DISABLE KEYS */;
INSERT INTO `log` VALUES (1,'tst'),(2,'dv'),(3,'еее'),(4,'йцу');
/*!40000 ALTER TABLE `log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modificator`
--

DROP TABLE IF EXISTS `modificator`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `modificator` (
  `id_mod` int NOT NULL AUTO_INCREMENT,
  `stat_point` int DEFAULT NULL,
  `mod_po` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`id_mod`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modificator`
--

LOCK TABLES `modificator` WRITE;
/*!40000 ALTER TABLE `modificator` DISABLE KEYS */;
INSERT INTO `modificator` VALUES (1,1,'-5'),(2,2,'-4'),(3,3,'-4'),(4,4,'-3'),(5,5,'-3'),(6,6,'-2'),(7,7,'-2'),(8,8,'-1'),(9,9,'-1'),(10,10,'0'),(11,11,'0'),(12,12,'+1'),(13,13,'+1'),(14,14,'+2'),(15,15,'+2'),(16,16,'+3'),(17,17,'+3'),(18,18,'+4'),(19,19,'+4'),(20,20,'+5'),(21,21,'+5'),(22,22,'+6'),(23,23,'+6'),(24,24,'+7'),(25,25,'+7'),(26,26,'+8'),(27,27,'+8'),(28,28,'+9'),(29,29,'+9'),(30,30,'+10');
/*!40000 ALTER TABLE `modificator` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profile`
--

DROP TABLE IF EXISTS `profile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `profile` (
  `id_prof` int NOT NULL AUTO_INCREMENT,
  `nick` varchar(50) DEFAULT NULL,
  `id_log` int DEFAULT NULL,
  `id_pswrd` int DEFAULT NULL,
  PRIMARY KEY (`id_prof`),
  KEY `id_log` (`id_log`),
  KEY `id_pswrd` (`id_pswrd`),
  CONSTRAINT `profile_ibfk_1` FOREIGN KEY (`id_log`) REFERENCES `log` (`id_log`),
  CONSTRAINT `profile_ibfk_2` FOREIGN KEY (`id_pswrd`) REFERENCES `pswrd` (`id_pswrd`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profile`
--

LOCK TABLES `profile` WRITE;
/*!40000 ALTER TABLE `profile` DISABLE KEYS */;
INSERT INTO `profile` VALUES (1,'tst',1,2),(2,'Бублик',2,3),(3,'',3,4),(4,'цув',4,5);
/*!40000 ALTER TABLE `profile` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pswrd`
--

DROP TABLE IF EXISTS `pswrd`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pswrd` (
  `id_pswrd` int NOT NULL AUTO_INCREMENT,
  `pswrd` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_pswrd`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pswrd`
--

LOCK TABLES `pswrd` WRITE;
/*!40000 ALTER TABLE `pswrd` DISABLE KEYS */;
INSERT INTO `pswrd` VALUES (2,'tst'),(3,'dv'),(4,'еее'),(5,'йцу');
/*!40000 ALTER TABLE `pswrd` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `race`
--

DROP TABLE IF EXISTS `race`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `race` (
  `id_race` int NOT NULL AUTO_INCREMENT,
  `name_race` varchar(100) DEFAULT NULL,
  `desc_race` varchar(2000) DEFAULT NULL,
  `speed` int DEFAULT NULL,
  `min_age` int DEFAULT NULL,
  `max_age` int DEFAULT NULL,
  `min_height` int DEFAULT NULL,
  `max_height` int DEFAULT NULL,
  PRIMARY KEY (`id_race`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `race`
--

LOCK TABLES `race` WRITE;
/*!40000 ALTER TABLE `race` DISABLE KEYS */;
INSERT INTO `race` VALUES (1,'Человек','В большинстве миров люди - это самая молодая из распространённых рас. Они поздно вышли на мировую сцену и живут намного меньше, чем дварфы, эльфы и драконы. Возможно, именно краткость их жизней заставляет их стремиться достигнуть как можно большего в отведённый им срок. А быть может, они хотят что-то доказать старшим расам, и поэтому создают могучие империи, основанные на завоеваниях и торговле. Что бы ни двигало ими, люди всегда были инноваторами и пионерами во всех мирах. Языки. Вы можете говорить, читать и писать на Общем и еще одном языке на ваш выбор. Люди обычно изучают языки народов, с которыми имеют дело, включая редкие диалекты. Они любят разбавлять собственную речь словами, позаимствованными из других языков: орочьими ругательствами, эльфийскими музыкальными терминами, дварфскими военными командами.',30,16,90,152,184),(2,'Полурослик','Целью большинства полуросликов является домашний уют. Место, где можно поселиться в покое и тишине, подальше от мародёрствующих чудовищ и сражающихся армий. Огонь очага, сытная пища, добрая выпивка и добрая беседа. Хотя некоторые полурослики проживают свой век в удалённых сельских общинах, другие сбиваются в постоянно кочующие общины, влекомые открытыми дорогами, широкими горизонтами и возможностью открыть чудеса новых мест и новых людей. Но даже такие кочевники любят покой, вкусную еду, свой очаг и свой дом, даже если это повозка, трясущаяся по пыльной дороге или плот, плывущий по течению реки.Везучий. Если при броске атаки, проверке характеристики или спасброске у вас выпало ?1?, вы можете перебросить кость, и должны использовать новый результат, даже если это ?1?. Храбрый. Вы совершаете с преимуществом спасброски от состояния испуганный. Проворство полуросликов. Вы можете проходить сквозь пространство, занятое существами, чей размер больше вашего. Языки. Вы можете говорить, читать и писать на Общем и языке Полуросликов. Их язык не является секретным, но они не торопятся делиться им с остальными. Пишут они мало, и почти не создали собственной литературы, но устные предания у них очень распространены. Почти все полурослики знают Общий, чтобы общаться с людьми в землях, куда они направляются, или по которым странствуют.',25,16,160,60,90),(3,'Полуэльф','Бродящие по двум мирам, но в действительности, не принадлежащие ни одному из них. Полуэльфы сочетают в себе, как некоторые говорят, лучшие качества обеих рас: человеческие любознательность, изобретательность и амбиции, приправленные изысканными чувствами, любовью к природе и ощущением прекрасного, свойственными эльфам. Некоторые полуэльфы живут среди людей, отгороженные эмоциональными и физическими различиями, наблюдая за старением друзей и возлюбленных, лишь слегка тронутые временем. Другие живут с эльфами в неподвластных времени эльфийских королевствах. Они стремительно растут, и достигают зрелости, пока их сверстники еще остаются детьми. Многие полуэльфы не способны ужиться ни в одном обществе, и выбирают жизнь одиноких странников или объединяются с другими изгнанниками и неудачниками, чтобы отправиться к приключениям. Тёмное зрение. Благодаря вашей эльфийской крови, вы обладаете превосходным зрением в темноте и при тусклом освещении. На расстоянии в 60 футов вы при тусклом освещении можете видеть так, как будто это яркое освещение, и в темноте так, как будто это тусклое освещение. В темноте вы не можете различать цвета, только оттенки серого. Наследие фей. Вы совершаете с преимуществом спасброски от состояния очарованный, и вас невозможно магически усыпить. Универсальность навыков. Вы получаете владение двумя навыками на ваш выбор. Языки. Вы можете говорить, читать и писать на Общем, Эльфийском и ещё одном языке на ваш выбор.',30,16,220,155,183);
/*!40000 ALTER TABLE `race` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skill_list`
--

DROP TABLE IF EXISTS `skill_list`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `skill_list` (
  `id_skill` int DEFAULT NULL,
  `id_char` int DEFAULT NULL,
  KEY `id_char` (`id_char`),
  KEY `id_skill` (`id_skill`),
  CONSTRAINT `skill_list_ibfk_1` FOREIGN KEY (`id_char`) REFERENCES `hero` (`id_char`),
  CONSTRAINT `skill_list_ibfk_2` FOREIGN KEY (`id_skill`) REFERENCES `skills` (`id_skill`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skill_list`
--

LOCK TABLES `skill_list` WRITE;
/*!40000 ALTER TABLE `skill_list` DISABLE KEYS */;
INSERT INTO `skill_list` VALUES (3,9),(4,9),(5,9),(7,10),(8,10),(13,10),(14,10),(5,11),(6,11),(7,11),(8,11);
/*!40000 ALTER TABLE `skill_list` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skills`
--

DROP TABLE IF EXISTS `skills`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `skills` (
  `id_skill` int NOT NULL AUTO_INCREMENT,
  `name_skill` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_skill`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skills`
--

LOCK TABLES `skills` WRITE;
/*!40000 ALTER TABLE `skills` DISABLE KEYS */;
INSERT INTO `skills` VALUES (1,'Акробатика (Лов)'),(2,'Анализ (Инт)'),(3,'Атлетика (Сил)'),(4,'Восприятие (Муд)'),(5,'Выживание (Муд)'),(6,'Выступление (Хар)'),(7,'Запугивание (Хар)'),(8,'История (Инт)'),(9,'Ловкость рук (Лов)'),(10,'Магия (Инт)'),(11,'Медицина (Муд)'),(12,'Обман (Хар)'),(13,'Природа (Инт)'),(14,'Проницательность (Муд)'),(15,'Религия (Инт)'),(16,'Скрытность (Лов)'),(17,'Убеждение (Хар)'),(18,'Уход за животными (Муд)');
/*!40000 ALTER TABLE `skills` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `spells`
--

DROP TABLE IF EXISTS `spells`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `spells` (
  `id_spell` int NOT NULL AUTO_INCREMENT,
  `name_spell` varchar(50) DEFAULT NULL,
  `id_class` int DEFAULT NULL,
  `desc_spell` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id_spell`),
  KEY `id_class` (`id_class`),
  CONSTRAINT `spells_ibfk_1` FOREIGN KEY (`id_class`) REFERENCES `classes` (`id_class`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spells`
--

LOCK TABLES `spells` WRITE;
/*!40000 ALTER TABLE `spells` DISABLE KEYS */;
INSERT INTO `spells` VALUES (1,'Второе дыхание',1,'Вы обладаете ограниченным источником выносливости, которым можете воспользоваться, чтобы уберечь себя. В свой ход вы можете бонусным действием восстановить хиты в размере 1к10 + ваш уровень воина.Использовав это умение, вы должны завершить короткий либо продолжительный отдых, чтобы получить возможность использовать его снова.');
/*!40000 ALTER TABLE `spells` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stat`
--

DROP TABLE IF EXISTS `stat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stat` (
  `id_stat` int NOT NULL AUTO_INCREMENT,
  `strenght` int DEFAULT NULL,
  `dextery` int DEFAULT NULL,
  `constilution` int DEFAULT NULL,
  `intelligence` int DEFAULT NULL,
  `wisdom` int DEFAULT NULL,
  `charisma` int DEFAULT NULL,
  PRIMARY KEY (`id_stat`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stat`
--

LOCK TABLES `stat` WRITE;
/*!40000 ALTER TABLE `stat` DISABLE KEYS */;
INSERT INTO `stat` VALUES (8,8,10,8,8,8,8),(9,9,9,9,9,9,9),(10,14,10,12,8,15,15);
/*!40000 ALTER TABLE `stat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tenure_armor`
--

DROP TABLE IF EXISTS `tenure_armor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tenure_armor` (
  `id_typea` int DEFAULT NULL,
  `id_class` int DEFAULT NULL,
  KEY `id_class` (`id_class`),
  KEY `id_typea` (`id_typea`),
  CONSTRAINT `tenure_armor_ibfk_1` FOREIGN KEY (`id_class`) REFERENCES `classes` (`id_class`),
  CONSTRAINT `tenure_armor_ibfk_2` FOREIGN KEY (`id_typea`) REFERENCES `type_armor` (`id_typea`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tenure_armor`
--

LOCK TABLES `tenure_armor` WRITE;
/*!40000 ALTER TABLE `tenure_armor` DISABLE KEYS */;
INSERT INTO `tenure_armor` VALUES (1,1),(2,1),(3,1),(4,1);
/*!40000 ALTER TABLE `tenure_armor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tenure_weapon`
--

DROP TABLE IF EXISTS `tenure_weapon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tenure_weapon` (
  `id_typew` int DEFAULT NULL,
  `id_class` int DEFAULT NULL,
  KEY `id_class` (`id_class`),
  KEY `id_typew` (`id_typew`),
  CONSTRAINT `tenure_weapon_ibfk_1` FOREIGN KEY (`id_class`) REFERENCES `classes` (`id_class`),
  CONSTRAINT `tenure_weapon_ibfk_2` FOREIGN KEY (`id_typew`) REFERENCES `type_weapon` (`id_typew`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tenure_weapon`
--

LOCK TABLES `tenure_weapon` WRITE;
/*!40000 ALTER TABLE `tenure_weapon` DISABLE KEYS */;
INSERT INTO `tenure_weapon` VALUES (1,1),(2,1),(3,1),(4,1);
/*!40000 ALTER TABLE `tenure_weapon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trait`
--

DROP TABLE IF EXISTS `trait`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `trait` (
  `id_trait` int NOT NULL AUTO_INCREMENT,
  `desc_trait` varchar(300) DEFAULT NULL,
  `id_history` int DEFAULT NULL,
  PRIMARY KEY (`id_trait`),
  KEY `id_history` (`id_history`),
  CONSTRAINT `trait_ibfk_1` FOREIGN KEY (`id_history`) REFERENCES `history` (`id_history`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trait`
--

LOCK TABLES `trait` WRITE;
/*!40000 ALTER TABLE `trait` DISABLE KEYS */;
INSERT INTO `trait` VALUES (1,'Я применяю так много лести, что все, с кем я разговариваю, чувствуют себя самыми чудесными и важными персонами в мире.',1),(2,'Обыватели любят меня за доброту и великодушие.',1),(3,'Один лишь взгляд на мои регалии заставляет перестать сомневаться в том, что я выше немытого отребья.',1),(4,'Я много трачу на то, чтобы выглядеть потрясающе, и по последнему слову моды.',1),(5,'Мне не нравится марать руки, и я не хочу умереть в каком-нибудь неподобающем месте.',1),(6,'Несмотря на благородное рождение, я не ставлю себя выше народа. У всех нас течёт одинаковая кровь.',1),(7,'Потеряв мою милость, обратно её не вернёшь.',1),(8,'Оскорбишь меня, и я сотру тебя в порошок, уничтожу твоё имя, и сожгу твои поля.',1);
/*!40000 ALTER TABLE `trait` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `type_armor`
--

DROP TABLE IF EXISTS `type_armor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type_armor` (
  `id_typea` int NOT NULL AUTO_INCREMENT,
  `typea` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_typea`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type_armor`
--

LOCK TABLES `type_armor` WRITE;
/*!40000 ALTER TABLE `type_armor` DISABLE KEYS */;
INSERT INTO `type_armor` VALUES (1,'Лёгкий доспех'),(2,'Средний доспех'),(3,'Тяжёлый доспех'),(4,'Щит');
/*!40000 ALTER TABLE `type_armor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `type_weapon`
--

DROP TABLE IF EXISTS `type_weapon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type_weapon` (
  `id_typew` int NOT NULL AUTO_INCREMENT,
  `typew` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_typew`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type_weapon`
--

LOCK TABLES `type_weapon` WRITE;
/*!40000 ALTER TABLE `type_weapon` DISABLE KEYS */;
INSERT INTO `type_weapon` VALUES (1,'Простое рукопашное оружие'),(2,'Простое дальнобойное оружие'),(3,'Воинское рукопашное оружие'),(4,'Воинское дальнобойное оружие');
/*!40000 ALTER TABLE `type_weapon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `weakness`
--

DROP TABLE IF EXISTS `weakness`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `weakness` (
  `id_weakness` int NOT NULL AUTO_INCREMENT,
  `desc_weakness` varchar(300) DEFAULT NULL,
  `id_history` int DEFAULT NULL,
  PRIMARY KEY (`id_weakness`),
  KEY `id_history` (`id_history`),
  CONSTRAINT `weakness_ibfk_1` FOREIGN KEY (`id_history`) REFERENCES `history` (`id_history`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `weakness`
--

LOCK TABLES `weakness` WRITE;
/*!40000 ALTER TABLE `weakness` DISABLE KEYS */;
INSERT INTO `weakness` VALUES (1,'Я втайне считаю всех ниже себя.',1),(2,'Я скрываю позорную тайну, которая может уничтожить мою семью.',1),(3,'Я слишком часто слышал завуалированные оскорбления и угрозы, и потому быстро впадаю в гнев.',1),(4,'У меня неустанная страсть к плотским удовольствиям.',1),(5,'Весь мир вращается вокруг меня.',1),(6,'Я часто навлекаю позор на свою семью словами и действиями.',1);
/*!40000 ALTER TABLE `weakness` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `weapon`
--

DROP TABLE IF EXISTS `weapon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `weapon` (
  `id_weapon` int NOT NULL AUTO_INCREMENT,
  `id_typew` int DEFAULT NULL,
  `name_weapon` varchar(100) DEFAULT NULL,
  `desc_weapon` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_weapon`),
  KEY `id_typew` (`id_typew`),
  CONSTRAINT `weapon_ibfk_1` FOREIGN KEY (`id_typew`) REFERENCES `type_weapon` (`id_typew`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `weapon`
--

LOCK TABLES `weapon` WRITE;
/*!40000 ALTER TABLE `weapon` DISABLE KEYS */;
INSERT INTO `weapon` VALUES (1,1,'Боевой посох','1к6 дробящий урон, Универсальное (1к8)'),(2,1,'Дубинка','1к4 дробящий, Лёгкое'),(3,2,'Короткий лук','1к6 колющий урон, Боеприпас (дис. 80/320), двуручное'),(4,3,'Алебарда','1к10 рубящий урон, Двуручное, досягаемость, тяжёлое'),(5,4,'Длинный лук','1к8 колющий урон, Боеприпас (дис. 150/600), двуручное, тяжёлое');
/*!40000 ALTER TABLE `weapon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `worldview`
--

DROP TABLE IF EXISTS `worldview`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `worldview` (
  `id_world` int NOT NULL AUTO_INCREMENT,
  `name_w` varchar(50) DEFAULT NULL,
  `desc_w` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`id_world`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `worldview`
--

LOCK TABLES `worldview` WRITE;
/*!40000 ALTER TABLE `worldview` DISABLE KEYS */;
INSERT INTO `worldview` VALUES (1,'Законно-добрый','Персонаж верит в то, что можно достичь всеобщего добра, если все будут руководствоваться справедливыми законами.'),(2,'Добрый','Персонаж склонен помогать другим.'),(3,'Хаотично-добрый','Персонаж действует в соответствии с велениями своего сердца, не обращая внимания на мнение окружающих.'),(4,'Законный','Персонаж действует в соответствии с законами, традициями или собственным моральным кодексом.'),(5,'Злой','Персонаж готов творить всё, что угодно, при условии, что он сможет уйти от ответственности.');
/*!40000 ALTER TABLE `worldview` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-04-16 17:44:53
