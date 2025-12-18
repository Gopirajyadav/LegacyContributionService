using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContribution.Domain.Entities
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyNumber { get; set; } = null!;
        public int InsurerId { get; set; }
        public string PolicyType { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<Contribution> Contributions { get; set; }
            = new List<Contribution>();
    }
}
