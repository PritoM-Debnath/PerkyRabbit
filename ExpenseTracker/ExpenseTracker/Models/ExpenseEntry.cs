﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class ExpenseEntry
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Description { get; set; }

        [Required]
        public decimal? Amount { get; set; }

        [Required]
        public DateTime ExpenseDate { get; set; } = DateTime.Now;

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual ExpenseCategory Category { get; set; }
    }
}
