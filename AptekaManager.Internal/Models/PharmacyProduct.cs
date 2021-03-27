namespace AptekaManager.Internal.Models
{
    public partial class PharmacyProduct
    {
        public int Id { get; set; }
        public int PharmacyId { get; set; }
        public int ProductId { get; set; }

        public virtual Pharmacy Pharmacy { get; set; }
        public virtual Product Product { get; set; }
    }
}
