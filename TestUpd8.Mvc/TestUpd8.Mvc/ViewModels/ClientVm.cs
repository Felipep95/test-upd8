﻿using System;

namespace TestUpd8.Mvc.ViewModels
{
    public class ClientVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
