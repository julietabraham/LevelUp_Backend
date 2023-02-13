using System.ComponentModel.DataAnnotations;

namespace LevelUp_1.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string? First_Name { get; set; }
        [Required]
        public string? Last_Name { get; set; }
        [Required, MinLength(8)]
        public string? User_Password { get; set; }
        [Required]
        public string? User_Mailid { get; set; }
        [Required, MaxLength(10)]
        public string? User_ContactNo { get; set; }

        public string? User_Country { get; set; }
    }
}
