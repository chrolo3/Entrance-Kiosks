using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace DataBaseHandlerDebugger
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseHandler dbh = new DataBaseHandler();
            dbh.UpdateAll();
            dbh.GenerateAdvisors();

            dbh.MainOfficeNetIds.Add("kclague");
            dbh.MainOfficeNetIds.Add("skharris");
            dbh.GenerateMainOffices();

            dbh.CreateObjectsJson();

            dbh.SearchAllInPeople("jason");
        }
    }

    public class DataBaseHandler
    {
        private List<StaffFaculty> people = new List<StaffFaculty>();
        private List<Faculty> Pfaculty = new List<Faculty>();
        private List<Staff> Pstaff = new List<Staff>();
        private List<StaffFaculty> advisors = new List<StaffFaculty>();
        private List<StaffFaculty> mainOffice = new List<StaffFaculty>();
        private List<StaffFaculty> faculty = new List<StaffFaculty>();
        private List<StaffFaculty> staff = new List<StaffFaculty>();
        private List<StaffFaculty> searchedList = new List<StaffFaculty>();
        private List<string> mainOfficeNetIds = new List<string>();

        public List<StaffFaculty> People
        {
            get { return people; }
            set { people = value; }
        }
        public List<StaffFaculty> Advisors
        {
            get { return advisors; }
            set { advisors = value; }
        }
        public List<StaffFaculty> MainOffice
        {
            get { return mainOffice; }
            set { mainOffice = value; }
        }
        public List<StaffFaculty> Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }
        public List<StaffFaculty> Staff
        {
            get { return staff; }
            set { staff = value; }
        }
        public List<StaffFaculty> SearchedList
        {
            get { return searchedList; }
            set { searchedList = value; }
        }
        public List<string> MainOfficeNetIds
        {
            get { return mainOfficeNetIds; }
            set { MainOfficeNetIds = value; }
        }


        public DataBaseHandler()
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                CreateJsonObjects();
                CombineStaffandFaculty(Pstaff, Pfaculty);
            }
            else
            {
                LoadFromGeneratedFiles();
            }

            MainOfficeNetIds.Add("kclague");
            MainOfficeNetIds.Add("skharris");

            GenerateAdvisors();
            GenerateMainOffices();

            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                CreateObjectsJson();
            }
        }

        public void UpdateAll()
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                CreateJsonObjects();
                CombineStaffandFaculty(Pstaff, Pfaculty);
            }
            else
            {
                LoadFromGeneratedFiles();
            }

            GenerateAdvisors();
            GenerateMainOffices();

            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                CreateObjectsJson();
            }
        }

        public void SearchAllInPeople(string ss)
        {
            SearchedList = new List<StaffFaculty>();
            foreach (StaffFaculty sf in people)
            {
                if (sf.title.rendered.Contains(ss, StringComparison.OrdinalIgnoreCase))
                {
                    SearchedList.Add(sf);
                }
                else if (sf.netid.Contains(ss, StringComparison.OrdinalIgnoreCase))
                {
                    SearchedList.Add(sf);
                }
                else if (sf.office.Contains(ss, StringComparison.OrdinalIgnoreCase))
                {
                    SearchedList.Add(sf);
                }
            }
        }

        public void SearchByNameInPeople(string ss)
        {
            SearchedList = new List<StaffFaculty>();
            foreach (StaffFaculty sf in people)
            {
                if (sf.title.rendered.Contains(ss, StringComparison.OrdinalIgnoreCase))
                {
                    SearchedList.Add(sf);
                }
            }
        }

        public void SearchByNetIdInPeople(string ss)
        {
            SearchedList = new List<StaffFaculty>();
            foreach (StaffFaculty sf in people)
            {
                if (sf.netid.Contains(ss, StringComparison.OrdinalIgnoreCase))
                {
                    SearchedList.Add(sf);
                }
            }
        }

        public void SearchByRoomInPeople(string ss)
        {
            SearchedList = new List<StaffFaculty>();
            foreach (StaffFaculty sf in people)
            {
                if (sf.office.Contains(ss, StringComparison.OrdinalIgnoreCase))
                {
                    SearchedList.Add(sf);
                }
            }
        }

        //Convert json files to objects
        public void CreateJsonObjects()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://www.engineering.iastate.edu/people/wp-json/wp/v2/profile?page=1&per_page=100&orderby=title&order=asc&context=view&department=1121%2C1122%2C1123%2C1124%2C1125");

            using (StreamReader r = new StreamReader(stream))
            {
                string json = r.ReadToEnd();
                Pfaculty = JsonConvert.DeserializeObject<List<Faculty>>(json);
            }

            stream = client.OpenRead("https://www.engineering.iastate.edu/people/wp-json/wp/v2/profile?page=1&per_page=100&orderby=title&order=asc&context=embed&department=1126");

            using (StreamReader r = new StreamReader(stream))
            {
                string json = r.ReadToEnd();
                Pstaff = JsonConvert.DeserializeObject<List<Staff>>(json);
            }
        }

        private void LoadFromGeneratedFiles()
        {
            using (StreamReader r = File.OpenText(@"C:\IntuifaceCommon\People.json"))
            {
                People = new List<StaffFaculty>();
                string json = r.ReadToEnd();
                People = JsonConvert.DeserializeObject<List<StaffFaculty>>(json);
            }
            using (StreamReader r = File.OpenText(@"C:\IntuifaceCommon\Staff.json"))
            {
                Staff = new List<StaffFaculty>();
                string json = r.ReadToEnd();
                Staff = JsonConvert.DeserializeObject<List<StaffFaculty>>(json);
            }
            using (StreamReader r = File.OpenText(@"C:\IntuifaceCommon\Faculty.json"))
            {
                Faculty = new List<StaffFaculty>();
                string json = r.ReadToEnd();
                Faculty = JsonConvert.DeserializeObject<List<StaffFaculty>>(json);
            }
        }

        //Create all json files for easy use in intuiface
        public void CreateObjectsJson()
        {
            using (StreamWriter file = File.CreateText(@"C:\IntuifaceCommon\People.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, People);
            }
            using (StreamWriter file = File.CreateText(@"C:\IntuifaceCommon\Advisors.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Advisors);
            }
            using (StreamWriter file = File.CreateText(@"C:\IntuifaceCommon\MainOffice.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, MainOffice);
            }
            using (StreamWriter file = File.CreateText(@"C:\IntuifaceCommon\Faculty.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Faculty);
            }
            using (StreamWriter file = File.CreateText(@"C:\IntuifaceCommon\Staff.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Staff);
            }
        }

        public void CombineStaffandFaculty(List<Staff> staff, List<Faculty> faculty)
        {
            foreach (Staff s in staff)
            {
                StaffFaculty sf = new StaffFaculty();
                StaffFaculty.staffConvert(out sf, s);
                people.Add(sf);
                Staff.Add(sf);
            }
            foreach (Faculty f in faculty)
            {
                StaffFaculty sf = new StaffFaculty();
                StaffFaculty.facultyConvert(out sf, f);
                people.Add(sf);
                Faculty.Add(sf);
            }
        }

        public void GenerateAdvisors()
        {
            foreach (StaffFaculty sf in people)
            {
                if (sf.isu_title.Length > 16)
                {
                    if (String.Compare(sf.isu_title.Remove(16), "Academic Adviser") == 0)
                    {
                        Advisors.Add(sf);
                    }
                }
            }
        }

        public void GenerateMainOffices()
        {
            foreach (StaffFaculty sf in people)
            {
                foreach (string id in MainOfficeNetIds)
                {
                    if (sf.netid == id)
                    {
                        mainOffice.Add(sf);
                    }
                }
            }
        }
    }

    #region Classes...
    public class Guid
    {
        public string rendered { get; set; }
    }

    public class Title
    {
        public string rendered { get; set; }
    }

    public class UserImage
    {
        public string ID { get; set; }
        public string post_author { get; set; }
        public string post_date { get; set; }
        public string post_date_gmt { get; set; }
        public string post_content { get; set; }
        public string post_title { get; set; }
        public string post_excerpt { get; set; }
        public string post_status { get; set; }
        public string comment_status { get; set; }
        public string ping_status { get; set; }
        public string post_password { get; set; }
        public string post_name { get; set; }
        public string to_ping { get; set; }
        public string pinged { get; set; }
        public string post_modified { get; set; }
        public string post_modified_gmt { get; set; }
        public string post_content_filtered { get; set; }
        public string post_parent { get; set; }
        public string guid { get; set; }
        public string menu_order { get; set; }
        public string post_type { get; set; }
        public string post_mime_type { get; set; }
        public string comment_count { get; set; }
        public string pod_item_id { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Collection
    {
        public string href { get; set; }
    }

    public class About
    {
        public string href { get; set; }
    }

    public class Author
    {
        public bool embeddable { get; set; }
        public string href { get; set; }
    }

    public class WpAttachment
    {
        public string href { get; set; }
    }

    public class WpTerm
    {
        public string taxonomy { get; set; }
        public bool embeddable { get; set; }
        public string href { get; set; }
    }

    public class Cury
    {
        public string name { get; set; }
        public string href { get; set; }
        public bool templated { get; set; }
    }

    public class Links
    {
        public List<Self> self { get; set; }
        public List<Collection> collection { get; set; }
        public List<About> about { get; set; }
        public List<Author> author { get; set; }
        public List<WpAttachment> __invalid_name__wpAttachment { get; set; }
        public List<WpTerm> __invalid_name__wpTerm { get; set; }
        public List<Cury> curies { get; set; }
    }

    public class Faculty
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public DateTime date_gmt { get; set; }
        public Guid guid { get; set; }
        public DateTime modified { get; set; }
        public DateTime modified_gmt { get; set; }
        public string slug { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public Title title { get; set; }
        public int author { get; set; }
        public string template { get; set; }
        public List<int> affiliation { get; set; }
        public List<int> department { get; set; }
        public List<object> group { get; set; }
        public List<object> interest { get; set; }
        public string netid { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string nickname { get; set; }
        public string middle_name { get; set; }
        public string lastname { get; set; }
        public UserImage user_image { get; set; }
        public string phone_number { get; set; }
        public string fax { get; set; }
        public string user_title { get; set; }
        public string isu_title { get; set; }
        public string hide_isu_title { get; set; }
        public string office { get; set; }
        public string isu_office { get; set; }
        public string hide_isu_office { get; set; }
        public string external_link { get; set; }
        public string info { get; set; }
        public string publications { get; set; }
        public Links links { get; set; }
    }

    public class Staff
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string slug { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public Title title { get; set; }
        public int author { get; set; }
        public string netid { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string nickname { get; set; }
        public string middle_name { get; set; }
        public string lastname { get; set; }
        public UserImage user_image { get; set; }
        public string phone_number { get; set; }
        public string fax { get; set; }
        public string user_title { get; set; }
        public string isu_title { get; set; }
        public object hide_isu_title { get; set; }
        public string office { get; set; }
        public string isu_office { get; set; }
        public object hide_isu_office { get; set; }
        public string external_link { get; set; }
        public string info { get; set; }
        public string publications { get; set; }
        public Links _links { get; set; }
    }

    public class StaffFaculty
    {
        public string employeeType { get; set; }
        public int id { get; set; }
        public DateTime date { get; set; }
        public DateTime date_gmt { get; set; }
        public Guid guid { get; set; }
        public DateTime modified { get; set; }
        public DateTime modified_gmt { get; set; }
        public string slug { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public Title title { get; set; }
        public int author { get; set; }
        public string template { get; set; }
        public List<int> affiliation { get; set; }
        public List<int> department { get; set; }
        public List<object> group { get; set; }
        public List<object> interest { get; set; }
        public string netid { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string nickname { get; set; }
        public string middle_name { get; set; }
        public string lastname { get; set; }
        public UserImage user_image { get; set; }
        public string phone_number { get; set; }
        public string fax { get; set; }
        public string user_title { get; set; }
        public string isu_title { get; set; }
        public string hide_isu_title { get; set; }
        public string office { get; set; }
        public string isu_office { get; set; }
        public string hide_isu_office { get; set; }
        public string external_link { get; set; }
        public string info { get; set; }
        public string publications { get; set; }
        public Links links { get; set; }

        public StaffFaculty()
        {
            employeeType = "unassigned";
            id = -1;
            //date = staff.date;
            //date_gmt = null;
            guid = null;
            //modified = null;
            //modified_gmt = null;
            slug = "unassigned";
            status = null;
            type = "unassigned";
            link = "unassigned";
            //title = "unassigned";
            //author = "unassigned";
            template = null;
            affiliation = null;
            department = new List<int>();
            group = null;
            interest = null;
            netid = "unassigned";
            email = "unassigned";
            firstname = "unassigned";
            nickname = "unassigned";
            middle_name = "unassigned";
            lastname = "unassigned";
            //user_image = "unassigned";
            phone_number = "unassigned";
            fax = "unassigned";
            user_title = "unassigned";
            isu_title = "unassigned";
            hide_isu_title = "false";
            office = "unassigned";
            office = "unassigned";
            hide_isu_office = "false";
            external_link = "unassigned";
            info = "unassigned";
            publications = "unassigned";
            links = new Links();
        }

        public static void staffConvert(out StaffFaculty sf, Staff staff)
        {
            sf = new StaffFaculty();
            sf.employeeType = "Staff";
            sf.id = staff.id;
            sf.date = staff.date;
            //date_gmt = null;
            sf.guid = null;
            //modified = null;
            //modified_gmt = null;
            sf.slug = staff.slug;
            sf.status = null;
            sf.type = staff.type;
            sf.link = staff.link;
            sf.title = staff.title;
            sf.author = staff.author;
            sf.template = null;
            sf.affiliation = null;
            sf.department = new List<int>();
            sf.group = null;
            sf.interest = null;
            sf.netid = staff.netid;
            sf.email = staff.email;
            sf.firstname = staff.firstname;
            sf.nickname = staff.nickname;
            sf.middle_name = staff.middle_name;
            sf.lastname = staff.lastname;
            sf.user_image = staff.user_image;
            sf.phone_number = staff.phone_number;
            sf.fax = staff.fax;
            sf.user_title = staff.user_title;
            sf.isu_title = staff.isu_title;
            sf.hide_isu_title = "false";
            sf.office = (staff.isu_office.Length - 1 > 4) ? staff.isu_office.Remove(4) : staff.isu_office;
            sf.hide_isu_office = "false";
            sf.external_link = staff.external_link;
            sf.info = staff.info;
            sf.publications = staff.publications;
            sf.links = new Links();
        }

        public static void facultyConvert(out StaffFaculty sf, Faculty faculty)
        {
            sf = new StaffFaculty();
            sf.employeeType = "Faculty";
            sf.id = faculty.id;
            sf.date = faculty.date;
            sf.date_gmt = faculty.date_gmt;
            sf.guid = faculty.guid;
            sf.modified = faculty.modified;
            sf.modified_gmt = faculty.modified_gmt;
            sf.slug = faculty.slug;
            sf.status = faculty.status;
            sf.type = faculty.type;
            sf.link = faculty.link;
            sf.title = faculty.title;
            sf.author = faculty.author;
            sf.template = faculty.template;
            sf.affiliation = faculty.affiliation;
            sf.department = faculty.department;
            sf.group = faculty.group;
            sf.interest = faculty.interest;
            sf.netid = faculty.netid;
            sf.email = faculty.email;
            sf.firstname = faculty.firstname;
            sf.nickname = faculty.nickname;
            sf.middle_name = faculty.middle_name;
            sf.lastname = faculty.lastname;
            sf.user_image = faculty.user_image;
            sf.phone_number = faculty.phone_number;
            sf.fax = faculty.fax;
            sf.user_title = faculty.user_title;
            sf.isu_title = faculty.isu_title;
            sf.hide_isu_title = faculty.hide_isu_title;
            sf.office = (faculty.isu_office.Length - 1 > 4) ? faculty.isu_office.Remove(4) : faculty.isu_office;
            sf.isu_office = faculty.isu_office;
            int tempint = faculty.isu_office.IndexOf('$');
            sf.isu_office = faculty.isu_office.Substring(0, tempint >= 0 ? tempint - 1 : 0);
            sf.hide_isu_office = faculty.hide_isu_office;
            sf.external_link = faculty.external_link;
            sf.info = faculty.info;
            sf.publications = faculty.publications;
            sf.links = faculty.links;
        }

    }
    #endregion
}

public static class StringExtensions
{
    public static bool Contains(this String str, String substring,
                                StringComparison comp)
    {
        if (substring == null)
            throw new ArgumentNullException("substring",
                                         "substring cannot be null.");
        else if (!Enum.IsDefined(typeof(StringComparison), comp))
            throw new ArgumentException("comp is not a member of StringComparison",
                                     "comp");

        return str.IndexOf(substring, comp) >= 0;
    }
}