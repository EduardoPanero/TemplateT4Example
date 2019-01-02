using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateT4Example.Db.Model
{
    public partial class Class
    {
        [Key]
        public int ClassID { get; set; }
        public string Location { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherID { get; set; }

        [ForeignKey("Subject")]
        public int SubjectID { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}
