﻿using GCall.Domain.Entities.Common;

namespace GCall.Domain.Entities.Definitions
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
