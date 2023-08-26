using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models;


public partial class ExpenseCategory
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = $"Category Should Have a Unique Name")]
    public string Name { get; set; }
    public string? Description { get; set; }

    public DateTime? CreationDate { get; set; } = DateTime.Now;

    public ICollection<ExpenseEntry>? Expenses { get; set; }
}
