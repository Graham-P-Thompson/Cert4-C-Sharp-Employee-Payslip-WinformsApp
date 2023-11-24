using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOProgramming.Domain
{
    /// <summary>
    /// Class to carry out calculations and create a payslip object.
    /// </summary>
    public class PayCalculator
    {
        private static List<TaxScale> _taxScaleWithThreshold;
        private static List<TaxScale> _taxScaleNoThreshold;

        /// <summary>
        /// Function to load both tax scales into memory when program starts.
        /// </summary>
        public static void LoadTaxScales()
        {
            _taxScaleWithThreshold = DataImport.GetTaxScaleWithThreshold();
            _taxScaleNoThreshold = DataImport.GetTaxScaleNoThreshold();
        }

        /// <summary>
        /// Method to calculate gross pay.
        /// </summary>
        /// <param name="hourlyRate">The hourly rate of an employee.</param>
        /// <param name="hoursWorked">The total hours an employee has worked.</param>
        /// <returns>Rounded value for the calculated gross pay.</returns>
        public static decimal CalculateGrossPay(decimal hourlyRate, decimal hoursWorked)
        {
            return Math.Round(hourlyRate * hoursWorked, 2);
        }

        /// <summary>
        /// Method to calculate the tax to deduct from an employees gross pay.
        /// </summary>
        /// <param name="grossPay">The total pay before any deductions.</param>
        /// <param name="taxFreeThreshold">Is the employee claiming the tax free threshold.</param>
        /// <returns>Rounded value for the calculated tax.</returns>
        /// <exception cref="Exception">If weekly wage is greater than the highest limit on the tax scale.</exception>
        public static decimal CalculateTax(decimal grossPay, bool taxFreeThreshold)
        {
            TaxScale row;

            if (taxFreeThreshold)
            {
                row = FindTaxScaleRow(grossPay, _taxScaleWithThreshold);
            }
            else
            {
                row = FindTaxScaleRow(grossPay, _taxScaleNoThreshold);
            }

            if (row == null)
            {
                throw new Exception("Weekly wage exceeded tax scale.");
            }

            decimal grossPayForCalculation = Math.Floor(grossPay) + 0.99m; // whole amount + 99c

            return Math.Round(row.CoEfficientA * grossPayForCalculation - row.CoEfficientB, 2);
        }

        /// <summary>
        /// Method to find the correct row of the tax scale to use based on the employees gross pay.
        /// </summary>
        /// <param name="grossPay">The total pay before any deductions.</param>
        /// <param name="taxScaleTable">A list containing TaxScale objects representing each row of the tax scale.</param>
        /// <returns>A TaxScale object containing the upper limit, and both coefficincies to use when calculating tax.</returns>
        private static TaxScale FindTaxScaleRow(decimal grossPay, List<TaxScale> taxScaleTable)
        {
            foreach (TaxScale row in taxScaleTable)
            {
                if (grossPay < row.UpperLimit)
                {
                    return row;
                }
            }
            return null;
        }

        /// <summary>
        /// Method for calculating the net pay for an employee.
        /// </summary>
        /// <param name="grossPay">The total pay before any deductions.</param>
        /// <param name="taxToDeduct">The tax to be deducted from an employees total gross pay.</param>
        /// <returns>Rounded value for the total net pay of an employee.</returns>
        public static decimal CalculateNetPay(decimal grossPay, decimal taxToDeduct)
        {
            return Math.Round(grossPay - taxToDeduct, 2);
        }

        /// <summary>
        /// Method to calculate the total superannuation due for an employee.
        /// </summary>
        /// <param name="grossPay">Total pay for an employee before any deductions.</param>
        /// <returns>Rounded value for the superannuation amount.</returns>
        public static decimal CalculateSuperAnnuation(decimal grossPay)
        {
            const decimal superRate = 10.5m;
            const decimal superRateAsPercent = superRate/100;

            return Math.Round(superRateAsPercent * grossPay, 2);

        }

        /// <summary>
        /// Calculates payment values and creates a payslip object. 
        /// </summary>
        /// <param name="emp">An employee object to create a payslip for.</param>
        /// <returns></returns>
        public static PaySlip CreatePaySlip(Employee emp)
        {
            decimal grossPay = CalculateGrossPay(emp.HourlyRate, emp.HoursWorked);
            decimal taxToDeduct = CalculateTax(grossPay, emp.TaxFreeThreshold);
            decimal netPay = CalculateNetPay(grossPay, taxToDeduct);
            decimal superAnnuation = CalculateSuperAnnuation(grossPay);

            string taxThreshold;
            if (emp.TaxFreeThreshold == true)
            {
                taxThreshold = "Y";
            }
            else
            {
                taxThreshold = "N";
            }

            PaySlip paySlip = new PaySlip(emp.Id, emp.FirstName, emp.LastName, emp.HoursWorked, emp.HourlyRate,
                                          taxThreshold, grossPay, taxToDeduct, netPay, superAnnuation);
            return paySlip;
        }
    }
       
}
