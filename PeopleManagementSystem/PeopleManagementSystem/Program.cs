using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagementSystem
{
    internal class Program
    {
        class Person
        {
            // get runs when reading the property value
            // set runs when asssigning a new value to property. Keyword "value" represents incoming data

            // protected restricts so that value can only be assigned within the containing class   (We can only assign the name inside the Person Class)
            // Anything outside the class can still publically read the values
            public string name { get; protected set; }  
            public int age { get; protected set; }



            public Person(string name, int age)
            {
                // this refers to the class field "name" in the current instance of a class ( public string name )
                // name is the constructor parameter

                this.name = name;
                this.age = age;

            }


            public string returnDetails()
            {
                return $"{name} - {age}";
            }


            // 2 Additional functions to allow us to change individual parameters, instead of having to rewrite both parameters

            public void setName(string name)
            {
                this.name = name;
            }

            public void setAge(int age)
            {
                this.age = age;
            }


        }

        class Manager
        {
            // Manager will be in charge of a list of people
            public List<Person> people;


            // Manger Constructor
            public Manager()
            {
                people = new List<Person>();    // initialising list
                printMenu();
            }

            public void printMenu()
            {
                Console.WriteLine("Welcome to the management system!");
                Console.WriteLine("1. Print all users");
                Console.WriteLine("2. Add User");
                Console.WriteLine("3. Edit User");
                Console.WriteLine("4. Search User");
                Console.WriteLine("5. Remove User");
                Console.WriteLine("6. Exit App");

                Console.Write("Enter an option: ");

                bool tryParse = int.TryParse(Console.ReadLine(), out int menuOption);   // Parsing the User Input as a Menu option

                if(tryParse && menuOption > 0 && menuOption < 7)
                {
                    //Console.WriteLine(menuOption);

                    if (menuOption == 1) { printUsers(); }
                    else if (menuOption == 2) { addUsers(); }
                    else if (menuOption == 3) { editUsers(); }
                    else if (menuOption == 4) { searchUsers(); }
                    else if (menuOption == 5) { removeUsers(); }
                    else if (menuOption == 6) { exit(); }
                }
                else
                {
                    Console.WriteLine("Invalid option; Press <Enter> to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    printMenu();
                }

            }

            public void printUsers()
            {
                Console.WriteLine("Print");
            }
            public void addUsers()
            {
                Console.WriteLine("Add");
            }
            public void editUsers()
            {
                Console.WriteLine("Edit");
            }
            public void searchUsers()
            {
                Console.WriteLine("Search");
            }
            public void removeUsers()
            {
                Console.WriteLine("Remove");
            }
            public void exit()
            {
                Console.WriteLine("Exit");
            }


        }


        static void Main(string[] args)
        {
            //Person person = new Person("Aba", 23);
            //Console.WriteLine(person.returnDetails());

            ////Console.WriteLine($"{person.name} - {person.age}");
            //person.setName("Ab");
            //person.setAge(20);
            //Console.WriteLine(person.returnDetails());

            Manager manager = new Manager();    // A new instance of manager will automatically call printMenu(), as stated in the constructor


            Console.ReadLine();
        }
    }
}
