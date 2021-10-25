using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Manager
{
    public class User
    {
        public String name { get; set; }
        public String surname { get; set; }
        public String email { get; set; }
        public String username { get; set; }
        public String password { get; set; }

        //user preferences
        public int week { get; set; }
        public DateTime semesterDate { get; set; }
        //each user can have many modules 

        private List<Module> modules = new List<Module>();
        public List<Module> Module
        {
            get { return modules; }
            set { modules = value; } 
        }
        
    }
}
