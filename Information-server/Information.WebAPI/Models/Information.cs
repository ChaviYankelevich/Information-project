namespace Information.WebAPI.Models
{
    public enum EMOF { male, female }
    public class Information
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public EMOF EMOF { get; set; }
        public string HMO { get; set; }
    }
}
