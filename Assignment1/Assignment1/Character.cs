using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Character
    {
        private string description;
        private string category;
        public string Name { get; set; }

        public string NickName { get; set; }

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                var wrongValue = value.ToLower() != Global.Hero && value.ToLower() != Global.Villian;
                while (wrongValue)
                {
                    Console.WriteLine("Wrong side entered, Enter ({0}/{1}):", Global.Hero, Global.Villian);
                    value = Console.ReadLine();
                    wrongValue = value.ToLower() != Global.Hero && value.ToLower() != Global.Villian;
                }
                this.category = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (value.Equals(""))
                {
                    this.description = "Just another hero/villain)";
                    return;
                }
                this.description = value;
            }
        }
    }
}
