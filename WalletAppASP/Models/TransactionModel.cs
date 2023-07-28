using System.ComponentModel.DataAnnotations;

namespace WalletAppASP.Models
{
    public class TransactionModel
    {
        [Key]
        public long Id { get; set; }
        public decimal Sum { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public bool Pending { get; set; }
        public UserModel User { get; set; }
        public UserModel AuthorizedUser { get; set; }
        public bool Type { get; set; }
    }
}
