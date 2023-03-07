namespace AutomapperTest.Dto
{
    public class ChildToDisplayDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SchoolName { get; set; }
        public int ParentId { get; set; }
        //public virtual Parent Parent { get; set; }
    }
}