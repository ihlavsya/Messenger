using Messenger.Core.RequestModels;
using System.Threading.Tasks;

namespace Messenger.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(RegisterModel model);
    }
}
