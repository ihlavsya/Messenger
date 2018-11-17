using Messenger.Domain.Models;
using Messenger.Domain.Repositories.Interfaces;

namespace Messenger.Domain.Repositories.Implementations
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(MessengerContext context) : base(context)
        {
            MessengerContext = context;
        }

        public MessengerContext MessengerContext { get; set; }
    }
}
