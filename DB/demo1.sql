-- Adminer 4.7.2 MySQL dump

SET NAMES utf8;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET sql_mode = 'NO_AUTO_VALUE_ON_ZERO';

DROP DATABASE IF EXISTS `demo1`;
CREATE DATABASE `demo1` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `demo1`;

DROP TABLE IF EXISTS `todo_item`;
CREATE TABLE `todo_item` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Title` longtext DEFAULT NULL,
  `IsCompleted` bit(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

TRUNCATE `todo_item`;

DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `name` longtext DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

TRUNCATE `user`;
INSERT INTO `user` (`id`, `name`) VALUES
(24,	'Ninh'),
(26,	'Ninh'),
(27,	'Ninh');

-- 2019-09-05 23:42:47
