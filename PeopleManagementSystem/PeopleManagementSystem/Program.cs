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
            // (User) Manager will contain a list of people
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


                    //else if (menuOption == 6) { exit(); }

                    if (menuOption >=1 && menuOption <= 5) 
                    {
                        printMenu();
                    }
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

                if (!isSystemEmpty()) 
                {
                    printAllUsers();
                }


                finishOption();                


            }

            public void addUsers()
            {
                startOption("Adding");


                Person person = returnPerson(); // This will return either a successful person object or null

                if (person != null) 
                {
                    // add to List
                    people.Add(person);

                    Console.WriteLine("Successfully added a person!");

                    finishOption();
                }
                else
                {
                    addUsers(); // Repeat this function when the user inputs an invalid entry/person
                }



            }
            public void editUsers()
            {
                startOption("Editing");

                //Console.WriteLine("Edit");


                //if (people.Count == 0)
                //{
                //    Console.WriteLine("There are currently no users in the system. Create a user with option 1.");
                //    finishOption();

                //}
                //else

                if (!isSystemEmpty())
                {
                    // Check if person in system AND Print all people
                    printAllUsers();


                    // allow selection
                    Console.Write("Enter an Index: ");

                    // validate selection                
                    bool tryParseEdit = int.TryParse(Console.ReadLine(), out int indexSelect);   // Parsing the Index Selection input

                    indexSelect--;  // To match the actual list index


                    if (tryParseEdit && indexSelect >= 0 && indexSelect < people.Count)
                    {

                        // edit user, print message
                        Person person = returnPerson(); // This will return either a successful person object or null

                        if (person != null)
                        {
                            // edit list

                            // instead of adding, we replace it directly at the corresponding index
                            people[indexSelect] = person;


                            Console.WriteLine("Successfully edited a person!");

                            finishOption();
                        }
                        else
                        {
                            editUsers(); // Repeat this function when the user inputs an invalid entry/person
                        }

                    }
                    else
                    {
                        errorMessage("Invalid Index! Please enter a valid Index to edit.");
                        editUsers();
                    }



                }
                else
                {
                    Console.ReadLine();
                    Console.Clear();
                }


            }
            public void searchUsers()
            {
                startOption("Searching");

                // Check for people in system             
                if (people.Count == 0)
                {
                    Console.WriteLine("There are currently no users in the system. Create a user with option 1.");
                    finishOption();

                }
                else
                {

                    bool searchFound = false;


                    //while (!searchFound)
                    //{
                    Console.Write("Enter a name: ");
                    string nameInput = (Console.ReadLine()).ToLower();


                    // Validating Name input
                    if (!string.IsNullOrEmpty(nameInput))
                    {

                        for (int i = 0; i < people.Count; i++)
                        {
                            //if (people[i].name.ToLower() == nameInput.ToLower())
                            if (people[i].name.ToLower().Contains(nameInput))
                            {
                                Console.WriteLine(people[i].returnDetails());
                                searchFound = true;
                            }
                        }

                        if (!searchFound)
                        {
                            errorMessage("No search result found.");
                            searchUsers();
                        }



                        finishOption();
                    }
                    else
                    {
                        errorMessage("Invalid name input!");
                        searchUsers();
                    }
                    //}

                    

                }


                // Get Name input
                // Validate Name input
                // Maybe allow age Search as well ***
                // Loop and check for name
                // Output results


                // Return back to menu (AFTER search ends)
                // * Maybe enter Null if done searching? Or just press a Key (Y/N/F)


                //Console.WriteLine("Search");

                finishOption();
            }
            public void removeUsers()
            {
                startOption("Removing");

                // Check for people in system

                // Check for people in system             
                if (people.Count == 0)
                {
                    Console.WriteLine("There are currently no users in the system. Create a user with option 1.");
                    finishOption();

                }
                else
                {

                    // Output list of users
                    printAllUsers();

                    // allow selection
                    Console.Write("Enter an Index: ");

                    // validate selection                
                    bool tryParseRemove = int.TryParse(Console.ReadLine(), out int indexSelect);   // Parsing the Index Selection input

                    indexSelect--;  // To match the actual list index


                    if (tryParseRemove && indexSelect >= 0 && indexSelect < people.Count)
                    {

                        // remove user, print message
                        people.RemoveAt(indexSelect);
                        Console.WriteLine("Successfully removed a person!");

                        finishOption();

                    }
                    else
                    {
                        errorMessage("Invalid Index! Please enter a valid Index to edit.");
                        removeUsers();
                    }

                }
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

                for (int i = 1; i < people.Count + 1; i++)
                {
                    Console.WriteLine(i + ". " + people[i - 1].returnDetails());  // return details for each person in list
                }

                /* Removed people. Count validation as this will be implemented directly in function.
                 * We only run the other processes if the people count isnt 0 */

                //if (people.Count == 0)
                //{
                //    Console.WriteLine("There are currently no users in the system. Create a user with option 1.");
                //}
                //else
                //{
                //    for (int i = 1; i < people.Count + 1; i++)
                //    {
                //        Console.WriteLine(i + ". " + people[i - 1].returnDetails());  // return details for each person in list
                //    }
                //}
            }

            // we want to return a Person, not void
            public Person returnPerson()
            {
                // Enter name

                Console.Write("Enter a name: ");
                string nameInput = Console.ReadLine();

                // Enter age
                Console.Write("Enter age: ");

                bool tryParseAge = int.TryParse(Console.ReadLine(), out int ageInput);   // Parsing the Age Input


                // Validating Name input
                if (!string.IsNullOrEmpty(nameInput))
                {
                    if (tryParseAge && ageInput > 0 && ageInput < 150)  // Validating age Range
                    {

                        return new Person(nameInput, ageInput); // returns new person if successful

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

                return null;    // returns Null in case of error, as error lines do not return anything

            }

            public bool isSystemEmpty()
            {
                if (people.Count == 0)
                {
                    Console.WriteLine("There are currently no users in the system. Create a user with option 1.");
                    return true;
                }
                else
                {

                    return false;
                }
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

            Console.WriteLine("Press <Enter> Again to close the app. \n Goodbye! ");

            Console.ReadLine();
        }
    }
}
