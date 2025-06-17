using LibraryDV.Repos;
using LibraryDV.Services;
using LibraryDV.Models;

namespace ExamPaper

{
    public class Program
    {

        public static void Main(string[] args)
        {

            ///////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////// INSTANCIATING REPOSITORIES AND SERVICES /////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////


            // Repo Instances
            IActivityRepo activityRepo = new ActivityRepo();
            IAnimalRepo animalRepo = new AnimalRepo();
            IBlogPostRepo blogPostRepo = new BlogPostRepo();
            IBookingRepo bookingRepo = new BookingRepo();
            IUserRepo userRepo = new UserRepo();

            // Service Instances
            ActivityService activityService = new ActivityService(activityRepo);
            AnimalService animalService = new AnimalService(animalRepo);
            BlogPostService blogPostService = new BlogPostService(blogPostRepo);
            BookingService bookingService = new BookingService(bookingRepo);
            UserServices userService = new UserServices(userRepo);

            ///////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////










            ///////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////// EXAMPLE CODE FOR PRINTING TO THE CONSOLE ////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////


            // Example code of printing all bookings to the console using a foreach-loop
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------ Start All Bookings | For-Each-Loop ------------");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Booking booking in bookingService.GetAllBookings())
            {
                string value = $"Booking Info: {booking.BookingID}, Name: {booking.UserID}, Animal: {booking.AnimalID}";
                Console.WriteLine(value);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------ End All Bookings | For-Each-Loop --------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            // End of example code of printing all bookings to the console using a foreach-loop

            ///////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////











            ///////////////////////////////////////////////////////////////////////////////////////////
            /////////////////// EXAMPLE CODE OF USING WHILE LOOP INSTEAD OF FOREACH ///////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////


            // Example code of printing all bookings to the console using a while-loop
            Console.WriteLine("------------ Start All Bookings | While-Loop ---------------");
            Console.ForegroundColor = ConsoleColor.White;
            var bookings = bookingService.GetAllBookings();
            int index = 0;
            while (index < bookings.Count)
            {
                Booking booking = bookings[index];
                Console.WriteLine($"Booking Info: {booking.BookingID}, Name: {booking.UserID}, Animal: {booking.AnimalID}");
                index++;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------ End All Bookings | While-Loop -----------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            // End of example code of printing all bookings to the console using a while-loop




            var animals = animalService.GetAllAnimals();
            foreach (Animal animal in animals)
            {
                Console.WriteLine($"Animal Info: {animal.AnimalID}, Name: {animal.Name}, Species: {animal.Type}");
            }



            // Filter and print animals where Type == 0
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------ Start Animals With Type 0 ---------------------");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Animal animal in animals)
            {
                if ((int)animal.Type == 0)
                {
                    Console.WriteLine($"Animal Info: {animal.AnimalID}, Name: {animal.Name}, Species: {animal.Type}");
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------ End Animals With Type 0 -----------------------");
            Console.ForegroundColor = ConsoleColor.White;





            // Example code of printing all activities to the console
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------ Start All Activities | For-Each-Loop ----------");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (LibraryDV.Models.Activity activity in activityService.GetAllActivities())
            {
                string value = $"Activity Info: {activity.ActivityID}, Name: {activity.ActivityTitle}";
                Console.WriteLine(value);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------ End All Activities | For-Each-Loop ------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////










            ///////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////// EXAMPLE CODE FOR HANDLING EXCEPTIONS ///////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////


            // Example code of printing all activities to the console using exception handling and throws and exception if less than 10 acitvities exists
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------ Start All Activities | Exception --------------");
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                List<LibraryDV.Models.Activity> activities = activityService.GetAllActivities();
                if (activities.Count < 10)
                {
                    throw new Exception("There are less than 10 activities available.");
                }
                foreach (LibraryDV.Models.Activity activity in activities)
                {
                    string value = $"Activity Info: {activity.ActivityID}, Name: {activity.ActivityTitle}";
                    Console.WriteLine(value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("THIS ALWAYS RUNS");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------ End All Activities | Exception ----------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            // Example code of printing all blog posts to the console using a foreach-loop with exception handling
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------ Start All Blog Posts | For-Each-Loop ----------");
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                List<LibraryDV.Models.BlogPost> blogposts = blogPostService.GetAllBlogPosts();
                if (blogposts.Count < 5)
                {
                    throw new Exception("There are less than 5 blog posts available.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------ End All Blog Posts | For-Each-Loop ------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////










            ///////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////// EXAMPLE CODE FOR INTERFACES EXAM TASK //////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////

            // Ask user if they want to clear the console before proceeding
            string? clearInput;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Do you want to clear the console before proceeding? (yes/no):");
                Console.ForegroundColor = ConsoleColor.White;
                clearInput = Console.ReadLine()?.ToLower();
            } while (clearInput != "yes" && clearInput != "no");

            if (clearInput == "yes")
            {
                Console.Clear();
            }

            // Create the repository and service
            IObjectRepo objectRepo = new ObjectRepo();
            ObjectService objectService = new ObjectService(objectRepo);

            // Add objects to the repository
            objectService.AddObject(new Object(1, "Object One", "Description for Object One"));
            objectService.AddObject(new Object(2, "Object Two", "Description for Object Two"));
            objectService.AddObject(new Object(3, "Object Three", "Description for Object Three"));
            objectService.AddObject(new Object(4, "Object Four", "Description for Object Four"));
            objectService.AddObject(new Object(5, "Object Five", "Description for Object Five"));
            objectService.AddObject(new Object(6, "Object Six", "Description for Object Six"));
            objectService.AddObject(new Object(7, "Object Seven", "Description for Object Seven"));
            objectService.AddObject(new Object(8, "Object Eight", "Description for Object Eight"));
            objectService.AddObject(new Object(9, "Object Nine", "Description for Object Nine"));
            objectService.AddObject(new Object(10, "Object Ten", "Description for Object Ten"));

            // Example code of getting an object by ID
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------ Start Get Object By ID -------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                "Enter the ID of the object you want to retrieve:");
            int id;
            try
            {
                while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive integer ID:");
                }
                Object? retrievedObject = objectService.GetObjectById(id);
                if (retrievedObject != null)
                {
                    Console.WriteLine($"Retrieved Object: ID = {retrievedObject.ID}, Name = {retrievedObject.Name}, Description = {retrievedObject.description}");
                }
                else
                {
                    throw new Exception($"No object found with ID: {id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            Console.ForegroundColor = ConsoleColor.Cyan;

            ///////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////










            ///////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////// EXAMPLE CODE FOR DICTIONARY EXAM TASK //////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////

            // Healthlog dictionary example with filter and search functionality
            Console.WriteLine("------------ Start Healthlog Dictionary Example ------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                "This example demonstrates how to create a dictionary, filter its contents, and search for specific keys.");
            Console.WriteLine("------------------------------------------------------------");
            // Example code of a dictionary with string keys and string values
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(

                "Example code of a dictionary with string keys and string values:");
            Dictionary<DateTime, string> test = animalService.GetAnimal(1).HealthLogs;
            foreach (var entry in test)
            {
                Console.WriteLine($"Date: {entry.Key.ToShortDateString()}, Log: {entry.Value}");
            }



            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("------------ End Healthlog Dictionary Example --------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Filtering the health logs by the string 'pre edit':");
            Dictionary<DateTime, string> filterTest = FilterByString("pre edit", test);

        }

        public static Dictionary<DateTime, string> FilterByString(string inputfilter, Dictionary<DateTime, string> inputDictionary)
        {
            Dictionary<DateTime, string> filteredLogs = new Dictionary<DateTime, string>();
            foreach(KeyValuePair<DateTime, string> filterTest in inputDictionary)
            {
                if (filterTest.Value.Contains(inputfilter))
                {
                    filteredLogs.Add(filterTest.Key, filterTest.Value);
                    Console.WriteLine($"Date: {filterTest.Key.ToShortDateString()}, Log: {filterTest.Value}");
                }
            }

            return filteredLogs;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

    }
}

