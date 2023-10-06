namespace SimpleApi.Models.Dto
{
    public class UserDto : BaseUserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
    }
}
