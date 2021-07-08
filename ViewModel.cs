using Syncfusion.Windows.Shared;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SfTreeGridDemo
{
    public class ViewModel : NotificationObject
    {
        private List<decimal> _comboBoxItemsSource = new List<decimal>();

        public ViewModel()
        {
            GetEmployees();
        }
        private ObservableCollection<EmployeeInfo> _employees;

        public ObservableCollection<EmployeeInfo> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                RaisePropertyChanged("Employees");
            }
        }

        public string[] Column = new string[] { "CheckBoxColumn", "ComboBoxColumn", "CurrencyColumn", "GridUpDownColumn", "TextColumn" };

        public List<decimal> ComboBoxItemsSource
        {
            get { return new List<decimal>() { 300000, 4000000, 850000, 11 , 20 , 12, 10, 90}; }
            set { _comboBoxItemsSource = value; }
        }

        private  void GetEmployees()
        {
            //await Task.Delay(5000);
            ObservableCollection<EmployeeInfo> employeeDetails = new ObservableCollection<EmployeeInfo>();
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ferando", LastName = Column[1], Title = "Management", Salary = 20, ReportsTo = -1, ID = 2 ,IsSelected=true});
            employeeDetails.Add(new EmployeeInfo() { FirstName = "John", LastName = Column[2], Title = "Accounts", Salary = 2000000, ReportsTo = -1, ID = 3, IsSelected = true });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Thomas", LastName = Column[3], Title = "Sales", Salary = 300000, ReportsTo = -1, ID = 4, IsSelected = false });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = Column[4], Title = "Marketing", Salary = 4000000, ReportsTo = -1, ID = 5, IsSelected = true });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ulysses", LastName = Column[0], Title = "HumanResource", Salary = 1500000, ReportsTo = -1, ID = 6, IsSelected = true });
            
            //Management
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = Column[1], ID = 9, Salary = 12, ReportsTo = 2, Title = "Vice President", IsSelected = true });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Janet", LastName = Column[1], ID = 10, Salary = 10, ReportsTo = 2, Title = "GM", IsSelected = true });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Steven", LastName = Column[1], ID = 11, Salary = 90, ReportsTo = 2, Title = "Manager", IsSelected = false });

            //Accounts
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Nancy", LastName = Column[2], ID = 12, Salary = 850000, ReportsTo = 3, Title = "Accounts Manager", IsSelected = true });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Margaret", LastName = Column[2], ID = 13, Salary = 700000, ReportsTo = 3, Title = "Accountant", IsSelected = true });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Michael", LastName = Column[2], ID = 14, Salary = 700000, ReportsTo = 3, Title = "Accountant", IsSelected = false });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Robert", LastName = Column[2], ID = 15, Salary = 650000, ReportsTo = 3, Title = "Accountant", IsSelected = true });

            //Sales
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Laura", LastName = Column[3], ID = 16, Salary = 900000, ReportsTo = 4, Title = "Sales Manager", IsSelected = false });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Anne", LastName = Column[3], ID = 17, Salary = 800000, ReportsTo = 4, Title = "Sales Representative", IsSelected = true });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Albert", LastName = Column[3], ID = 18, Salary = 750000, ReportsTo = 4, Title = "Sales Representative", IsSelected = false });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Tim", LastName = Column[3], ID = 19, Salary = 700000, ReportsTo = 4, Title = "Sales Representative", IsSelected = true });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Justin", LastName = Column[3], ID = 20, Salary = 700000, ReportsTo = 4, Title = "Sales Representative", IsSelected = false });

            //Back Office
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Caroline", LastName = Column[4], ID = 21, Salary = 800000, ReportsTo = 5, Title = "Receptionist", IsSelected = false });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Xavier", LastName = Column[4], ID = 22, Salary = 700000, ReportsTo = 5, Title = "Mail Clerk", IsSelected = true });

            //HR
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Laurent", LastName = Column[0], ID = 23, Salary = 900000, ReportsTo = 6, Title = "HR Manager", IsSelected = false });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Syed", LastName = Column[0], ID = 24, Salary = 650000, ReportsTo = 6, Title = "HR Assistant", IsSelected = true });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Amy", LastName = Column[0], ID = 25, Salary = 650000, ReportsTo = 6, Title = "HR Assistant", IsSelected = false });
                        
            Employees = employeeDetails;
        }
    }
}
