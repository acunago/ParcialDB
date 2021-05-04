
-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

CREATE TABLE `accounts` (
  `Id` int(10) NOT NULL,
  `usern` varchar(10) NOT NULL,
  `passw` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`Id`, `usern`, `passw`) VALUES
(1, 'gonzalo', '12345'),
(3, 'Hugo', '1234'),
(4, 'Facundo', 'qwert'),
(5, 'Juan', 'Maggi'),
(6, 'Nicolas', 'Cano'),
(8, 'pepe', '1234'),
(13, 'Matilda', 'testeando'),
(14, 'algo', 'mucho'),
(15, 'ledesma', 'azucar'),
(16, 'carlos', 'saul');
