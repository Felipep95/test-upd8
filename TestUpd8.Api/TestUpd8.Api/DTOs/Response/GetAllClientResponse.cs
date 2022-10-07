using System.Collections.Generic;
using TestUpd8.Api.ViewModels;

namespace TestUpd8.Api.DTOs.Response
{
    public class GetAllClientResponse : BaseResponse
    {
        public List<ClientListVm> Clients { get; set; } = new List<ClientListVm>();
    }
}
