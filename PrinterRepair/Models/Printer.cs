using PrinterRepair.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrinterRepairService.Models
{
    public class Printer
    {
        public Printer()
        {
        }
        //public Printer(string make, string model, int userID)
        //{
        //    this.Make = make;
        //    this.Model = model;
        //    this.UserId = userID;       
        //}
        
       [Key]
        public int UserId { get; set; }

        [Required]
        public PrinterType Type { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "The make must be less than 20 characters long")]
        public string Make { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "The model must be less than 20 characters long")]
        public string Model { get; set; }

        public virtual ICollection<Damage> Damages { get; set; }
    }
}
