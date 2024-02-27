using GCall.Domain.Entities.Common;

namespace GCall.Domain.Entities.Definitions
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public Guid? MainDepartmentId { get; set; }
        public ICollection<BranchDepartment> BranchesDepartments { get; set; }
    }
}
