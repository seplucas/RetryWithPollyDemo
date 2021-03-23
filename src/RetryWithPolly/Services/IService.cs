using System.Threading.Tasks;

namespace RetryWithPolly.Services
{
    public interface IService
    {
        Task CallApi();
    }
}
