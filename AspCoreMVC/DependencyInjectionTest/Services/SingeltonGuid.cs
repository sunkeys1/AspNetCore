namespace DependencyInjectionTest.Services
{
    public class SingeltonGuid : ISingeltonGuid
    {
        private readonly Guid Id;
        public SingeltonGuid()
        {
            Id = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return Id.ToString();
        }
    }
}
