using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class UserPhoneNumber : BaseEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public User User { get; set; }
    }
}
