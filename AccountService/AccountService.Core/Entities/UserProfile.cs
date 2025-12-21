using Fishing.Core.Database;

namespace AccountService.Core.Entities;

public class UserProfile : IAuditableEntity
{
    public int UserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsBlocked { get; set; }
    public string TaxUseCode { get; set; }
    public string TaxExemptId { get; set; }
    public DateTime? TaxExemptExpirationDate { get; set; }
    public string Notes { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<BillingAddress> BillingAddresses { get; set; }
    public virtual ICollection<ShippingAddress> ShippingAddresses { get; set; }
}