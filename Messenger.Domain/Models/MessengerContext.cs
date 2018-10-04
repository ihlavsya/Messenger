using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.Domain.Models
{
    public class MessengerContext : IdentityDbContext<User>
    {
        public MessengerContext(DbContextOptions<MessengerContext> options): base(options)
        {
        }
    }
}
