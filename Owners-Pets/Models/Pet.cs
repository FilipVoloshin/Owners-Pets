namespace Owners_Pets.Models
{
    public class Pet
    {
        public long PetId { get; set; }
        public string PetName { get; set; }
        public int OwnerId { get; set; }
    }
}