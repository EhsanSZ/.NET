namespace Core.Entities.Security;
public class RolePermission
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
    public int PermissionId { get; set; }
    public virtual Permission Permission { get; set; }
}