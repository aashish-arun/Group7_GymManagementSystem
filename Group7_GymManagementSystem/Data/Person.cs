﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Group7_GymManagementSystem.Data
{
    // Abstract class Person from which the Customer, Trainer and Staff will inherit
    public class Person
    {
        // Properties for person
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        // Default constructor
        public Person() { }

        // Constructor to initialize all properties
        public Person(int id, string firstName, string lastName, string phoneNumber, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
