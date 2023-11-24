using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProgramming.Domain
{
    /// <summary>
    /// Class to create an employee object.
    /// </summary>
    public class Employee
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private decimal _hourlyRate;
        private bool _taxFreeThreshold;
        private decimal _hoursWorked;

        /// <summary>
        /// Constructor to create an employee object.
        /// </summary>
        /// <param name="id">Employee ID.</param>
        /// <param name="firstName">First name of employee.</param>
        /// <param name="lastName">Last name of employee.</param>
        /// <param name="hourlyRate">Hourly rate of the employee.</param>
        /// <param name="taxFreeThreshold">The tax threshold being claimed by the employee.</param>
        public Employee(int id, string firstName, string lastName, decimal hourlyRate, bool taxFreeThreshold)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _hourlyRate = hourlyRate;
            _taxFreeThreshold = taxFreeThreshold;
        }

        /// <summary>
        /// Returns the value stored for the employee ID.
        /// </summary>
        public int Id { get { return _id; } }

        /// <summary>
        /// Returns the value stored for the employee first name.
        /// </summary>
        public string FirstName { get { return _firstName; } }

        /// <summary>
        /// Returns the value stored for the employee last name.
        /// </summary>
        public string LastName { get { return _lastName; } }

        /// <summary>
        /// Returns the value stored for the employee hourly rate.
        /// </summary>
        public decimal HourlyRate { get { return _hourlyRate; } }

        /// <summary>
        /// Returns the value stored for the tax threshold being claimed by the employee. 
        /// </summary>
        public bool TaxFreeThreshold { get { return _taxFreeThreshold; } }

        /// <summary>
        /// Returns the value stored for the hours worked by the employee.
        /// </summary>
        public decimal HoursWorked { get { return _hoursWorked; } set { _hoursWorked = value; } }

        /// <summary>
        /// Overrides the to string method to access the state of the employee object.
        /// </summary>
        /// <returns>A formatted string including the employee ID, first name and last name.</returns>
        public override string ToString()
        {
            return $"{Id}: {FirstName}, {LastName}";
        }
    }
}
