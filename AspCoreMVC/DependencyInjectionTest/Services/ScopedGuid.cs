namespace DependencyInjectionTest.Services
{
    public class ScopedGuid : IScopedGuid
    {
        private readonly Guid Id;
        public ScopedGuid()
        {
            Id = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return Id.ToString();
        }
    }
}
