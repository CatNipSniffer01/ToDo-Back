using Microsoft.EntityFrameworkCore;

namespace ToDo.modells{
    [PrimaryKey("User_Id")]
    public class users{
        public int User_Id {  get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Acc_CR_D { get; set; }
        public int Acc_UP_D { get; set; }
    }
}
