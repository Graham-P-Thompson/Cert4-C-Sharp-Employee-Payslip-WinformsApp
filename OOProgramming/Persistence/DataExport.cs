using CsvHelper;
using OOProgramming.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOProgramming
{
    /// <summary>
    /// Class containing methods to export data to a csv file.
    /// </summary>
    public class DataExport
    {
        /// <summary>
        /// Saves the state of a payslip object to a csv file
        /// </summary>
        /// <param name="paySlip">A payslip that has already been completed</param>
        public static void SavePaySlip(PaySlip paySlip)
        {
            DateTime dateTimeNoFormat = DateTime.Now;
            string dateTime = String.Format("{0:dd}.{0:MM}.{0:yyyy}-{0:HH}.{0:mm}.{0:ss}", dateTimeNoFormat);

            string path = GetFilePath($"Pay-{paySlip.EmpId}-{paySlip.FirstName}{paySlip.LastName}-{dateTime}.csv");

            using (StreamWriter sw = new StreamWriter(path))
            using (CsvWriter csv = new CsvWriter(sw, System.Globalization.CultureInfo.InvariantCulture))
            {
                csv.WriteField("EmployeeID");
                csv.WriteField("Full Name");
                csv.WriteField("Hours Worked");
                csv.WriteField("Hourly Rate");
                csv.WriteField("Tax Threshold");
                csv.WriteField("Gross Pay");
                csv.WriteField("Tax Deducted");
                csv.WriteField("Net Pay");
                csv.WriteField("Superannuation");
                csv.NextRecord();

                csv.WriteRecord(paySlip);
            }
        }

        private static string GetFilePath(string fileName)
        {
            string relativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory
                                  , "..", "..", "..", "payslips", fileName);

            return Path.GetFullPath(relativePath);
        }
    }
}
