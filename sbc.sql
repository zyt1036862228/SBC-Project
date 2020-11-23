-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 06, 2020 at 04:18 PM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sbc`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `EmpID` varchar(5) NOT NULL,
  `Name` varchar(20) NOT NULL,
  `Hash` varchar(64) NOT NULL,
  `Master` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`EmpID`, `Name`, `Hash`, `Master`) VALUES
('E0001', 'Johnny', '21232f297a57a5a743894a0e4a801fc3', 1),
('E0002', 'Ali', '21232f297a57a5a743894a0e4a801fc3', 0),
('E0003', 'Abu', '21232f297a57a5a743894a0e4a801fc3', 0);

-- --------------------------------------------------------

--
-- Table structure for table `booking`
--

CREATE TABLE `booking` (
  `BookingID` varchar(5) NOT NULL,
  `CustomerPhoneNo` varchar(11) NOT NULL,
  `BookingDate` varchar(10) NOT NULL,
  `DepartLocation` varchar(30) NOT NULL,
  `ArrivalLocation` varchar(30) NOT NULL,
  `EmpID` varchar(5) NOT NULL,
  `status` varchar(50) DEFAULT NULL,
  `passengerNumber` int(2) NOT NULL,
  `remarks` varchar(100) DEFAULT NULL,
  `modified` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `booking`
--

INSERT INTO `booking` (`BookingID`, `CustomerPhoneNo`, `BookingDate`, `DepartLocation`, `ArrivalLocation`, `EmpID`, `status`, `passengerNumber`, `remarks`, `modified`) VALUES
('B0001', '0176254522', '06/11/2020', 'Kuala Lumpur', 'Johor', 'E0002', 'Booked but not paid', 10, 'Lunch provided by customer', 0),
('B0002', '0176254522', '06/11/2020', 'Subang', 'Klang', 'E0003', 'Booked but not paid', 15, 'Call the customer 10 mins before reaching pickup location', 1),
('B0003', '0115228896', '06/11/2020', 'Kelantan', 'Perak', 'E0002', 'Booked but not paid', 12, '2 stops during the journey', 0),
('B0004', '0115228896', '06/11/2020', 'KLIA', 'KLCC', 'E0003', 'Requested', 6, 'Carrying luggage along', 0);

-- --------------------------------------------------------

--
-- Table structure for table `bus`
--

CREATE TABLE `bus` (
  `NumberPlate` varchar(7) NOT NULL,
  `Category` varchar(30) NOT NULL,
  `Specification` varchar(50) NOT NULL,
  `PassengerPermit` varchar(10) NOT NULL,
  `PermitValidity` varchar(21) NOT NULL,
  `OwnerIC` varchar(12) NOT NULL,
  `status` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bus`
--

INSERT INTO `bus` (`NumberPlate`, `Category`, `Specification`, `PassengerPermit`, `PermitValidity`, `OwnerIC`, `status`) VALUES
('ADK5506', 'Factory Bus', '30 seats factory bus transporting workers to area ', 'P7460', '01/07/2022-01/07/2022', '990102065522', 'Available'),
('AKK8442', 'Express Bus', '25 seats Express Bus for interstate travel', 'P1142', '01/12/2019-08/12/2020', '990102065522', 'In workshop'),
('JHK7441', 'Passenger Van', '20 seats spacious van with a TV panel in the front', 'P1112', '12/11/2022-12/11/2022', '841225415227', 'Available'),
('JHU1577', 'Coach', 'Luxury coach with comfort seats and mini video dev', 'P7448', '01/12/2023-01/12/2023', '750518441256', 'Available'),
('KGH5226', 'School Bus', 'Simple 30 seats bus with no facilities', 'P4722', '30/09/2022-30/09/2022', '750518441256', 'Available'),
('PFG1263', 'School Bus', 'School bus for travelling within Penang', 'P7744', '01/02/2023-01/02/2023', '990102065522', 'Available'),
('PGH5821', 'Passenger Van', '6 seats van for short distance travelling', 'P8552', '30/03/2022-30/03/2022', '841225415227', 'Available'),
('QKU854', 'Factory Bus', '40 seats factory bus that travels only within Klan', 'P1152', '31/12/2021-31/12/2021', '750518441256', 'Available'),
('WKH4512', 'MPV', 'MVP with 2 seats in front and 3 rows at the back. ', 'P6885', '01/01/2023-01/01/2023', '841225415227', 'Available');

-- --------------------------------------------------------

--
-- Table structure for table `busowner`
--

