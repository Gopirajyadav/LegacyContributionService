using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContribution.Domain.Entities
{
    public class Contribution
    {
        public int ContributionId { get; set; }
        public int PolicyId { get; set; }
        public decimal PremiumAmount { get; set; }
        public DateTime ContributionDate { get; set; }
        public string TransactionRef { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Policy Policy { get; set; } = null!;
    }
}
