using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProgramming
{
    /// <summary>
    /// Class to create a payslip object.
    /// </summary>
    public class PaySlip
    {
        private int _empId;
        private string _firstName;
        private string _lastName;
        private decimal _hoursWorked;
        private decimal _hourlyRate;
        private string _taxThreshold;
        private decimal _grossPay;
        private decimal _taxAmount;
        private decimal _netPay;
        private decimal _superAnnuation;

        /// <summary>
        /// Constructor for payslip object.
        /// </summary>
        /// <param name="id">Employee ID.</param>
        /// <param name="firstName">Employee first name.</param>
        /// <param name="lastName">Employee last name.</param>
        /// <param name="hoursWorked">Hours worked by the employee.</param>
        /// <param name="hourlyRate">Hourly rate of the employee.</param>
        /// <param name="threshold">Tax threshold being claimed by the employee.</param>
        /// <param name="grossPay">Gross pay of the employee before tax.</param>
        /// <param name="tax">Tax to be deducted from the emplyees gross pay.</param>
        /// <param name="netPay">Net pay of the employee after deductions.</param>
        /// <param name="super">Superannuation amount payable to the employee.</param>
        public PaySlip(int id, string firstName, string lastName, decimal hoursWorked, decimal hourlyRate,
                       string threshold, decimal grossPay, decimal tax, decimal netPay, decimal super)
        {
            this._empId = id;
            this._firstName = firstName;
            this._lastName = lastName;
            this._hoursWorked = hoursWorked;
            this._hourlyRate = hourlyRate;
            this._taxThreshold = threshold;
            this._grossPay = grossPay;
            this._taxAmount = tax;
            this._netPay = netPay;
            this._superAnnuation = super;
        }

        /// <summary>
        /// Returns the value stored for the employee ID.
        /// </summary>
        public int EmpId { get { return _empId; } }

        /// <summary>
        /// Returns the value stored for the employees frist name.
        /// </summary>
        public string FirstName { get { return _firstName; } }

        /// <summary>
        /// Returns the value stored for the employees last name.
        /// </summary>
        public string LastName { get { return _lastName; } }

        /// <summary>
        /// Returns the value stored for the hours worked by the employee.
        /// </summary>
        public decimal HoursWorked { get { return _hoursWorked; } }

        /// <summary>
        /// Returns the value stored for the hourly rate of the employee.
        /// </summary>
        public decimal HourlyRate { get { return _hourlyRate; } }

        /// <summary>
        /// Returns the value stored for the tax threshold being claimed by the employee.
        /// </summary>
        public string TaxThreshold { get { return _taxThreshold; } }

        /// <summary>
        /// Returns the value stored for the employees gross pay.
        /// </summary>
        public decimal GrossPay { get { return _grossPay; } }

        /// <summary>
        /// Returns the value stored for the tax to be deducted from the employees gross pay.
        /// </summary>
        public decimal TaxAmount { get { return _taxAmount; } }

        /// <summary>
        /// Returns the value stored for the net pay of the employee.
        /// </summary>
        public decimal NetPay { get { return _netPay; } }

        /// <summary>
        /// Returns the value stored for the superannuation to be payable to the employee.
        /// </summary>
        public decimal SuperAnnuation { get { return _superAnnuation; } }

        /// <summary>
        /// Overrides the to string method to display the values stored in the state of a pay slip object.
        /// </summary>
        /// <returns>Formatted strings of the payslips objects state.</returns>
        public override string ToString()
        {
            // :C is short hand for .ToString("C")
            return $"EmpID: {EmpId}\tName: {FirstName} {LastName}" +
                Environment.NewLine +
                Environment.NewLine + $"Hours worked: \t{HoursWorked}" +
                Environment.NewLine + $"Hourly rate: \t{HourlyRate:C}" +
                Environment.NewLine + $"Tax threshold:\t {TaxThreshold}" +
                Environment.NewLine + $"Gross Pay: \t{GrossPay:C}" +
                Environment.NewLine + $"Tax deduction: \t{TaxAmount:C}" +
                Environment.NewLine + $"Net Pay: \t\t{NetPay:C}" +
                Environment.NewLine + $"Superannuation: \t{SuperAnnuation:C}";
        }
    }
}
