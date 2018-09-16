namespace klaravictor.Models
{
    public class RvspModel
    {
        public int RvspId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Attending { get; set; }
        public string Accommondation { get; set; }
        public int NumberOfNights { get; set; }
        public string FoodInfo { get; set; }
        public string Comment { get; set; }
    }
}