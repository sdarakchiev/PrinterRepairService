using System.ComponentModel.DataAnnotations;

namespace PrinterRepairService.Models
{
    public class User
    {
        public User()
        {
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "The name is too long")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "The name is too long")]
        public string LastName { get; set; }

        public virtual Printer Printer { get; set; }

        //public virtual IList<Printer> printers { get; set; }

        public override string ToString()
        {
            return $"{this.Id} - {this.FirstName} {this.LastName}";
        }
    }
}
