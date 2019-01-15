using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateT4Example.Db.Model
{
    public partial class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
