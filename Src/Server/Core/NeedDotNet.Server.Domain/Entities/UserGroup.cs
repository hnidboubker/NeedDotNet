namespace NeedDotNet.Server.Domain.Entities
{
    public class UserGroup
    {

        public long UserId { get; set; }
        public virtual User User { get; set; }

        public long GroupId { get; set; }
        public virtual Group Group { get; set; }
        
    }
}