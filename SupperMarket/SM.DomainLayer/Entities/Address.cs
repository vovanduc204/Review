using SM.InfractureLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Entities
{
    public class Address
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        [Required]
        public string AppUserId { get; private set; }

        public Address()
        {

        }

        public Address(int id, string firstName, string lastName, string street, string city, string state, string zipCode, string appUserId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            AppUserId = appUserId;
        }

        public Address(int id, string firstName, string lastName, string street, string city, string state, string zipCode)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}
