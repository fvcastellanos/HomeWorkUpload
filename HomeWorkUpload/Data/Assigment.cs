using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWorkUpload.Data
{
    [Table("assigment")]
    public class Assigment
    {
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("copy_email")]
        public string CopyEmail { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}