using EzgiBlog.Data.DTO;

namespace EzgiBlog.ViewModels
{
    public class LoginModel
    {
        public string Msg { get; internal set; }
        public UserDTO User { get; internal set; }
    }
}