using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListApp.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        
        [Required]
        [Display(Name = "Item Quantity")]
        public int ItemQuantity { get; set; }

        [StringLength(20)]
        [Display(Name = "Shop Name")]
        public string? ShopName { get; set; }

        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }
    }
}
