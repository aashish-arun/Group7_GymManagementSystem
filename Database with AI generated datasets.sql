CREATE DATABASE IF NOT EXISTS `CPRG211`;
USE `CPRG211`;

CREATE TABLE IF NOT EXISTS `staff` (
  `id` INT NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `phone_number` VARCHAR(14) NOT NULL,
  `email` VARCHAR(50) NOT NULL,
  `job_title` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`),
  CHECK (`phone_number` REGEXP '^\\([0-9]{3}\\) [0-9]{3}-[0-9]{4}$'),
  CHECK (`email` REGEXP '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$')
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

INSERT INTO `staff` (`id`, `first_name`, `last_name`, `phone_number`, `email`, `job_title`) VALUES
(1, 'Alice', 'Johnson', '(321) 123-4567', 'alice.johnson@example.com', 'Gym Manager'),
(2, 'Bob', 'Smith', '(321) 234-5678', 'bob.smith@example.com', 'Front Desk Receptionist'),
(3, 'Carol', 'Williams', '(321) 345-6789', 'carol.williams@example.com', 'Fitness Technician'),
(4, 'David', 'Brown', '(321) 456-7890', 'david.brown@example.com', 'Gym Supervisor'),
(5, 'Eva', 'Jones', '(321) 567-8901', 'eva.jones@example.com', 'HR Specialist'),
(6, 'Frank', 'Garcia', '(321) 678-9012', 'frank.garcia@example.com', 'IT Support'),
(7, 'Grace', 'Miller', '(321) 789-0123', 'grace.miller@example.com', 'Gym Accountant'),
(8, 'Henry', 'Martinez', '(321) 890-1234', 'henry.martinez@example.com', 'Security Officer'),
(9, 'Ivy', 'Rodriguez', '(321) 901-2345', 'ivy.rodriguez@example.com', 'Cleaning Staff'),
(10, 'Jack', 'Lee', '(321) 012-3456', 'jack.lee@example.com', 'Fitness Technician');


CREATE DATABASE IF NOT EXISTS `CPRG211`;
USE `CPRG211`;

CREATE TABLE IF NOT EXISTS `trainer` (
  `id` INT NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `phone_number` VARCHAR(14) NOT NULL,
  `email` VARCHAR(50) NOT NULL,
  `speciality` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`),
  CHECK (`phone_number` REGEXP '^\\([0-9]{3}\\) [0-9]{3}-[0-9]{4}$'),
  CHECK (`email` REGEXP '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$')
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

INSERT INTO `trainer` (`id`, `first_name`, `last_name`, `phone_number`, `email`, `speciality`) VALUES
(1, 'James', 'Smith', '(321) 123-4567', 'james.smith@example.com', 'Strength Training'),
(2, 'Emily', 'Johnson', '(321) 234-5678', 'emily.johnson@example.com', 'Yoga Instructor'),
(3, 'Michael', 'Williams', '(321) 345-6789', 'michael.williams@example.com', 'Cardio Training'),
(4, 'Sarah', 'Brown', '(321) 456-7890', 'sarah.brown@example.com', 'Pilates Instructor'),
(5, 'David', 'Jones', '(321) 567-8901', 'david.jones@example.com', 'CrossFit Trainer'),
(6, 'Laura', 'Garcia', '(321) 678-9012', 'laura.garcia@example.com', 'Zumba Instructor'),
(7, 'Daniel', 'Miller', '(321) 789-0123', 'daniel.miller@example.com', 'Boxing Coach'),
(8, 'Sophia', 'Martinez', '(321) 890-1234', 'sophia.martinez@example.com', 'Swimming Coach'),
(9, 'Robert', 'Rodriguez', '(321) 901-2345', 'robert.rodriguez@example.com', 'Personal Trainer'),
(10, 'Olivia', 'Lee', '(321) 012-3456', 'olivia.lee@example.com', 'Group Fitness Instructor');

CREATE DATABASE IF NOT EXISTS `CPRG211`;
USE `CPRG211`;

