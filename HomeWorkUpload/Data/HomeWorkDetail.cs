using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWorkUpload.Data
{
    [Table("homework_detail")]
    public class HomeWorkDetail
    {
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("image_url")]
        public string ImageUrl { get; set; }

        [Required]
        [ForeignKey("homework_id")]
        public HomeWork HomeWork { get; set; }
    }
}