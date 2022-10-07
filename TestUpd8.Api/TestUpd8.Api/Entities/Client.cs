using System;
using TestUpd8.Api.Enums;

namespace TestUpd8.Api.Entities
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public EGender Gender { get; private set; }
        public string Address { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public DateTime BirthDate { get; private set; }


        public static Client New(string name, string cpf, EGender gender, string address, string state, string city, DateTime birthDate) => new Client
        {
            Id = Guid.NewGuid(),
            Name = name,
            Cpf = cpf,
            Gender = gender,
            Address = address,
            State = state,
            City = city,
            BirthDate = birthDate
        };

        public void Update(string name, string cpf, EGender? gender, string address, string state, string city, DateTime? birthDate)
        {
            Name = string.IsNullOrWhiteSpace(name) ? Name : name;
            Cpf = string.IsNullOrWhiteSpace(cpf) ? Cpf : cpf;
            Gender = gender != null ? gender.Value : Gender;
            Address = string.IsNullOrWhiteSpace(address) ? Address : address;
            State = string.IsNullOrWhiteSpace(state) ? State : state;
            City = string.IsNullOrWhiteSpace(city) ? City : city;
            BirthDate = birthDate != null ? birthDate.Value : BirthDate;
        }
    }
}
