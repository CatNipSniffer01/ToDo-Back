using Microsoft.EntityFrameworkCore;

namespace ToDo.modells{
        [PrimaryKey("AdminUser_Id")]
    public class adminUsers{
        public int AdminUser_Id { get; set; }
        public int AdminUserName { get; set; }
        public int AdminUser_Password { get; set; }
        public int AdminUser_Email { get; set; }
        public int AdminUserAcc_CR_D {  get; set; }
        public int AdminUserAcc_UP_D { get; set; }
    }
}