using System.Collections.Generic;

namespace AutomapperTest.Dto
{
    public class ParentCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<ChildCreationDto> Children { get; set; }  // as we don't need to include ParentId inside the child
    }
}