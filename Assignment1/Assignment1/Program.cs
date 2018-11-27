using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Assignment1
{
    public class Program
    {
              
        static void Main(string[] args)
        {
            Commands.DisplayAllCommands();
            bool whileCond = true;
            while(whileCond)
            {
                
                Console.WriteLine("Enter a command:");
                var input = Console.ReadLine();

                switch (input)
                {

                    case "-l":
                        Commands.LoadPreviouStateApp();
                        break;
                    case "-s":
                        Commands.Save();
                        break;
                    case "-v":
                        Commands.ViewListOfCharacters();
                        break;
                    case "-c":
                        Commands.CreateACharacter();                        
                        break;
                    case "-d":
                        Console.WriteLine("Enter character name to delete:");
                        var charName = Console.ReadLine();
                        Commands.DeleteCharByName(charName);
                        break;
                    case "-q":
                        whileCond = false;
                        break;
                    case "-h":
                        Commands.DisplayAllCommands();
                        break;
                    default:
                        Console.WriteLine("Wrong command, please select a command from list:");
                        break;
                }


            }
        }
    }
    
}
