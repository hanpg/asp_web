using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiKiemTra03_02.Models
{
    public class Sach
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string TieuDeSach { get; set; }
        [Required]
        public DateTime NamXuatBan { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public int MaTacGia { get; set; }
        [ForeignKey("MaTacGia")]
        [ValidateNever]
        public TacGia TacGia { get; set; }
    }
}
