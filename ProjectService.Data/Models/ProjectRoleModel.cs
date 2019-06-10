using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectService.Data.Models
{
    [Table("project_role")]
    public class ProjectRoleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long ProjectId { get; set; }
        public ProjectModel Project { get; set; }

        public long UserId { get; set; }
    }
}
