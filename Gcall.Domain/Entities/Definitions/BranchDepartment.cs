using GCall.Domain.Entities.Common;

namespace GCall.Domain.Entities.Definitions
{
    public class BranchDepartment : BaseEntity
    {
        public Guid BranchId { get; set; }
        public Guid DepartmentId { get; set; }
        public Branch Branch { get; set; }
        public Department Department { get; set; }
    }
}
