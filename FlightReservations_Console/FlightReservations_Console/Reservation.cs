using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This application will create 2 flights - 1 each on a 5 seat passenger plane
// the user can add them selves to a reservation list, see the flight info,
// and see the reservation list


namespace FlightReservations_Console
{
    class Reservation
    {
        Flight flight1;
        Flight flight2;

        static void Main(string[] args)
        {
            // create an instance of this class - to call its instance members, and other classes
            Reservation localReserv = new Reservation();

            // create 2 flights
            // flight 1
            string flight1_num = "WG123";
            string departCity1 = "Atlanta";
            string arrivalCity1 = "Chicago";
            DateTime departTime1 = DateTime.Today.AddMonths(5);
            DateTime arrivalTime1 = DateTime.Today.AddMonths(5);
            localReserv.flight1 = new Flight(flight1_num, departCity1, arrivalCity1, departTime1, arrivalTime1);

            // flight 2
            string flight2_num = "WG456";
            string departCity2 = "Atlanta";
            string arrivalCity2 = "Chicago";
            DateTime departTime2 = DateTime.Today.AddMonths(6);
            DateTime arrivalTime2 = DateTime.Today.AddMonths(6);
            localReserv.flight2 = new Flight(flight2_num, departCity2, arrivalCity2, departTime2, arrivalTime2);

            bool reservingFlights = true;
            // Prompt User to do things
            while (reservingFlights)
            {
                Console.WriteLine("Select:  A=Add Person, R=Remove Person, V=View Flight info, Q=quit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "A":
                        localReserv.AddPerson();
                        break;
                    case "R":
                        localReserv.RemovePerson();
                        break;
                    case "V":
                        localReserv.displayFlightInfo();
                        break;
                    case "Q":
                        reservingFlights = false;
                        break;
                    default:
                        Console.WriteLine("Sorry, not an option");
                        break;
                }

            }

        }

        void AddPerson()
        {
            // create a person
            Console.Write("Enter First Name: ");
            string Fname = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string Lname = Console.ReadLine();

            var formatTxt = new System.Globalization.CultureInfo("en-US", false).TextInfo;
            Fname = formatTxt.ToTitleCase(Fname).Trim();
            Lname = formatTxt.ToTitleCase(Lname).Trim();

            string fullName = Fname + " " + Lname;
            int LQty,Pnum;

            Console.Write("Enter Phone Number: ");
            int.TryParse(Console.ReadLine(), out Pnum);
            string PNumber = String.Format("{0:(###) ###-####}", Pnum);
            
            Console.Write("Enter number of bags to check in: ");
            int.TryParse(Console.ReadLine(),out LQty);

            int tempID = Person.returnIDfromName(fullName);

            // need to check before creating a new person
            if (tempID == 0)
            {
                Person aPerson = new Person(Fname, Lname,PNumber,LQty);
                tempID = aPerson.getID();
            }

            // add them to a flight
            Console.Write("Add person to Flight 1 or 2: ");
            int flightNum;
            bool success1 = int.TryParse(Console.ReadLine(), out flightNum);
            if (success1 && ((flightNum == 1) || (flightNum == 2)))
            {
                bool success = Flight.AddPersonToFlt(flightNum, tempID);
                if (!success) Console.WriteLine("That person is already on the reservation list or flight is full");

            }
            else
            {
                Console.WriteLine("Sorry there was an error with your input");
            }
            return;
        }

        void RemovePerson()
        {
            // who to remove
            Console.Write("Enter First Name: ");
            string Fname = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string Lname = Console.ReadLine();

            var formatTxt = new System.Globalization.CultureInfo("en-US", false).TextInfo;

            string fullName = formatTxt.ToTitleCase(Fname).Trim() + " " + formatTxt.ToTitleCase(Lname).Trim();

            // remove them from flight
            Console.Write("Remove person from Flight 1 or 2: ");
            int flightNum;
            bool success1 = int.TryParse(Console.ReadLine(), out flightNum);
            if (success1 && ((flightNum == 1) || (flightNum == 2)))
            {
                bool success = Flight.RemovePersonFromFlt(flightNum, Person.returnIDfromName(fullName));
                if (!success) Console.WriteLine("That person is not on the reservation list");
            }
            else
            {
                Console.WriteLine("Sorry there was an error with your input");
            }
            return;
        }

        void displayFlightInfo()
        {
            Console.WriteLine("Flight 1 Info: ");
            Console.WriteLine("  Flight Number: {0}", flight1.flight_number);
            Console.WriteLine("  Departure City: {0}", flight1.depart_city);
            Console.WriteLine("  Arrival City: {0}", flight1.arrival_city);
            Console.WriteLine("  Departure Time: {0}", flight1.departure_time);
            Console.WriteLine("  Arrival Time: {0}", flight1.arrival_time);
            Flight.DisplayReservationList(1);
            Console.WriteLine(" ");
            Console.WriteLine("Flight 2 Info: ");
            Console.WriteLine("  Flight Number: {0}", flight2.flight_number);
            Console.WriteLine("  Departure City: {0}", flight2.depart_city);
            Console.WriteLine("  Arrival City: {0}", flight2.arrival_city);
            Console.WriteLine("  Departure Time: {0}", flight2.departure_time);
            Console.WriteLine("  Arrival Time: {0}", flight2.arrival_time);
            Flight.DisplayReservationList(2);
            Console.WriteLine(" ");
        }



    }
}
