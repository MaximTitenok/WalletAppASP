using System.ComponentModel.DataAnnotations;

namespace WalletAppASP.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
