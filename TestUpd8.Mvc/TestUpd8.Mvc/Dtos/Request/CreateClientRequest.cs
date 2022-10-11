using System;
using System.ComponentModel.DataAnnotations;
using TestUpd8.Mvc.Enums;

namespace TestUpd8.Mvc.DTOs.Request
{
    public class CreateClientRequest
    {

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cpf is required.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public EGender Gender { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "BirthDate is required.")]
        public DateTime BirthDate { get; set; }
    }
}
