namespace NeedDotNet.Server.Domain.Entities
{
    public class RoleGroup
    {
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }

        public long GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}