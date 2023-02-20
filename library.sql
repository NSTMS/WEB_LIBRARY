-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 20 Lut 2023, 20:39
-- Wersja serwera: 10.4.21-MariaDB
-- Wersja PHP: 8.0.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `library`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `books`
--

CREATE TABLE `books` (
  `ID` int(11) NOT NULL,
  `Authors` varchar(255) COLLATE utf8mb4_polish_ci NOT NULL,
  `Title` varchar(255) COLLATE utf8mb4_polish_ci NOT NULL,
  `RelaseDate` char(10) COLLATE utf8mb4_polish_ci NOT NULL,
  `ISBN` char(20) COLLATE utf8mb4_polish_ci NOT NULL,
  `Format` char(3) COLLATE utf8mb4_polish_ci NOT NULL,
  `Pages` smallint(6) NOT NULL,
  `Description` varchar(255) COLLATE utf8mb4_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Zrzut danych tabeli `books`
--

INSERT INTO `books` (`ID`, `Authors`, `Title`, `RelaseDate`, `ISBN`, `Format`, `Pages`, `Description`) VALUES
(65, 'Jan Kochanowski', 'Na dom w Czarnolesie', '04.02.1521', '8276132187', 'pdf', 1, 'Nowa pozycja od Jana Kochanowskiego'),
(66, 'Juliusz Słowacki', 'Balladyna', '31.12.1812', '9821379217', 'pap', 321, 'Dramat od znanego pisarza'),
(67, 'William Szekspir', 'Makbet', '21.03.1782', '79234293874938274', 'pdf', 123, 'Książka autorstwa znanego pisarza'),
(68, 'Adam Mickiewicz', 'Konrad Wallenrod', '31.12.1799', '970834328423213', 'pdf', 100, 'Konrad co udawał Konrada Wallenroda'),
(69, 'Johann Wolfgang Goethe', 'Cierpienia młodego Wertera ', '18.03.1867', '01892302137', 'pap', 457, 'Cierpienia młodego Wertera jak sam tytuł nam wskazuje');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `logins`
--

CREATE TABLE `logins` (
  `ID` int(11) NOT NULL,
  `user` char(20) COLLATE utf8mb4_polish_ci NOT NULL,
  `password` char(255) COLLATE utf8mb4_polish_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_polish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Zrzut danych tabeli `logins`
--

INSERT INTO `logins` (`ID`, `user`, `password`, `email`) VALUES
(42, 'test', '9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08', '');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`ID`);

--
-- Indeksy dla tabeli `logins`
--
ALTER TABLE `logins`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `books`
--
ALTER TABLE `books`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=70;

--
-- AUTO_INCREMENT dla tabeli `logins`
--
ALTER TABLE `logins`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
