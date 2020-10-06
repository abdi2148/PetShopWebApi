using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entities;
using PetShopApp.Coree;
using PetShopApp.Coree.ApplicationServices.Services;

namespace ConsoleApp2020
{
    class Printer : IPrinter
    {
        #region Service area
        readonly IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
        }
        #endregion

        #region UI

        public void StartUI()
        {
            string[] menuItems = {
                "List All Pets",
                "Create Pet",
                "Delete Pet",
                "Update Pet",
                "Search by type",
                "Sort Pets by price",
                "List 5 cheapest pets",
                "Exit"
            };

            int selection = ShowMenu(menuItems);

            while (selection != 8)
            {
                while (selection != 8)
                {   
                    switch (selection)
                    {
                        case 1:
                            List<Pet> pets = _petService.GetPets();
                            ListPets(pets);
                            Console.WriteLine();
                            break;
                        case 2:
                            var pet = MakeNewPet();
                            _petService.Create(pet);
                            Console.WriteLine();
                            break;
                        case 3:
                            DeletePet();
                            break;
                        case 4:
                            UpdatePet();
                            Console.WriteLine();
                            break;
                        case 5:
                            SearchPetByType();
                            Console.WriteLine();
                            break;
                        case 6:
                            GetSortedPetsByPrice();
                            Console.WriteLine();
                            break;
                        case 7:
                            ListCheapestPets();
                            Console.WriteLine();
                            break;
                        default:
                            break;
                    }
                    selection = ShowMenu(menuItems);
                }
                Console.WriteLine("Bye bye!");
                Console.ReadLine();
            }
        }

        private void DeletePet()
        {
            int idForDelete = PrintFindPetId();
            _petService.Delete(idForDelete);
            Console.WriteLine("Removed!");
        }

        private void ListCheapestPets()
        {
            List<Pet> pets = _petService.GetSortedList();
            int counter = 0;
            foreach (var item in pets)
            {
                if (counter < 5)
                {
                    Console.WriteLine($"{item.Price} {item.Name}");
                    counter++;
                }
            }
        }

        private List<Pet> GetSortedPetsByPrice()
        {
            List<Pet> pets = _petService.GetSortedList();
            foreach (var item in pets)
            {
                Console.WriteLine($"{item.Name} {item.Price}");
            }
            return pets;
        }

        private void SearchPetByType()
        {
            Console.Write($"Insert type: ");
            string type = Console.ReadLine();
            List<Pet> filteredList = _petService.FilterPetByType(type);
            foreach (var item in filteredList)
            {
                Console.WriteLine(item.Name, item.Type);
            }
        }

        private void UpdatePet()
        {
            int petId = InsertPetId();
            var petToUpdate = _petService.FindPetById(petId);
            Console.WriteLine("Update " + petToUpdate.Name);
            var newName = AskStringQuestion("Name: ");
            var newType = AskStringQuestion("Type: ");
            string newColor = AskStringQuestion("Color:");
            Console.Write("Birth date:");
            DateTime newBirthday = AskDateQuestion();
            Console.Write("Sold date:");
            DateTime newSoldDate = AskDateQuestion();
            var newOwner = AskStringQuestion("Owner: ");
            Console.Write("Price: ");
            double newPrice = AskDoubleQuestion();

            petToUpdate.Name = newName;
            petToUpdate.Type = newType;
            petToUpdate.Color = newColor;
            petToUpdate.Birthday = newBirthday;
            petToUpdate.SoldDate = newSoldDate;
            petToUpdate.PrevOwner = newOwner;
            petToUpdate.Price = newPrice;

            _petService.Update(petToUpdate);
        }

        private int InsertPetId()
        {
            Console.Write("Insert Pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number: ");
            }
            return id;
        }

        private Pet MakeNewPet()
        {
            Console.WriteLine("Create new Pet ");
            var name = AskStringQuestion("Name: ");
            var type = AskStringQuestion("Type: ");
            var color = AskStringQuestion("Color: ");
            Console.Write("Birthday: ");
            DateTime birthday = AskDateQuestion();
            Console.Write("Sold Date: ");
            DateTime soldDate = AskDateQuestion();
            var owner = AskStringQuestion("Previous Owner: ");
            Console.Write("Price: ");
            Double price = AskDoubleQuestion();
            return _petService.CreateNewPet(name, type, birthday, soldDate, color, price, owner);
        }

        private double AskDoubleQuestion()
        {
            double amount;
            while (!Double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Please insert a amount: ");
            }
            return amount;
        }

        private DateTime AskDateQuestion()
        {
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Please insert a correct date format (example: 01/01/1991)");
            }
            return date;
        }

        string AskStringQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        private void ListPets(List<Pet> pets)
        {
            Console.WriteLine("\nList of Pets");
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id} | Name: {pet.Name} "  +
                                $"| Type: {pet.Type} | Color: {pet.Color}"  +
                                $"| Birthday: {pet.Birthday} | Previous Owner: { pet.PrevOwner} " +
                                $"| Price: {pet.Price} | Sold Date: { pet.SoldDate}");
            }
            Console.WriteLine("\n");
        }

        private int PrintFindPetId()
        {
            Console.WriteLine("Insert Pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }



        int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("\n Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 8)
            {
                Console.WriteLine("Please select a number between 1-8");
            }

            return selection;
        }

        //public void BackMainMenu()
        //{
        //    Console.WriteLine("\nPress any key to back");
        //    Console.ReadKey();
        //    ShowMenu();
        //}
    }
    #endregion
}