namespace Information.WebAPI.Models
{
    public class Chaild
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int ParentId { get; set; }
    }
}
