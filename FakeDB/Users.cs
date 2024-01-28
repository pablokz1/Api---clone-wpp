namespace Api___clone_wpp.FakeDB
{
    public class Users(Guid id, string name)
    {
        public Guid Id { get; private set; } = id;
        public string Name { get; private set; } = name;
    }
}
