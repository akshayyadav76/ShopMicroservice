using Shop.Web.Models;

namespace Shop.Web.Service.IService
{
    public interface IBaseService :IDisposable
    {

        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
