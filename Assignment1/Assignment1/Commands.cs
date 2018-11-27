using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Commands
    {
        public static bool ValidateInput(string input)
        {

            return false;
        }
        public static void DisplayAllCommands()
        {
            Console.WriteLine("1. -l => Load application.");
            Console.WriteLine("2. -s => Save current changes.");
            Console.WriteLine("3. -v => View List of all characters.");
            Console.WriteLine("4. -c => Create a character.");
            Console.WriteLine("5. -d => Delete a character.");
            Console.WriteLine("5. -h => Display commands.");
            Console.WriteLine("6. -q => Exit application.");
        }

        public static void LoadPreviouStateApp()
        {
            var json = JsonConvert.DeserializeObject(
                File.ReadAllText(@"C:\tmp\output.json"));

            //Commands.listOfCharacters.RemoveAll(item => !string.IsNullOrEmpty(item.Name));
            Global.listOfCharacters.RemoveRange(0, Global.listOfCharacters.Count);
            Global.listOfCharacters = JsonConvert.DeserializeObject<List<Character>>
                (json.ToString()).ToList();

            Console.WriteLine("Loaded previous state of application");
        }

        public static void Save()
        {
            var json = JsonConvert.SerializeObject(Global.listOfCharacters);
            File.WriteAllText(@"C:\tmp\output.json", json);
            Console.WriteLine("Saved current status of application to file");
        }

        public static void ViewListOfCharacters()
        {
            Console.WriteLine("Heroes:");
            DisplayListOfSpecficCharacters(Global.Hero);

            Console.WriteLine("Villians:");
            DisplayListOfSpecficCharacters(Global.Villian);
        }

        public static void DisplayListOfSpecficCharacters(string category)
        {
            foreach (var item in Global.listOfCharacters)
            {
                if (item.Category.ToLower() == category)
                {
                    Console.Write("- {0} ", item.Name);
                    if (!string.IsNullOrEmpty(item.NickName))
                    {
                        Console.Write("a.k.a '{0}'", item.NickName);
                    }
                    Console.WriteLine(" - {0}", item.Description);
                }
            }
        }
        public static void CreateACharacter()
        {
            Console.WriteLine("Enter name of character");
            var name = Console.ReadLine();

            var nameAlreadyExists = Global.listOfCharacters.Any(item => item.Name == name);
            while (nameAlreadyExists)
            {
                Console.WriteLine("Name already exists, enter a different name:");
                name = Console.ReadLine();
                nameAlreadyExists = Global.listOfCharacters.Any(item => item.Name == name);
            }

            Console.WriteLine("Enter nick name of character");
            var nickName = Console.ReadLine();

            Console.WriteLine("Enter side of character (Hero/Villian)");
            var category = Console.ReadLine();

            Console.WriteLine("Enter description of character");
            var description = Console.ReadLine();

            var character = new Character
            {
                Name = name,
                NickName = nickName,
                Category = category,
                Description = description
            };

            Global.listOfCharacters.Add(character);
        }

        public static void DeleteCharByName(string name)
        {
            for (int i = 0; i < Global.listOfCharacters.Count; i++)
            {
                var item = Global.listOfCharacters[i];
                if (item.Name.Equals(name))
                {
                    Global.listOfCharacters.Remove(item);
                    Console.WriteLine("{0} deleted.", item.Name);
                }
            }
        }
    }
}
