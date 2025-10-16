namespace ToDoListDTOs
{
    public class AddUserDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }

    }
}
