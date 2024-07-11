using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Department name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Department Code is Required")]
        public string Code { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

    }
}
