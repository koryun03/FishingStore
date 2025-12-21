using Fishing.Core.Database;
using Microsoft.AspNetCore.Identity;

namespace AccountService.Core.Entities;

public class User : IdentityUser<Guid>, IAuditableEntity
{
    public User()
    {
        UserProfile = new UserProfile();
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool HasPayPalAccount { get; set; }
    public virtual UserProfile UserProfile { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; }
    public virtual ICollection<CreditCard> CreditCards { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<PaypalAccount> PaypalAccounts { get; set; }
    public virtual ICollection<CouponCodeApplicableUser> Coupons { get; set; }
    public virtual UserDevice UserDevice { get; set; }

    public bool IsBlocked { get; set; }
}