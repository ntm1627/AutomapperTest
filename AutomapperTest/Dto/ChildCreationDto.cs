namespace AutomapperTest.Dto
{
    public class ChildCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SchoolName { get; set; }
        public int ParentId { get; set; }  //Adding the Parent property will create a cyclic pb as collection of children is created in the parent
    }
}