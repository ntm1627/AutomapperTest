using System.Collections.Generic;

namespace AutomapperTest.Dto
{
    public class ParentForUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<ChildForUpdateDto> Children { get; set; }
    }
}