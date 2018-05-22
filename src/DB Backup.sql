/*
SQLyog Community v12.4.3 (32 bit)
MySQL - 5.7.21-log : Database - vapecms
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`vapecms` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `vapecms`;

/*Table structure for table `categories` */

DROP TABLE IF EXISTS `categories`;

CREATE TABLE `categories` (
  `CategoryId` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryGuId` int(11) DEFAULT NULL,
  `Category` varchar(20) DEFAULT NULL,
  `Updated` date DEFAULT NULL,
  `UserIdUpdated` int(11) DEFAULT NULL,
  `Deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`CategoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `categories` */

/*Table structure for table `colors` */

DROP TABLE IF EXISTS `colors`;

CREATE TABLE `colors` (
  `colorId` int(11) NOT NULL AUTO_INCREMENT,
  `color` varchar(20) DEFAULT NULL,
  `Updated` date DEFAULT NULL,
  `UserIdUpdated` int(11) DEFAULT NULL,
  `Deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`colorId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `colors` */

/*Table structure for table `files` */

DROP TABLE IF EXISTS `files`;

CREATE TABLE `files` (
  `FileId` int(11) NOT NULL AUTO_INCREMENT,
  `FileName` varchar(30) DEFAULT NULL,
  `FileContentType` varchar(30) DEFAULT NULL,
  `FileSize` int(11) DEFAULT NULL,
  `FileBytes` blob,
  `Deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`FileId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `files` */

/*Table structure for table `nicotine` */

DROP TABLE IF EXISTS `nicotine`;

CREATE TABLE `nicotine` (
  `NicotineId` int(11) NOT NULL AUTO_INCREMENT,
  `NicotineAmount` int(11) DEFAULT NULL,
  `Updated` date DEFAULT NULL,
  `UserIdUpdated` int(11) DEFAULT NULL,
  `Deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`NicotineId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `nicotine` */

/*Table structure for table `productcolortie` */

DROP TABLE IF EXISTS `productcolortie`;

CREATE TABLE `productcolortie` (
  `ProductColorTieId` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) DEFAULT NULL,
  `NicotineId` int(11) DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `Discount` double DEFAULT NULL,
  `stock` int(11) DEFAULT NULL,
  `Updated` date DEFAULT NULL,
  `UserIdUpdated` int(11) DEFAULT NULL,
  `Deleted` int(11) DEFAULT NULL,
  PRIMARY KEY (`ProductColorTieId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `productcolortie` */

/*Table structure for table `productimagetie` */

DROP TABLE IF EXISTS `productimagetie`;

CREATE TABLE `productimagetie` (
  `ProductImageTieId` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) DEFAULT NULL,
  `FileId` int(11) DEFAULT NULL,
  `Updated` date DEFAULT NULL,
  `UserIdUpdated` int(11) DEFAULT NULL,
  `Deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`ProductImageTieId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `productimagetie` */

/*Table structure for table `productnicotinetie` */

DROP TABLE IF EXISTS `productnicotinetie`;

CREATE TABLE `productnicotinetie` (
  `ProductNicotineTieId` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) DEFAULT NULL,
  `NicotineId` int(11) DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `Discount` double DEFAULT NULL,
  `Stock` int(11) DEFAULT NULL,
  `Updated` date DEFAULT NULL,
  `UserIdUpdated` date DEFAULT NULL,
  `Deleted` int(11) DEFAULT NULL,
  PRIMARY KEY (`ProductNicotineTieId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `productnicotinetie` */

/*Table structure for table `products` */

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `ProductId` int(11) NOT NULL AUTO_INCREMENT,
  `ProductGuId` int(11) DEFAULT NULL,
  `Product` varchar(30) DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `Discount` double DEFAULT NULL,
  `Discription` text,
  `Updated` date DEFAULT NULL,
  `UserIdUpdated` int(11) DEFAULT NULL,
  `Deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`ProductId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `products` */

/*Table structure for table `productscategorytie` */

DROP TABLE IF EXISTS `productscategorytie`;

CREATE TABLE `productscategorytie` (
  `ProductsCategoryTieId` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) DEFAULT NULL,
  `CategoryId` int(11) DEFAULT NULL,
  PRIMARY KEY (`ProductsCategoryTieId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `productscategorytie` */

/*Table structure for table `productsizetie` */

DROP TABLE IF EXISTS `productsizetie`;

CREATE TABLE `productsizetie` (
  `ProductSizeTieId` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) DEFAULT NULL,
  `SizeId` int(11) DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `Discount` double DEFAULT NULL,
  `Stock` int(11) DEFAULT NULL,
  `Updated` date DEFAULT NULL,
  `UserIdUpdated` int(11) DEFAULT NULL,
  `Deleted` int(11) DEFAULT NULL,
  PRIMARY KEY (`ProductSizeTieId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `productsizetie` */

/*Table structure for table `relatedproductstie` */

DROP TABLE IF EXISTS `relatedproductstie`;

CREATE TABLE `relatedproductstie` (
  `RelatedProductsTieId` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) DEFAULT NULL,
  `RelatedProductsId` int(11) DEFAULT NULL,
  `UserIdUpdated` int(11) DEFAULT NULL,
  `Deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`RelatedProductsTieId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `relatedproductstie` */

/*Table structure for table `roles` */

DROP TABLE IF EXISTS `roles`;

CREATE TABLE `roles` (
  `RoleId` int(11) NOT NULL AUTO_INCREMENT,
  `RoleDiscription` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `roles` */

/*Table structure for table `sizes` */

DROP TABLE IF EXISTS `sizes`;

CREATE TABLE `sizes` (
  `SizeId` int(11) NOT NULL AUTO_INCREMENT,
  `Size` int(11) DEFAULT NULL,
  `Updated` date DEFAULT NULL,
  `UserIdUpdated` int(11) DEFAULT NULL,
  `Deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`SizeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sizes` */

/*Table structure for table `userproductrating` */

DROP TABLE IF EXISTS `userproductrating`;

CREATE TABLE `userproductrating` (
  `UserProductRatingId` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `ProductId` int(11) DEFAULT NULL,
  `Rating` int(11) DEFAULT NULL,
  PRIMARY KEY (`UserProductRatingId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `userproductrating` */

/*Table structure for table `userproductreview` */

DROP TABLE IF EXISTS `userproductreview`;

CREATE TABLE `userproductreview` (
  `UserProductReviewId` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) DEFAULT NULL,
  `ReviewId` tinytext,
  `UserIdUpdated` int(11) DEFAULT NULL,
  `Deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`UserProductReviewId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `userproductreview` */

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `UserGuId` int(11) DEFAULT NULL,
  `FullName` varchar(20) DEFAULT NULL,
  `Email` varchar(30) DEFAULT NULL,
  `RoleId` int(11) DEFAULT NULL,
  `ValidEmail` tinyint(1) DEFAULT '0',
  `LastActive` date DEFAULT NULL,
  `ContactViaEmail` tinyint(1) DEFAULT NULL,
  `FileId` int(11) DEFAULT NULL,
  `Deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `users` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
