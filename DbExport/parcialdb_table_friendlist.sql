
-- --------------------------------------------------------

--
-- Table structure for table `friendlist`
--

CREATE TABLE `friendlist` (
  `Id` int(11) NOT NULL,
  `Solicitante` varchar(11) NOT NULL,
  `Invitado` varchar(11) NOT NULL,
  `Estado` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `friendlist`
--

INSERT INTO `friendlist` (`Id`, `Solicitante`, `Invitado`, `Estado`) VALUES
(33, 'facundo', 'Carlos', 1),
(34, 'gonzalo', 'hugo', 1),
(36, 'gonzalo', 'facundo', 1),
(38, 'ledesma', 'gonzalo', 1);
