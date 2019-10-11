using System.Collections.Generic;

namespace SearchRooms
{
    /// <summary>
    /// Describes what a room is in our scope.
    /// </summary>
    public class Room
    {
        public string RoomNumber { get; set; }

        public Room(string rn)
        {
            RoomNumber = rn;
        }

        /// <summary>
        /// Function that creates a list of rooms based on a string array.
        /// </summary>
        /// <param name="sra">String array to convert.</param>
        /// <returns>returns a list of rooms</returns>
        public static List<Room> SetRooms(string [] sra)
        {
            List<Room> output = new List<Room>();
            for (int x = 0; x < sra.Length; x++)
            {
                output.Add(new Room(sra[x]));
            }
            return output;
        }
    }

    /// <summary>
    /// This class allows the user to input a room number and search for it from a list of all the room numbers at coover hall.
    /// </summary>
    public class SearchForRoom
    {
        private string[] rooms;
        /// <summary>
        /// List of all rooms to search from
        /// </summary>
        public string [] Rooms
        {
            get
            {
                return rooms;
            }
            set
            {
                rooms = value;
            }
        }

        private string roomPath;
        /// <summary>
        /// Output path in the C directory to the room documents.
        /// </summary>
        public string RoomPath
        {
            get
            {
                return roomPath;
            }
            set
            {
                roomPath = value;
            }
        }

        private List<Room> allRooms;
        /// <summary>
        /// List of all rooms that can be searched for.
        /// </summary>
        public List<Room> AllRooms
        {
            get
            {
                return allRooms;
            }
            set
            {
                allRooms = value;
            }
        }

        private List<Room> conferenceRooms;
        /// <summary>
        /// List of all conference rooms.
        /// </summary>
        public List<Room> ConferenceRooms
        {
            get
            {
                return conferenceRooms;
            }
            set
            {
                conferenceRooms = value;
            }
        }

        private List<Room> studentServices;
        /// <summary>
        /// List of student services rooms.
        /// </summary>
        public List<Room> StudentServices
        {
            get
            {
                return studentServices;
            }
            set
            {
                studentServices = value;
            }
        }

        private List<Room> acedemicOffices;
        /// <summary>
        /// List of acedemic offices.
        /// </summary>
        public List<Room> AcedemicOffices
        {
            get
            {
                return acedemicOffices;
            }
            set
            {
                acedemicOffices = value;
            }
        }

        private List<Room> graduateOffices;
        /// <summary>
        /// List of graduate offices
        /// </summary>
        public List<Room> GraduateOffices
        {
            get
            {
                return graduateOffices;
            }
            set
            {
                graduateOffices = value;
            }
        }

        private List<Room> mainOffice;
        /// <summary>
        /// List of all rooms related to main office.
        /// </summary>
        public List<Room> MainOffice
        {
            get
            {
                return mainOffice;
            }
            set
            {
                mainOffice = value;
            }
        }

        private List<Room> administrativeOffices;
        /// <summary>
        /// List of all administrative offices.
        /// </summary>
        public List<Room> AdministrativeOffices
        {
            get
            {
                return administrativeOffices;
            }
            set
            {
                administrativeOffices = value;
            }
        }

        private List<Room> labs;
        /// <summary>
        /// List of all labs.
        /// </summary>
        public List<Room> Labs
        {
            get
            {
                return labs;
            }
            set
            {
                labs = value;
            }
        }

