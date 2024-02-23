using GCall.Domain.Entities.Common;

namespace GCall.Domain.Entities.Definitions
{
    public  class Customer : BaseEntity
    {
        public string? Name { get; set; }
        public string Title { get; set; }
        public int Code { get; set; }
    }
}