CREATE TABLE IF NOT EXISTS `customer` (
  `id` INT NOT NULL,
  `first_name` VARCHAR(50) NOT NULL,
  `last_name` VARCHAR(50) NOT NULL,
  `phone_number` VARCHAR(14) NOT NULL,
  `email` VARCHAR(50) NOT NULL,
  `membership_type` ENUM('Basic', 'Premium', 'VIP') NOT NULL,
  `membership_status` ENUM('Active', 'Inactive') NOT NULL,
  PRIMARY KEY (`id`),
  CHECK (`phone_number` REGEXP '^\\([0-9]{3}\\) [0-9]{3}-[0-9]{4}$'),
  CHECK (`email` REGEXP '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$')
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

INSERT INTO `customer` (`id`, `first_name`, `last_name`, `phone_number`, `email`, `membership_type`, `membership_status`) VALUES
(1, 'Alice', 'Smith', '(123) 456-7890', 'alice@example.com', 'Basic', 'Active'),
(2, 'Bob', 'Johnson', '(987) 654-3210', 'bob@example.com', 'Premium', 'Inactive'),
(3, 'Charlie', 'Brown', '(555) 123-4567', 'charlie@example.com', 'VIP', 'Active'),
(4, 'Diana', 'White', '(555) 222-3333', 'diana@example.com', 'Basic', 'Active'),
(5, 'Ethan', 'Green', '(555) 444-5555', 'ethan@example.com', 'Premium', 'Active'),
(6, 'Fiona', 'Hall', '(555) 666-7777', 'fiona@example.com', 'VIP', 'Inactive'),
(7, 'George', 'Clark', '(555) 888-9999', 'george@example.com', 'Basic', 'Active'),
(8, 'Hannah', 'Adams', '(555) 111-2222', 'hannah@example.com', 'VIP', 'Active'),
(9, 'Ian', 'Nelson', '(555) 333-4444', 'ian@example.com', 'Premium', 'Inactive'),
(10, 'Jenny', 'Moore', '(555) 777-8888', 'jenny@example.com', 'Basic', 'Active');

CREATE TABLE IF NOT EXISTS `appointment` (
  `id` INT NOT NULL,
  `date` DATE NOT NULL,
  `customer_id` INT NOT NULL,
  `trainer_id` INT NOT NULL,
  `scheduled_date` DATE NOT NULL,
  `scheduled_time` ENUM('08:00 AM to 10:00 AM', '10:00 AM to 12:00 PM', '12:00 PM to 02:00 PM', '02:00 PM to 04:00 PM', '04:00 PM to 06:00 PM', '06:00 PM to 08:00 PM') NOT NULL,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`customer_id`) REFERENCES `customer`(`id`) ON DELETE CASCADE,
  FOREIGN KEY (`trainer_id`) REFERENCES `trainer`(`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

INSERT INTO `appointment` (`id`, `date`, `customer_id`, `trainer_id`, `scheduled_date`, `scheduled_time`) VALUES
(1, '2025-04-25', 1, 2, '2025-04-26', '08:00 AM to 10:00 AM'),
(2, '2025-04-25', 2, 4, '2025-04-27', '10:00 AM to 12:00 PM'),
(3, '2025-04-25', 3, 1, '2025-04-28', '12:00 PM to 02:00 PM'),
(4, '2025-04-25', 4, 3, '2025-04-26', '02:00 PM to 04:00 PM'),
(5, '2025-04-25', 5, 6, '2025-04-29', '04:00 PM to 06:00 PM'),
(6, '2025-04-25', 6, 7, '2025-04-30', '06:00 PM to 08:00 PM'),
(7, '2025-04-25', 7, 5, '2025-05-01', '08:00 AM to 10:00 AM'),
(8, '2025-04-25', 8, 8, '2025-05-02', '10:00 AM to 12:00 PM'),
(9, '2025-04-25', 9, 9, '2025-05-03', '12:00 PM to 02:00 PM'),
(10, '2025-04-25', 10, 10, '2025-05-04', '02:00 PM to 04:00 PM');