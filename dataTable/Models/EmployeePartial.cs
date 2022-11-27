namespace dataTable.Models
{
    public partial class EmployeePartial
    {
        
        public int EmployeeId
        {
            get;
            set;
        }
       
        public string EmployeeFirstName
        {
            get;
            set;
        }
     
        public string EmployeeLastName
        {
            get;
            set;
        }
       
        public decimal Salary
        {
            get;
            set;
        }
      
        public string Designation
        {
            get;
            set;
        }



    }



    public partial class EmployeePartial
    {
        public int TotalCount { get; set; }
        public int FilteredCount { get; set; }
    }
}


