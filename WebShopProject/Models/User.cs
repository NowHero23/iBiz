using System.Text.Json.Serialization;

namespace WebShopProject.Models
{
    public class User
    {
        public int Id { get; set; } //Url
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public string Login { get; set; }

        public string? Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; } //hash password

        public DateTime RegisterDate { get; set; }

        public string? AvatarImg { get; set; }
        public string? AvatarAlt { get; set; }
    }
}
