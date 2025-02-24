using Microsoft.EntityFrameworkCore;

namespace ToDo.modells{
    [PrimaryKey("Task_Id")]
    public class tasks{
        public int Task_Id {  get; set; }
        public string Task_Title { get; set; }
        public string Task_Description { get; set; }
        public string Task_Status { get; set; }
        public string Task_Priority { get; set; }
        public int Due_Date { get; set; }
        public int Creation_Date { get; set; }
        public int Update_Date { get; set; }
    }
}
