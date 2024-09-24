using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra02.Models
{
    public class LopHoc
    {
        [Key]
        public int Id { get; set; }
        public string TenLopHoc { get; set; }
        public DateTime NamNhapHoc { get; set; }
        public DateTime NamRaTruong {  get; set; }
        public int SoLuongSinhVien { get; set; }
    }
}
