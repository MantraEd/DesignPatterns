<Query Kind="Program" />

void Main()
{
//A component in object orientation may be either an individual object or a collection of objects. The Composite pattern is designed to accommodate both cases. You can use the Composite to build part-whole hierarchies or to construct data representations of trees. In summary, a composite is a collection of objects, any one of which may be either a composite or just a primitive object. In tree nomenclature, some objects may be nodes with additional branches and some may be leaves. 

//* The intent of this pattern is to compose objects into tree structures to represent part-whole hierarchies.

//* Composite lets clients treat individual objects and compositions of objects uniformly.

	        IEmployee director = new Branch("Raghu", "Director", "GSE");
            IEmployee manager = new Branch("Naveen", "Manager", "GSE");
            IEmployee srTechSpec1 = new Branch("Rocky", "Sr. Technical Specialist", "GSE");
            IEmployee srTechSpec2 = new Branch("Saurav", "Sr. Technical Specialist", "GSE");
            IEmployee srSoftEng = new Leaf("Mahesh", "Sr. Software Engineer", "GSE");
            IEmployee softEng = new Leaf("Sunitha", "Software Engineer", "GSE");

            srTechSpec1.AddReportees(srSoftEng);
            srTechSpec2.AddReportees(softEng);

            manager.AddReportees(srTechSpec1);
            manager.AddReportees(srTechSpec2);

            director.AddReportees(manager);
            director.Display(1);
}

// Define other methods and classes here
public interface IEmployee
    {
        string Name { get; set; }
        string Department { get; set; }
        string Designation { get; set; }

        bool AddReportees(IEmployee employee);
        bool RemoveReportees(IEmployee employee);
        void Display(int level);
    }

    public class Branch : IEmployee
    {
        private IList<IEmployee> _Reportees = new List<IEmployee>();

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Department;
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        private string _Designation;
        public string Designation
        {
            get { return _Designation; }
            set { _Designation = value; }
        }

        public Branch(string name, string designation, string department)
        {
            this._Name = name;
            this._Designation = designation;
            this._Department = department;
        }

        public bool AddReportees(IEmployee employee)
        {
            _Reportees.Add(employee);
            return true;
        }

        public bool RemoveReportees(IEmployee employee)
        {
            return _Reportees.Remove(employee);
        }

        public void Display(int level)
        {
            string empDisp = new string('-', level) + this.Name + " (" + this.Designation + ") [Dept: " + this.Designation + "]";
            Console.WriteLine(empDisp);

            level += 3;
            foreach (IEmployee emp in _Reportees)
            {
                emp.Display(level);
            }
        }
    }

    public class Leaf : IEmployee
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Department;
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        private string _Designation;
        public string Designation
        {
            get { return _Designation; }
            set { _Designation = value; }
        }

        public Leaf(string name, string designation, string department)
        {
            this._Name = name;
            this._Designation = designation;
            this._Department = department;
        }

        public bool AddReportees(IEmployee employee)
        {
            throw new NotImplementedException("Invalid Leaf Operation: AddReportees().");
        }

        public bool RemoveReportees(IEmployee employee)
        {
            throw new NotImplementedException("Invalid Leaf Operation: RemoveReportees().");
        }

        public void Display(int level)
        {
            string empDisp = new string('-', level) + this.Name + " (" + this.Designation + ") [Dept: " + this.Department + "]";
            Console.WriteLine(empDisp);
        }
    }