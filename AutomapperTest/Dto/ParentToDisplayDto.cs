using System.Collections.Generic;

namespace AutomapperTest.Dto
{
    public class ParentToDisplayDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<ChildToDisplayDto> Children { get; set; }
    }
}