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



            // Definition of a person
            // Can be adjusted in the future as necessary
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
                // initialising list
                people = new List<Person>()
                {
                    //new Person("Aba", 23),
                    //new Person("Austin", 16)
                };


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

                bool tryParseMenu = int.TryParse(Console.ReadLine(), out int menuOption);   // Parsing the User Input as a Menu option

                if (tryParseMenu && menuOption > 0 && menuOption < 7)
                {
                    //Console.WriteLine(menuOption);

                    if (menuOption == 1) { printUsers(); }
                    else if (menuOption == 2) { addUsers(); }
                    else if (menuOption == 3) { editUsers(); }
                    else if (menuOption == 4) { searchUsers(); }
                    else if (menuOption == 5) { removeUsers(); }
                    else if (menuOption == 6) { exit(); }

                    printMenu();
                }
                else
                {
                    //Console.WriteLine("Invalid option; Press <Enter> to try again.");
                    errorMessage("Invalid option!");
                    printMenu();
                }

            }

            public void printUsers()
            {
                //Console.WriteLine("Print");

                startOption("Printing");

                printAllUsers();


                finishOption();

                //int i = 1;

                //// people is a list of Persons
                //people.ForEach(delegate (Person person)
                //{                    
                //    Console.WriteLine(i + ". " + person.returnDetails());  // return details for each person in list
                //    i++;
                //});


            }

            public void addUsers()
            {
                startOption("Adding");


                // Enter name

                Console.Write("Enter a name: ");
                string nameInput = Console.ReadLine();

                // Enter age
                Console.Write("Enter age: ");
                //int ageInput = Convert.ToInt32( Console.ReadLine() );

                bool tryParseAdd = int.TryParse(Console.ReadLine(), out int ageInput);   // Parsing the Age Input


                if (!string.IsNullOrEmpty(nameInput))
                {
                    if (tryParseAdd && ageInput > 0 && ageInput < 150)
                    {
                        // Create person class

                        Person person = new Person(nameInput, ageInput);

                        // add to List
                        people.Add(person);

                        Console.WriteLine("Successfully added a person!");

                        finishOption();
                    }
                    else
                    {
                        errorMessage("Invalid age input! Please enter a valid age and range.");
                        addUsers();
                    }
                }
                else
                {
                    errorMessage("Invalid name input!");
                    addUsers();
                }




            }
            public void editUsers()
            {
                startOption("Editing");

                //Console.WriteLine("Edit");


                if (people.Count == 0)
                {
                    Console.WriteLine("There are currently no users in the system to edit. Create a user with option 1.");
                    
                }
                else
                {
                    // Check if person in system AND Print all people
                    printAllUsers();


                    // allow selection
                    Console.Write("Enter an Index: ");

                    // validate selection                
                    bool tryParseEdit = int.TryParse(Console.ReadLine(), out int indexSelect);   // Parsing the Index Selection input

                    indexSelect--;  // To match the actual list index

                    if (tryParseEdit && indexSelect >= 0 && indexSelect < people.Count())
                    {

                        // edit user, print message
                        //people();

                        Console.WriteLine("Successfully edited a person!");

                    }
                    else
                    {
                        errorMessage("Invalid Index! Please enter a valid Index to edit.");
                        editUsers();
                    }

                }


                finishOption();
            }
            public void searchUsers()
            {
                startOption("Searching");

                Console.WriteLine("Search");
                finishOption();
            }
            public void removeUsers()
            {
                startOption("Removing");

                Console.WriteLine("Remove");
                finishOption();
            }
            public void exit()
            {
                Console.Clear();

                Console.WriteLine("Press <Enter> again to exit the app.");
            }



            public void finishOption()
            {
                Console.WriteLine();
                Console.WriteLine("Press <Enter> again to return to Menu.");

                Console.ReadLine();
                Console.Clear();
            }

            public void startOption(string message)
            {
                Console.Clear();

                Console.WriteLine($"{message} users: \n");
            }

            public void errorMessage(string message)
            {
                Console.WriteLine();
                Console.WriteLine($"{message} Press <Enter> to try again.");

                Console.ReadLine();
                Console.Clear();
            }


            public void printAllUsers()
            {
                if (people.Count == 0)
                {
                    Console.WriteLine("There are currently no users in the system. Create a user with option 1.");
                    //finishOption();
                }
                else
                {
                    for (int i = 1; i < people.Count + 1; i++)
                    {
                        Console.WriteLine(i + ". " + people[i - 1].returnDetails());  // return details for each person in list
                    }
                }
            }

            // we want to return a Person, not void
            public Person returnPerson()
            {
                // Enter name

                Console.Write("Enter a name: ");
                string nameInput = Console.ReadLine();

                // Enter age
                Console.Write("Enter age: ");
                //int ageInput = Convert.ToInt32( Console.ReadLine() );

                bool tryParseAge = int.TryParse(Console.ReadLine(), out int ageInput);   // Parsing the Age Input


                if (!string.IsNullOrEmpty(nameInput))
                {
                    if (tryParseAge && ageInput > 0 && ageInput < 150)
                    {
                        // Create new person

                        return new Person(nameInput, ageInput); // returns new person

                    }
                    else
                    {
                        errorMessage("Invalid age input! Please enter a valid age and range.");
                    }
                }
                else
                {
                    errorMessage("Invalid name input!");
                }

                return null;

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
