using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Data.DataModels;

[Table("UserRolesByUser")]
public class UserRolesByUser
{
    [Key, StringLength(50), Column(TypeName = "varchar(50)")]
    public string UserId { get; set; }
    
    [Key, StringLength(50), Column(TypeName = "varchar(50)")]
    public string RoleId { get; set; }
    
    [Required]
    public DateTime OwnedUtcDate { get; set; }
    
    public virtual User User { get; set; }
    
    public virtual UserRole UserRole { get; set; }
}