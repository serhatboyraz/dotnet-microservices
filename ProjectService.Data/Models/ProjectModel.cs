using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectService.Data.Enum;

namespace ProjectService.Data.Models
{
    [Table("project")]
    public class ProjectModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Title { get; set; }

        public ProjectStatusEnum Status { get; set; }

    }
}
