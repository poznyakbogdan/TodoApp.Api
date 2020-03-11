using Microsoft.AspNetCore.Identity;

namespace TodoApp.DAL.Models
{
    public class User : IdentityUser
    {
        public string Password { get; set; }
    }
}