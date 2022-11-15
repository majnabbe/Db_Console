using Db_Console.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Db_Console
{
    internal static class MenuAndInput
    {
        public static void Menu()
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("Välj alternativ:\n\n1. Lägg till person.\n2. Uppdatera person med id.\n3. Ta bort person med id.\n4. Hitta person med id.\n" +
                    "5. Sök (begränsad funktionalitet - använd endast ett sökord).\n6. Skriv ut alla personer.\n7. Avsluta.\n");

                Console.Write("Ditt val: ");
                string select = Console.ReadLine();
                Console.Clear();

                switch (select)
                {
                    case "1":
                        Console.WriteLine("Ange följande uppgifter:\n");
                        InputAdd();
                        ClearScreenAndContinue();
                        break;
                    case "2":
                        Console.Write("Ange id för person som ska uppdateras: ");
                        InputUpdate();
                        ClearScreenAndContinue();
                        break;
                    case "3":
                        Console.Write("Ange id för person som ska tas bort: ");
                        InputDelete();
                        ClearScreenAndContinue();
                        break;
                    case "4":
                        Console.Write("Ange id för att söka på person: ");
                        InputFind();
                        ClearScreenAndContinue();
                        break;
                    case "5":
                        SearchForPerson();
                        ClearScreenAndContinue();
                        break;
                    case "6":
                        PrintAll();
                        ClearScreenAndContinue();
                        break;
                    case "7":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Felaktigt alternativ.");
                        break;
                }
            }
        }

        public static void InputAdd()
        {
            Console.Write("Förnamn: ");
            string firstName = Console.ReadLine();
            Console.Write("Efternamn: ");
            string lastName = Console.ReadLine();
            Console.Write("Adress: ");
            string address = Console.ReadLine();

            AddPerson newPerson = new AddPerson();
            newPerson.AddPersonToDatabase(new Person(firstName, lastName, address));
        }
        public static void InputUpdate()
        {
            UpdatePerson newUpdatePerson = new UpdatePerson();
            newUpdatePerson.UpdatePersonInDatabase(InputCheck());
        }
        public static void InputDelete()
        {
            DeletePerson newDeletePerson = new DeletePerson();
            newDeletePerson.DeletePersonFromDatabase(InputCheck());
        }

        public static void InputFind()
        {
            FindPerson newFindPerson = new FindPerson();
            newFindPerson.FindPersonInDatabase(InputCheck());
        }

        public static void SearchForPerson()
        {
            Console.Write("Sök efter: ");

            FindPerson newSearch = new FindPerson();
            newSearch.FindPersonInDatabase(Console.ReadLine());
        }

        public static void PrintAll()
        {
            FindPerson newFindAllPersons = new FindPerson();
            newFindAllPersons.FindPersonInDatabase();
        }

        public static void ClearScreenAndContinue()
        {
            Console.Write("\nTryck på valfri tangent för att fortsätta. \n");
            Console.ReadKey();
            Console.Clear();
        }

        public static int InputCheck()
        {
            int id = 0;
            bool correctInput = false;

            while (!correctInput)
            {
                correctInput = int.TryParse(Console.ReadLine(), out id);

                if (!correctInput)
                {
                    Console.Clear();
                    Console.Write("Felaktig inmatning. Försök igen: ");
                }
            }

            return id;
        }
    }
}
