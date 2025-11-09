
using System;
using System.ComponentModel.DataAnnotations;

namespace LowOffice.Models
{
    public class CourtRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم المحكمة مطلوب")]
        public string CourtName { get; set; }

        [Required(ErrorMessage = "منطقة المحكمة مطلوبة")]
        public string GovernorateNameArabic { get; set; }

        //public DateTime RequestDate { get; set; } = DateTime.Now;
    }
    public class AuthenticationModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

