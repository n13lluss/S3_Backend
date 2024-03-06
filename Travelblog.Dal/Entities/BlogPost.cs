using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travelblog.Dal.Entities
{
    public partial class BlogPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int BlogId { get; set; }

        public int PostId { get; set; }

        public virtual Blog Blog { get; set; } = null!;

        public virtual Post Post { get; set; } = null!;
    }
}
