using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContribution.Domain.Entities
{
    public class Insurer
    {
        public int InsurerId { get; set; }
        public string InsurerCode { get; set; } = null!;
        public string InsurerName { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
            = new List<Policy>();
    }
}
