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
        // TODO: Дата – за останній тиждень має виводитись назва дня для всього іншого дата.
        public DateTime? Date { get; set; }
        // TODO: транзакція може бути в статусі pending – тоді в неє це виводиться перед description
        public bool Pending { get; set; }
        public UserModel User { get; set; }
        public short Types { get; set; }
    }
}