        /// <summary>
        /// Manipulate these variables if rooms need changed.
        /// </summary>
        public SearchForRoom()
        {
            RoomPath = "room. Please try again";
            Rooms = new string[] {
                "1011", "1012", "1016", "1041", "1042",
                "1045", "1046", "1048", "1050", "1101",
                "1102", "1111", "1113", "1115", "1117",
                "1121", "1122", "1124", "1125", "1126",
                "1129", "1130", "1131", "1132", "1201",
                "1207", "1212", "1213", "1219", "1301",
                "1313", "1316", "1318", "1331", "2011",
                "2014", "2018", "2041", "2042", "2046",
                "2048", "2050", "2061", "2105", "2113",
                "2115", "2117", "2121", "2124", "2126",
                "2128", "2129", "2130", "2132", "2133",
                "2134", "2135", "2201", "2202", "2205",
                "2208", "2210", "2211", "2212", "2214",
                "2215", "2216", "2218", "2222", "2245",
                "3011", "3013", "3014", "3018", "3038",
                "3041", "3042", "3043", "3046", "3050",
                "3065", "3101", "3102", "3107", "3108",
                "3112", "3113", "3119", "3121", "3123",
                "3125", "3126", "3128", "3131", "3132",
                "3133", "3134", "3138", "3201", "3202",
                "3208", "3209", "3212", "3214", "3215",
                "3216", "3217", "3218", "3219", "3222",
                "3223", "3224", "3227", "3231"
                };
            AllRooms = new List<Room>();
            AllRooms = Room.SetRooms(new string[] {
                "1011", "1012", "1016", "1041", "1042",
                "1045", "1046", "1048", "1050", "1101",
                "1102", "1111", "1113", "1115", "1117",
                "1121", "1122", "1124", "1125", "1126",
                "1129", "1130", "1131", "1132", "1201",
                "1207", "1212", "1213", "1219", "1301",
                "1313", "1316", "1318", "1331", "2011",
                "2014", "2018", "2041", "2042", "2046",
                "2048", "2050", "2061", "2105", "2113",
                "2115", "2117", "2121", "2124", "2126",
                "2128", "2129", "2130", "2132", "2133",
                "2134", "2135", "2201", "2202", "2205",
                "2208", "2210", "2211", "2212", "2214",
                "2215", "2216", "2218", "2222", "2245",
                "3011", "3013", "3014", "3018", "3038",
                "3041", "3042", "3043", "3046", "3050",
                "3065", "3101", "3102", "3107", "3108",
                "3112", "3113", "3119", "3121", "3123",
                "3125", "3126", "3128", "3131", "3132",
                "3133", "3134", "3138", "3201", "3202",
                "3208", "3209", "3212", "3214", "3215",
                "3216", "3217", "3218", "3219", "3222",
                "3223", "3224", "3227", "3231"
                });
            ConferenceRooms = new List<Room>();
            ConferenceRooms = Room.SetRooms(new string[] {
                "2205", "2222", "3041", "3043", "3138"
                });
            StudentServices = new List<Room>();
            StudentServices = Room.SetRooms(new string[] {
                "1212", "1219"
                });
            AcedemicOffices = new List<Room>();
            AcedemicOffices = Room.SetRooms(new string[] {
                "1111", "1113", "1115", "1117", "1122",
                "1124", "1126", "1129", "1130", "2113",
                "2115", "2117", "2124", "2126", "2128",
                "2129", "2130", "2132", "2133", "2134",
                "2214", "2216", "2218", "3107", "3112",
                "3119", "3121", "3123", "3128", "3131",
                "3132", "3134", "3202", "3212", "3215",
                "3217", "3222", "3227"
                });
            MainOffice = new List<Room>();
            MainOffice = Room.SetRooms(new string[] {
                "2215"
                });
            AdministrativeOffices = new List<Room>();
            AdministrativeOffices = Room.SetRooms(new string[] {
                "2208", "2210", "2211", "2212"
                });
            GraduateOffices = new List<Room>();
            GraduateOffices = Room.SetRooms(new string[] {
                "1121", "1131", "1132", "1201", "1207",
                "2105", "2121", "2135", "2201", "3042",
                "3101", "3102", "3108", "3113", "3125",
                "3126", "3133", "3201", "3208", "3209",
                "3214", "3219", "3223", "3224", "3231"
                });
            Labs = new List<Room>();
            Labs = Room.SetRooms(new string[] {
                "1041", "1102", "1301", "1313", "1318",
                "2011", "2014", "2018", "2041", "2042",
                "2046", "2048", "2050", "2061"
                });
        }
        
        /// <summary>
        /// Searches for a room and changes the roompath variable
        /// </summary>
        /// <param name="input">The room number to input.</param>
        public void FindRoomPDF(string input)
        {
            string finalString = "";

            if (RoomsContains(input))
            {
                // This is the path to the intuiface player installation of the project. Change only if you must.
                finalString = "C:\\IntuifaceUtilities\\BuildingMapPDFs\\" +  input + ".pdf";
                RoomPath = finalString;
            }
            else
            {
                //No room path was found.
                RoomPath = "room. Please try again";
            }
        }

        /// <summary>
        /// Does the Rooms list contain a certain Room
        /// </summary>
        /// <param name="x">Room number as string to find.</param>
        /// <returns>Returns whether the room exists or not.</returns>
        private bool RoomsContains(string x)
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                if (x == rooms[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
