using System.ComponentModel.DataAnnotations.Schema;

namespace AutomapperTest.Entity
{
    public class Child
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SchoolName { get; set; }

        [ForeignKey(nameof(Parent))]
        public int ParentId { get; set; }

        public virtual Parent Parent { get; set; }
    }
}