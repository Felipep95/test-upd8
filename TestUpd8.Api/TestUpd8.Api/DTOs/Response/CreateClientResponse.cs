using TestUpd8.Api.ViewModels;

namespace TestUpd8.Api.DTOs.Response
{
    public class GetClientByIdResponse : BaseResponse
    {
        public ClientVm Client { get; set; }
    }
}
