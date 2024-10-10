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
