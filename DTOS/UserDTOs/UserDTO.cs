namespace DTOS.UserDTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }  

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string Location { get; set; }

        public string PictureProfile { get; set; }
    }
}
