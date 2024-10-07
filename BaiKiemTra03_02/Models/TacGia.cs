using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_02.Models
{
    public class TacGia
    {
        [Key]
        public int MaTacGia { get; set; }
        [Required]
        public string TenTacGia { get; set; }
        [Required]
        public string? QuocTich { get; set; }
        [Required]
        public DateTime NamSinh { get; set; }
    }
}
