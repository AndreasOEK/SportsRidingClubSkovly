using Module.User.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.User.Domain.Test.Fakes
{
    public class FakeUser : Module.User.Domain.Entity.User
    {
        public FakeUser(Guid id) : base()
        {
            Id = id;
        }
    }
}
