
-- --------------------------------------------------------

--
-- Table structure for table `highscores`
--

CREATE TABLE `highscores` (
  `Id` int(10) NOT NULL,
  `user` varchar(10) NOT NULL,
  `score` int(10) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `highscores`
--

INSERT INTO `highscores` (`Id`, `user`, `score`) VALUES
(10, 'ledesma', 1234),
(11, 'facundo', 4123);
