namespace AspCoreMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public int GroupId { get; set; }
        public string UserState { get; set; }

    }
}
