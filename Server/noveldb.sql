-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Apr 25, 2019 at 05:05 PM
-- Server version: 5.6.41
-- PHP Version: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `noveldb`
--
CREATE DATABASE IF NOT EXISTS `noveldb` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `noveldb`;

-- --------------------------------------------------------

--
-- Table structure for table `progress`
--

CREATE TABLE `progress` (
  `id` int(10) UNSIGNED NOT NULL,
  `id_user` int(10) UNSIGNED NOT NULL,
  `save_data` text COMMENT 'something to save for test'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `progress`
--

INSERT INTO `progress` (`id`, `id_user`, `save_data`) VALUES
(3, 15, '{\"version\":1,\"savePoints\":[\"{\\n    \\\"savePointKey\\\": \\\"Start\\\",\\n    \\\"savePointDescription\\\": \\\"13:11 25 April, 2019\\\",\\n    \\\"sceneName\\\": \\\"GameTestScene\\\",\\n    \\\"saveDataItems\\\": [\\n        {\\n            \\\"dataType\\\": \\\"FlowchartData\\\",\\n            \\\"data\\\": \\\"{\\\\\\\"flowchartName\\\\\\\":\\\\\\\"Flowchart\\\\\\\",\\\\\\\"stringVars\\\\\\\":[],\\\\\\\"intVars\\\\\\\":[],\\\\\\\"floatVars\\\\\\\":[],\\\\\\\"boolVars\\\\\\\":[{\\\\\\\"key\\\\\\\":\\\\\\\"has_umbrella\\\\\\\",\\\\\\\"value\\\\\\\":true},{\\\\\\\"key\\\\\\\":\\\\\\\"burnt_bottom\\\\\\\",\\\\\\\"value\\\\\\\":false}]}\\\"\\n        }\\n    ]\\n}\",\"{\\n    \\\"savePointKey\\\": \\\"Start\\\",\\n    \\\"savePointDescription\\\": \\\"13:11 25 April, 2019\\\",\\n    \\\"sceneName\\\": \\\"GameTestScene\\\",\\n    \\\"saveDataItems\\\": [\\n        {\\n            \\\"dataType\\\": \\\"FlowchartData\\\",\\n            \\\"data\\\": \\\"{\\\\\\\"flowchartName\\\\\\\":\\\\\\\"Flowchart\\\\\\\",\\\\\\\"stringVars\\\\\\\":[],\\\\\\\"intVars\\\\\\\":[],\\\\\\\"floatVars\\\\\\\":[],\\\\\\\"boolVars\\\\\\\":[{\\\\\\\"key\\\\\\\":\\\\\\\"has_umbrella\\\\\\\",\\\\\\\"value\\\\\\\":true},{\\\\\\\"key\\\\\\\":\\\\\\\"burnt_bottom\\\\\\\",\\\\\\\"value\\\\\\\":false}]}\\\"\\n        }\\n    ]\\n}\",\"{\\n    \\\"savePointKey\\\": \\\"Queens Chamber\\\",\\n    \\\"savePointDescription\\\": \\\"13:17 25 April, 2019\\\",\\n    \\\"sceneName\\\": \\\"GameTestScene\\\",\\n    \\\"saveDataItems\\\": [\\n        {\\n            \\\"dataType\\\": \\\"FlowchartData\\\",\\n            \\\"data\\\": \\\"{\\\\\\\"flowchartName\\\\\\\":\\\\\\\"Flowchart\\\\\\\",\\\\\\\"stringVars\\\\\\\":[],\\\\\\\"intVars\\\\\\\":[],\\\\\\\"floatVars\\\\\\\":[],\\\\\\\"boolVars\\\\\\\":[{\\\\\\\"key\\\\\\\":\\\\\\\"has_umbrella\\\\\\\",\\\\\\\"value\\\\\\\":true},{\\\\\\\"key\\\\\\\":\\\\\\\"burnt_bottom\\\\\\\",\\\\\\\"value\\\\\\\":false}]}\\\"\\n        }\\n    ]\\n}\",\"{\\n    \\\"savePointKey\\\": \\\"Duck Down\\\",\\n    \\\"savePointDescription\\\": \\\"13:17 25 April, 2019\\\",\\n    \\\"sceneName\\\": \\\"GameTestScene\\\",\\n    \\\"saveDataItems\\\": [\\n        {\\n            \\\"dataType\\\": \\\"FlowchartData\\\",\\n            \\\"data\\\": \\\"{\\\\\\\"flowchartName\\\\\\\":\\\\\\\"Flowchart\\\\\\\",\\\\\\\"stringVars\\\\\\\":[],\\\\\\\"intVars\\\\\\\":[],\\\\\\\"floatVars\\\\\\\":[],\\\\\\\"boolVars\\\\\\\":[{\\\\\\\"key\\\\\\\":\\\\\\\"has_umbrella\\\\\\\",\\\\\\\"value\\\\\\\":true},{\\\\\\\"key\\\\\\\":\\\\\\\"burnt_bottom\\\\\\\",\\\\\\\"value\\\\\\\":false}]}\\\"\\n        }\\n    ]\\n}\"],\"rewoundSavePoints\":[]}'),
(4, 17, NULL),
(5, 19, NULL),
(6, 20, '{\"version\":1,\"savePoints\":[\"{\\n    \\\"savePointKey\\\": \\\"Start\\\",\\n    \\\"savePointDescription\\\": \\\"12:39 25 April, 2019\\\",\\n    \\\"sceneName\\\": \\\"GameTestScene\\\",\\n    \\\"saveDataItems\\\": [\\n        {\\n            \\\"dataType\\\": \\\"FlowchartData\\\",\\n            \\\"data\\\": \\\"{\\\\\\\"flowchartName\\\\\\\":\\\\\\\"Flowchart\\\\\\\",\\\\\\\"stringVars\\\\\\\":[],\\\\\\\"intVars\\\\\\\":[],\\\\\\\"floatVars\\\\\\\":[],\\\\\\\"boolVars\\\\\\\":[{\\\\\\\"key\\\\\\\":\\\\\\\"has_umbrella\\\\\\\",\\\\\\\"value\\\\\\\":true},{\\\\\\\"key\\\\\\\":\\\\\\\"burnt_bottom\\\\\\\",\\\\\\\"value\\\\\\\":false}]}\\\"\\n        }\\n    ]\\n}\",\"{\\n    \\\"savePointKey\\\": \\\"Queens Chamber\\\",\\n    \\\"savePointDescription\\\": \\\"12:40 25 April, 2019\\\",\\n    \\\"sceneName\\\": \\\"GameTestScene\\\",\\n    \\\"saveDataItems\\\": [\\n        {\\n            \\\"dataType\\\": \\\"FlowchartData\\\",\\n            \\\"data\\\": \\\"{\\\\\\\"flowchartName\\\\\\\":\\\\\\\"Flowchart\\\\\\\",\\\\\\\"stringVars\\\\\\\":[],\\\\\\\"intVars\\\\\\\":[],\\\\\\\"floatVars\\\\\\\":[],\\\\\\\"boolVars\\\\\\\":[{\\\\\\\"key\\\\\\\":\\\\\\\"has_umbrella\\\\\\\",\\\\\\\"value\\\\\\\":true},{\\\\\\\"key\\\\\\\":\\\\\\\"burnt_bottom\\\\\\\",\\\\\\\"value\\\\\\\":false}]}\\\"\\n        }\\n    ]\\n}\",\"{\\n    \\\"savePointKey\\\": \\\"Duck Down\\\",\\n    \\\"savePointDescription\\\": \\\"12:40 25 April, 2019\\\",\\n    \\\"sceneName\\\": \\\"GameTestScene\\\",\\n    \\\"saveDataItems\\\": [\\n        {\\n            \\\"dataType\\\": \\\"FlowchartData\\\",\\n            \\\"data\\\": \\\"{\\\\\\\"flowchartName\\\\\\\":\\\\\\\"Flowchart\\\\\\\",\\\\\\\"stringVars\\\\\\\":[],\\\\\\\"intVars\\\\\\\":[],\\\\\\\"floatVars\\\\\\\":[],\\\\\\\"boolVars\\\\\\\":[{\\\\\\\"key\\\\\\\":\\\\\\\"has_umbrella\\\\\\\",\\\\\\\"value\\\\\\\":true},{\\\\\\\"key\\\\\\\":\\\\\\\"burnt_bottom\\\\\\\",\\\\\\\"value\\\\\\\":false}]}\\\"\\n        }\\n    ]\\n}\"],\"rewoundSavePoints\":[]}'),
(7, 33, '{\"version\":1,\"savePoints\":[\"{\\n    \\\"savePointKey\\\": \\\"Start\\\",\\n    \\\"savePointDescription\\\": \\\"12:39 25 April, 2019\\\",\\n    \\\"sceneName\\\": \\\"GameTestScene\\\",\\n    \\\"saveDataItems\\\": [\\n        {\\n            \\\"dataType\\\": \\\"FlowchartData\\\",\\n            \\\"data\\\": \\\"{\\\\\\\"flowchartName\\\\\\\":\\\\\\\"Flowchart\\\\\\\",\\\\\\\"stringVars\\\\\\\":[],\\\\\\\"intVars\\\\\\\":[],\\\\\\\"floatVars\\\\\\\":[],\\\\\\\"boolVars\\\\\\\":[{\\\\\\\"key\\\\\\\":\\\\\\\"has_umbrella\\\\\\\",\\\\\\\"value\\\\\\\":true},{\\\\\\\"key\\\\\\\":\\\\\\\"burnt_bottom\\\\\\\",\\\\\\\"value\\\\\\\":false}]}\\\"\\n        }\\n    ]\\n}\",\"{\\n    \\\"savePointKey\\\": \\\"Queens Chamber\\\",\\n    \\\"savePointDescription\\\": \\\"12:40 25 April, 2019\\\",\\n    \\\"sceneName\\\": \\\"GameTestScene\\\",\\n    \\\"saveDataItems\\\": [\\n        {\\n            \\\"dataType\\\": \\\"FlowchartData\\\",\\n            \\\"data\\\": \\\"{\\\\\\\"flowchartName\\\\\\\":\\\\\\\"Flowchart\\\\\\\",\\\\\\\"stringVars\\\\\\\":[],\\\\\\\"intVars\\\\\\\":[],\\\\\\\"floatVars\\\\\\\":[],\\\\\\\"boolVars\\\\\\\":[{\\\\\\\"key\\\\\\\":\\\\\\\"has_umbrella\\\\\\\",\\\\\\\"value\\\\\\\":true},{\\\\\\\"key\\\\\\\":\\\\\\\"burnt_bottom\\\\\\\",\\\\\\\"value\\\\\\\":false}]}\\\"\\n        }\\n    ]\\n}\",\"{\\n    \\\"savePointKey\\\": \\\"Duck Down\\\",\\n    \\\"savePointDescription\\\": \\\"12:40 25 April, 2019\\\",\\n    \\\"sceneName\\\": \\\"GameTestScene\\\",\\n    \\\"saveDataItems\\\": [\\n        {\\n            \\\"dataType\\\": \\\"FlowchartData\\\",\\n            \\\"data\\\": \\\"{\\\\\\\"flowchartName\\\\\\\":\\\\\\\"Flowchart\\\\\\\",\\\\\\\"stringVars\\\\\\\":[],\\\\\\\"intVars\\\\\\\":[],\\\\\\\"floatVars\\\\\\\":[],\\\\\\\"boolVars\\\\\\\":[{\\\\\\\"key\\\\\\\":\\\\\\\"has_umbrella\\\\\\\",\\\\\\\"value\\\\\\\":true},{\\\\\\\"key\\\\\\\":\\\\\\\"burnt_bottom\\\\\\\",\\\\\\\"value\\\\\\\":false}]}\\\"\\n        }\\n    ]\\n}\"],\"rewoundSavePoints\":[]}');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(10) UNSIGNED NOT NULL,
  `login` varchar(32) NOT NULL,
  `password` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `login`, `password`) VALUES
(15, 'test9', '1234'),
(17, 'test10', '1234'),
(19, 'test11', '1234'),
(20, 'asd', 'asd'),
(33, 's6', 'f');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `progress`
--
ALTER TABLE `progress`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_user` (`id_user`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `login` (`login`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `progress`
--
ALTER TABLE `progress`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `progress`
--
ALTER TABLE `progress`
  ADD CONSTRAINT `user_to_progress` FOREIGN KEY (`id_user`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
