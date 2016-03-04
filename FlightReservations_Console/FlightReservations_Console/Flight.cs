using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations_Console
{
    class Flight
    {
        private const int maxSeats = 5;

        private string flightNumber;
        private string departCity;
        private string arrivalCity;
        private DateTime departTime;
        private DateTime arrivalTime;
        private int id;
        private static int flightID=1;
        private static Dictionary<int, int> flightManifest = new Dictionary<int, int>(); // <FlightID,PersonID>

        public string flight_number { get { return this.flightNumber; } }
        public string depart_city { get { return this.departCity; } }
        public string arrival_city { get { return this.arrivalCity; } }
        public DateTime departure_time { get { return this.departTime; } }
        public DateTime arrival_time { get { return this.arrivalTime; }}
        public int flight_id { get { return this.id; } }

        public Flight(string flightNumber, string departCity, string arrivalCity, DateTime departTime, DateTime arrivalTime) {
            this.flightNumber = flightNumber;
            this.departCity = departCity;
            this.arrivalCity = arrivalCity;
            this.departTime = departTime;
            this.arrivalTime = arrivalTime;
            this.id = flightID++;
        }

        public static bool AddPersonToFlt(int FlightID, int PersonID) {
            bool result=false;
            int seats = GetAvailableSeats(FlightID);
            if (seats > 0) {
                if (flightManifest.ContainsKey(PersonID) == false) {
                    flightManifest.Add(PersonID, FlightID);
                    result = true;
                }
                
            }
            return result;
        }

        public static bool RemovePersonFromFlt(int FlightID, int PersonID)
        {
            bool result = false;
            if (flightManifest.ContainsKey(PersonID) == true)
            {
                flightManifest.Remove(PersonID);
                result = true;
            }
            return result;
        }

        public static void DisplayReservationList(int FlightID) {
            if (flightManifest.ContainsValue(FlightID))
            {
                foreach (var passanger in flightManifest) {
                    if (passanger.Value == FlightID) {
                        Console.WriteLine(Person.returnName(passanger.Key));
                    }
                }
            }
            else {
                Console.WriteLine("There is no passangers in flight{0}: ", FlightID);
            }
        }

        private static int GetAvailableSeats(int FlightID) {
            int result = 0;

            if (flightManifest.ContainsValue(FlightID)) {
                foreach (var passanger in flightManifest) {
                    if (passanger.Value == FlightID) {
                        result++;
                    }
                }
            }
            return maxSeats - result;
        }
    }
}
