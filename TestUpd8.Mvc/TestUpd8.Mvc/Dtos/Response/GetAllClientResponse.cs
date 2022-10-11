using System.Collections.Generic;
using TestUpd8.Mvc.ViewModels;

namespace TestUpd8.Api.DTOs.Response
{
    public class GetAllClientResponse
    {
        public List<ClientVm> Clients { get; set; } = new List<ClientVm>();
    }
}
