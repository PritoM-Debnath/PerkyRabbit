using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models;

public partial class ExpenseEntry
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Description { get; set; }

    [Required]
    public decimal? Amount { get; set; }

    [Required]
    public DateTime ExpenseDate { get; set; } = DateTime.Now;

    [ForeignKey("Id")]
    public int CategoryId { get; set; }
    public virtual ExpenseCategory Category { get; set; }
}



