using System.ComponentModel.DataAnnotations;

namespace HomeWorkUpload.Model.Views
{
    public class AssigmentView
    {
        public long Id { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(300)]
        public string Email { get; set; }

        [EmailAddress]
        [MaxLength(300)]
        public string CopyEmail { get; set; }
    }
}