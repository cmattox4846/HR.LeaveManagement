namespace HR.LeaveManagement.Domain.Common
{

    //this is for shared values that may be used in other classes

    public abstract class BaseEntity
    {

        public int Id { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
