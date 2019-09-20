using System.Collections.Generic;

namespace SearchRooms
{
    public class Room
    {
        public string RoomNumber { get; set; }

        public Room(string rn)
        {
            RoomNumber = rn;
        }

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

    public class SearchForRoom
    {
        private string[] rooms;
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

        public void FindRoomPDF(string input)
        {
            string finalString = "";

            if (RoomsContains(input))
            {
                finalString = "C:\\Users\\Public\\Intuiface\\1-6d0c4909-3644\\Files\\Documents\\" +  input + ".pdf";
                RoomPath = finalString;
            }
            else
            {
                RoomPath = "room. Please try again";
            }
        }

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
