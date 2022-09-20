using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TaskXslx.DTO
{
    public class FileModel
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile ImportFile { get; set; }
    }
}
