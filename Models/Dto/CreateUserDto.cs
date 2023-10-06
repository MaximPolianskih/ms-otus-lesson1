namespace SimpleApi.Models.Dto
{
    public class CreateUserDto : BaseUserModel
    {
        public string UserName { get; set; } = null!;
    }
}
