using System.Collections.Generic;

namespace AutomapperTest.Entity
{
    public class Parent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Child> Children { get; set; }
    }
}