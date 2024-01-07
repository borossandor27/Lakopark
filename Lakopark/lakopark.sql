-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Jan 07. 14:24
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `lakopark`
--
CREATE DATABASE IF NOT EXISTS `lakopark` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `lakopark`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `epuletek`
--

CREATE TABLE `epuletek` (
  `lakoparkId` int(11) NOT NULL,
  `utcaSzam` int(11) NOT NULL COMMENT 'A lakótelep hanyadk utcája',
  `hazSzam` int(11) NOT NULL COMMENT 'Hanyadik telek az utcában',
  `emelet` int(11) NOT NULL COMMENT 'A ház szintjeinek a számát (értéke 1, 2, vagy 3 lehet, illetve 0, ha a\r\nparcella beépítetlen).'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `epuletek`
--

INSERT INTO `epuletek` (`lakoparkId`, `utcaSzam`, `hazSzam`, `emelet`) VALUES
(1, 1, 1, 2),
(1, 1, 2, 1),
(1, 1, 3, 1),
(1, 1, 6, 3),
(1, 1, 7, 1),
(1, 2, 2, 1),
(1, 2, 3, 2),
(1, 2, 6, 2),
(1, 2, 8, 2),
(1, 3, 2, 1),
(1, 3, 3, 3),
(1, 3, 4, 1),
(1, 3, 5, 3),
(1, 3, 6, 2),
(1, 3, 7, 1),
(1, 3, 8, 1),
(1, 4, 3, 2),
(1, 4, 5, 3),
(1, 4, 6, 2),
(1, 4, 8, 3),
(1, 4, 9, 3),
(1, 5, 1, 1),
(1, 5, 4, 1),
(1, 5, 7, 1),
(1, 5, 8, 3),
(2, 1, 1, 1),
(2, 1, 3, 3),
(2, 1, 5, 2),
(2, 2, 1, 3),
(2, 2, 3, 3),
(2, 2, 4, 3),
(2, 2, 5, 2),
(2, 3, 1, 1),
(2, 3, 2, 3),
(2, 3, 5, 2),
(3, 1, 2, 3),
(3, 1, 3, 1),
(3, 1, 7, 3),
(3, 2, 1, 2),
(3, 2, 2, 2),
(3, 2, 3, 3),
(3, 2, 7, 2),
(3, 3, 2, 1),
(3, 3, 5, 1),
(3, 3, 6, 1),
(3, 3, 7, 3),
(3, 4, 1, 2),
(3, 4, 2, 3),
(3, 4, 3, 2),
(3, 4, 5, 3),
(3, 4, 6, 3);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `lakopark`
--

CREATE TABLE `lakopark` (
  `lakoparkId` int(11) NOT NULL,
  `lakoparkNev` varchar(13) NOT NULL,
  `utcakSzama` int(11) NOT NULL COMMENT 'Az utcakSzama adattag a lakópark utcáinak a számát tárolja',
  `telkekSzama` int(11) NOT NULL COMMENT 'Az utcákban található házak (parcellák) számát tárolja.'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `lakopark`
--

INSERT INTO `lakopark` (`lakoparkId`, `lakoparkNev`, `utcakSzama`, `telkekSzama`) VALUES
(1, 'Puskás Ferenc', 5, 10),
(2, 'Van Gogh', 3, 5),
(3, 'Vivaldi', 4, 7);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `epuletek`
--
ALTER TABLE `epuletek`
  ADD KEY `fk_lakopark_epuletek` (`lakoparkId`);

--
-- A tábla indexei `lakopark`
--
ALTER TABLE `lakopark`
  ADD PRIMARY KEY (`lakoparkId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `lakopark`
--
ALTER TABLE `lakopark`
  MODIFY `lakoparkId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `epuletek`
--
ALTER TABLE `epuletek`
  ADD CONSTRAINT `fk_lakopark_epulet` FOREIGN KEY (`lakoparkId`) REFERENCES `lakopark` (`lakoparkid`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
