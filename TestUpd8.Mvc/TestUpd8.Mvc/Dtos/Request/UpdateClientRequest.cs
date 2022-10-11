using System;
using TestUpd8.Mvc.Enums;

namespace TestUpd8.Mvc.DTOs.Request
{
    public class UpdateClientRequest
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public EGender Gender { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
