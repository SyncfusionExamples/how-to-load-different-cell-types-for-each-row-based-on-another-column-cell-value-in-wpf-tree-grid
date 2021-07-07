using Syncfusion.Windows.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SfTreeGridDemo
{
    public class EmployeeInfo : NotificationObject,IDataErrorInfo, INotifyDataErrorInfo
    {
        int _id;
        string _firstName;
        string _lastName;
        private string _title;
        decimal _salary;
        int _reportsTo;
        bool isSelected;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set 
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        [Range(1, 2, ErrorMessage = "ID between 1 and 2 alone processed")]
        public int ID
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("ID"); }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; RaisePropertyChanged("Salary"); }
        }

        public int ReportsTo
        {
            get { return _reportsTo; }
            set { _reportsTo = value; }
        }

        [Display(AutoGenerateField = false)]

        public string Error => string.Empty;
       
        public string this[string columnName]
        {
            get
            {
                if (!columnName.Equals("Salary"))
                    return string.Empty;
                if (this.Salary < 10000 || this.Salary > 30000)
                    return "The 'Salary' field can range from 10000 to 30000 " ;

                return string.Empty;
            }
        }

        [Display(AutoGenerateField = false)]

        public bool HasErrors
        {
            get
            {
                return false;
            }
        }

        private List<string> errors = new List<string>();
        public IEnumerable GetErrors(string propertyName)
        {
            if (!propertyName.Equals("Title"))
                return null;

            if (this.Title.Contains("Management"))
                errors.Add("Management is not valid ");

            return errors;
        }
    }
}
