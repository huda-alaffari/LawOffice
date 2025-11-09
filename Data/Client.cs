using System.ComponentModel.DataAnnotations;

namespace LowOffice.Data
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "الرقم المدني مطلوب")]
        public string NationalID { get; set; }

        [Required(ErrorMessage = "رقم الهاتف مطلوب")]
        [Phone(ErrorMessage = "رقم الهاتف غير صالح")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صالح")]
        public string Email { get; set; }

        public string Address { get; set; }

        public string? DocumentFileName { get; set; } // لحفظ اسم ملف التوكيل المرفوع
    }
}