CREATE TABLE `busowner` (
  `IC` varchar(12) NOT NULL,
  `Name` varchar(20) NOT NULL,
  `Address` varchar(100) NOT NULL,
  `username` varchar(20) NOT NULL,
  `hash` varchar(64) NOT NULL,
  `PhoneNumber` varchar(11) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `busowner`
--

INSERT INTO `busowner` (`IC`, `Name`, `Address`, `username`, `hash`, `PhoneNumber`, `Email`) VALUES
('750518441256', 'Jimmy Choo', 'Jalan Midah 8a, Taman Midah, 56000 Kuala Lumpur, Wilayah Persekutuan Kuala Lumpur', 'jimmy', 'cbbe8cbff00281b4141d02ac4c45c871', '0145965523', 'jimmy@tournow.com'),
('841225415227', 'Syafiq Muhammad', '34, Jalan Nibong 17, Taman Daya, 81100 Johor Bahru, Johor', 'syafiq', 'a68a1c541b2e1cc5ceb3de8b46c21ae3', '0124129886', 'syafiq@travelmalaysia.com'),
('990102065522', 'SBC', 'PT 128899, Batu 3, 1/2, Jalan Kebun, Taman Maznah, 41000 Klang, Selangor', 'SBC', '', '0125526633', 'SBC@internalSBC.com');

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `PhoneNo` varchar(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `IC` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`PhoneNo`, `Name`, `email`, `IC`) VALUES
('0115228896', 'Christan', 'christ@yahoo.com', '750226412568'),
('0148556374', 'Cheong', 'cheong@hotmail.com', '840607562287'),
('0176254522', 'Siti Hawa', 'siti@gmail.com', '781214568444');

-- --------------------------------------------------------

--
-- Table structure for table `driver`
--

CREATE TABLE `driver` (
  `Name` varchar(20) NOT NULL,
  `IC` varchar(12) NOT NULL,
  `License` varchar(8) NOT NULL,
  `PhoneNo` varchar(11) NOT NULL,
  `RegisteredOwnerIC` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `driver`
--

INSERT INTO `driver` (`Name`, `IC`, `License`, `PhoneNo`, `RegisteredOwnerIC`) VALUES
('Hilmi', '621116557445', 'L5200', '0171126694', '841225415227'),
('Charlie', '670611958453', 'L0159', '0149668530', '990102065522'),
('Jensen Fernandez', '741225624593', 'L1148', '01114852233', '750518441256'),
('Jimmy Choo', '750518441256', 'L5521', '0145965523', '750518441256'),
('Alice', '751225085741', 'L1106', '0129856695', '990102065522'),
('Mikhail', '770405085523', 'L7450', '0169865556', '841225415227'),
('Bobby', '840421536528', 'L2411', '0164855693', '990102065522'),
('Brad Choi', '860423085113', 'L9588', '0164256632', '750518441256'),
('Abdul Mahmood', '881215627441', 'L7748', '0168569983', '841225415227');

-- --------------------------------------------------------

--
-- Table structure for table `drivershift`
--

CREATE TABLE `drivershift` (
  `BookingID` varchar(5) NOT NULL,
  `DriverIC` varchar(12) NOT NULL,
  `Date` varchar(10) NOT NULL,
  `BusNumberPlate` varchar(7) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `drivershift`
--

INSERT INTO `drivershift` (`BookingID`, `DriverIC`, `Date`, `BusNumberPlate`) VALUES
('B0001', '670611958453', '06/11/2020', 'PFG1263'),
('B0002', '670611958453', '06/11/2020', 'ADK5506'),
('B0003', '750518441256', '06/11/2020', 'JHU1577');

-- --------------------------------------------------------

--
-- Table structure for table `log`
--

CREATE TABLE `log` (
  `LogID` int(11) NOT NULL,
  `EmpID` varchar(5) NOT NULL,
  `Message` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `log`
--

INSERT INTO `log` (`LogID`, `EmpID`, `Message`) VALUES
(1, 'E0001', 'External provider added!'),
(2, 'E0001', 'Driver added!'),
(3, 'E0001', 'Bus added!!'),
(4, 'E0001', 'External provider added!'),
(5, 'E0001', 'Driver added!'),
(6, 'E0001', 'Bus added!!'),
(7, 'E0001', 'Provider IC 990102065522 info updated'),
(8, 'E0001', 'Provider IC 990102065522 info updated'),
(9, 'E0001', 'Provider IC 990102065522 info updated'),
(10, 'E0001', 'Created a driver record'),
(11, 'E0001', 'Created a driver record'),
(12, 'E0001', 'Created a driver record'),
(13, 'E0001', 'Created a driver record'),
(14, 'E0001', 'Created a driver record'),
(15, 'E0001', 'Created a driver record'),
(16, 'E0001', 'Created a driver record'),
(17, 'E0001', 'Created a bus record'),
(18, 'E0001', 'Created a bus record'),
(19, 'E0001', 'Created a bus record'),
(20, 'E0001', 'Created a bus record'),
(21, 'E0001', 'Created a bus record'),
(22, 'E0001', 'Created a bus record'),
(23, 'E0001', 'Created a bus record'),
(24, 'E0001', 'Added a new customer record'),
(25, 'E0001', 'Added a new customer record'),
(26, 'E0001', 'Added a new customer record'),
(27, 'E0002', 'Assigned a bus & driver to B0001'),
(28, 'E0003', 'Assigned a bus & driver to B0002'),
(29, 'E0003', 'Bus AKK8442 info updated'),
(30, 'E0002', 'B0002 booking info updated'),
(31, 'E0002', 'Created request for externalprovider'),
(32, 'E0003', 'Created request for externalprovider');

-- --------------------------------------------------------

--
-- Table structure for table `maintenance`
--

CREATE TABLE `maintenance` (
  `ID` int(11) NOT NULL,
  `busNumberPlate` varchar(7) NOT NULL,
  `status` varchar(20) NOT NULL,
  `maintenanceStartDate` varchar(8) NOT NULL,
  `maintenanceEndDate` varchar(8) NOT NULL,
  `remarks` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `mileage`
--

CREATE TABLE `mileage` (
  `ID` int(11) NOT NULL,
  `currentMileage` int(6) NOT NULL,
  `nextMileage` int(6) NOT NULL,
  `remarks` varchar(100) DEFAULT NULL,
  `busNumberPlate` varchar(7) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `registration`
--

CREATE TABLE `registration` (
  `PhoneNo` varchar(11) NOT NULL,
  `EmpID` varchar(5) NOT NULL,
  `RegisterDate` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`EmpID`);

--
-- Indexes for table `booking`
--
ALTER TABLE `booking`
  ADD PRIMARY KEY (`BookingID`),
  ADD KEY `FK2_Booking` (`EmpID`);

--
-- Indexes for table `bus`
--
ALTER TABLE `bus`
  ADD PRIMARY KEY (`NumberPlate`),
  ADD KEY `FK1_Bus` (`OwnerIC`);

--
-- Indexes for table `busowner`
--
ALTER TABLE `busowner`
  ADD PRIMARY KEY (`IC`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`PhoneNo`);

--
-- Indexes for table `driver`
--
ALTER TABLE `driver`
  ADD PRIMARY KEY (`IC`),
  ADD KEY `FK1_Driver` (`RegisteredOwnerIC`);

--
-- Indexes for table `drivershift`
--
ALTER TABLE `drivershift`
  ADD PRIMARY KEY (`DriverIC`,`BookingID`),
  ADD KEY `FK2_DriverShift` (`BookingID`),
  ADD KEY `FK3_drivershift` (`BusNumberPlate`);

--
-- Indexes for table `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`LogID`),
  ADD KEY `FK1_LOG` (`EmpID`);

--
-- Indexes for table `maintenance`
--
ALTER TABLE `maintenance`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `maintenance_FK1` (`busNumberPlate`);

--
-- Indexes for table `mileage`
--
ALTER TABLE `mileage`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `mileage_FK1` (`busNumberPlate`);

--
-- Indexes for table `registration`
--
ALTER TABLE `registration`
  ADD PRIMARY KEY (`PhoneNo`,`EmpID`),
  ADD KEY `FK1_Registration` (`EmpID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `log`
--
ALTER TABLE `log`
  MODIFY `LogID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `maintenance`
--
ALTER TABLE `maintenance`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mileage`
--
ALTER TABLE `mileage`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `booking`
--
ALTER TABLE `booking`
  ADD CONSTRAINT `FK2_Booking` FOREIGN KEY (`EmpID`) REFERENCES `admin` (`EmpID`);

--
-- Constraints for table `bus`
--
ALTER TABLE `bus`
  ADD CONSTRAINT `FK1_Bus` FOREIGN KEY (`OwnerIC`) REFERENCES `busowner` (`IC`);

--
-- Constraints for table `driver`
--
ALTER TABLE `driver`
  ADD CONSTRAINT `FK1_Driver` FOREIGN KEY (`RegisteredOwnerIC`) REFERENCES `busowner` (`IC`);

--
-- Constraints for table `drivershift`
--
ALTER TABLE `drivershift`
  ADD CONSTRAINT `FK1_DriverShift` FOREIGN KEY (`DriverIC`) REFERENCES `driver` (`IC`),
  ADD CONSTRAINT `FK2_DriverShift` FOREIGN KEY (`BookingID`) REFERENCES `booking` (`BookingID`),
  ADD CONSTRAINT `FK3_drivershift` FOREIGN KEY (`BusNumberPlate`) REFERENCES `bus` (`NumberPlate`);

--
-- Constraints for table `log`
--
ALTER TABLE `log`
  ADD CONSTRAINT `FK1_LOG` FOREIGN KEY (`EmpID`) REFERENCES `admin` (`EmpID`);

--
-- Constraints for table `maintenance`
--
ALTER TABLE `maintenance`
  ADD CONSTRAINT `maintenance_FK1` FOREIGN KEY (`busNumberPlate`) REFERENCES `bus` (`NumberPlate`);

--
-- Constraints for table `mileage`
--
ALTER TABLE `mileage`
  ADD CONSTRAINT `mileage_FK1` FOREIGN KEY (`busNumberPlate`) REFERENCES `bus` (`NumberPlate`);

--
-- Constraints for table `registration`
--
ALTER TABLE `registration`
  ADD CONSTRAINT `FK1_Registration` FOREIGN KEY (`EmpID`) REFERENCES `admin` (`EmpID`),
  ADD CONSTRAINT `FK2_Registration` FOREIGN KEY (`PhoneNo`) REFERENCES `customer` (`PhoneNo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
