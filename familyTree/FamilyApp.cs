using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace familyTree
{
    public class FamilyApp
    {
        public List<Person> People;
        public FamilyApp(params Person[] peoples)
        {
            People = new List<Person>(peoples);
        }

        public string WelcomeMessage = "Hei og velkommen til familietreet.";
        
        public string CommandPrompt = "Skriv inn din kommando her: "; 

        public string HandleCommand(string command)
        {
            var toLowerCommand = command.ToLower();

            if (toLowerCommand == "hjelp") 
            {
                return
                    "skriv inn 'hjelp' for alle mulige kommandor \n" +
                    "skriv inn 'list' for å liste opp alle personer \n" +
                    "skriv inn 'vis ID' for å finne en spesifik person \n";
            }

            if (toLowerCommand == "list")
            {
                string decription = string.Empty;
                foreach (var person in People)
                {
                    decription += person.GetDescription() + "\n"; 
                }
                    
            }

            var commandArray = toLowerCommand.Split(' ');
            int foundID = Convert.ToInt32(commandArray[1]);

            if (commandArray[0] == "vis") 
            {
                return FindFamilyMembers(foundID);
                return "";
            }

            return "Ugyldig person, prøv igjen";
        }

        public string FindFamilyMembers(int ID)
        {
            string foundPersonDescription = "Ugyldig person, prøv igjen";

            foreach (var person in People)
            {
                if (person.Id == ID) 
                {
                    foundPersonDescription = person.GetDescription();
                    foundPersonDescription += DescriptionOfChildren(ID);
                }
            }

            return foundPersonDescription;
        }

        public string DescriptionOfChildren(int ID)
        {
          string child = "\n  Barn:\n";

          foreach (var person in People)
            {
                if (person.Father != null && ID == person.Father.Id || person.Mother != null && ID == person.Mother.Id)
                {
                    child += "    " + person.FirstName + " (Id=" + person.Id + ") " + "Født: " + person.BirthYear + "\n";
                }
            }

          return child;
        }

    }
}
