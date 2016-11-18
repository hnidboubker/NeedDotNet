namespace NeedDotNet.Server.Domain.Entities
{
    public class UserPerson
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public long PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}