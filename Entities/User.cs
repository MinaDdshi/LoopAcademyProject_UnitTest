using System.ComponentModel.DataAnnotations;

namespace LoopAcademyProject.Entities
{
    public class User : BaseEntity<int>
    {
        [Required]
        [MinLength(6)]
        [MaxLength(12)]
        public string UserName { get; set; }

        [MaxLength(12)]
        public string Name { get; set; }

        [MaxLength(12)]
        public string SurName { get; set; }

        [Phone]
        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }

        [Required]
        [MaxLength(10)]
        public string NationalCode { get; set; }
    }
}
