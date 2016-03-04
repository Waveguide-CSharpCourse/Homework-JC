using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations_Console
{
    class Person
    {
        // class members
        string firstName;
        string lastName;
        int ID;

        string phoneNumber;
        int luggageQuantity;

        private static int ID_index = 1;

        private static Dictionary<int, string> listOfPersons = new Dictionary<int, string>();

        public Person (string NameFirst, string NameLast,string PhoneNumber, int LuggageQty)
        {
            firstName = NameFirst;
            lastName = NameLast;
            ID = ID_index++;
            string name = firstName + " " + lastName;
            
            phoneNumber = PhoneNumber;
            luggageQuantity = LuggageQty;

            listOfPersons.Add(ID, name);
        }

        public int getID()
        {
            return ID;
        }

        public static string returnName(int ID)
        {
            string name = "";
            if (listOfPersons.ContainsKey(ID))
            {
                name = listOfPersons[ID];
            }
            return name;
        }

        public static int returnIDfromName(string name)
        {
            int ID = 0;
            if (listOfPersons.ContainsValue(name))
            {
                foreach (KeyValuePair<int, string> pair in listOfPersons)
                {
                    if (pair.Value.Equals(name))
                    {
                        ID = pair.Key;
                        break;
                    }
                }
            }
            return ID;
        }

    }
}
