using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzmoonYar.API.Dtos;

public class UserDto
{
    [ReadOnly(true)]
    public Guid Guid { get; set; }
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
    [Required]
    [MaxLength(50)]
    public string Password { get; set; }
}