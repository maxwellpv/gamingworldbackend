namespace GamingWorld.API.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string TypeUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Premiun { get; set; }
    }
}