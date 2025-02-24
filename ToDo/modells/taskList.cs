using Microsoft.EntityFrameworkCore;

namespace ToDo.modells{
    [PrimaryKey("List_Id")]
    public class taskList{
        public int List_Id {  get; set; }
        public string List_Title { get; set; }
        public string List_Description { get; set; }
        public int Creation_Date { get; set; }
        public int Update_Date { get; set; }
    }
}