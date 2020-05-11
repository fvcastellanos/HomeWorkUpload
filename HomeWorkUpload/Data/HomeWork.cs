using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWorkUpload.Data
{
    [Table("homework")]
    public class HomeWork
    {
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Required]
        [ForeignKey("assigment_id")]
        public Assigment Assigment { get; set; }
    }
}