using CsvHelper;
using OOProgramming.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOProgramming
{
    /// <summary>
    /// Class to import data from a csv file.
    /// </summary>
    public class DataImport
    {
        /// <summary>
        /// Import employee details from a csv file and create a list of employee objects.
        /// </summary>
        /// <returns>Employee objects created from details imported from a csv file.</returns>
        public static List<Employee> GetEmployeeDetails()
        {
            // Method to get employee details from CSV, create seperate employee objects and return a list.
            string path = GetFilePath("employee.csv");
            List<Employee> employees = new List<Employee>();

            using (StreamReader sr = new StreamReader(path))
            using (CsvReader csv = new CsvReader(sr, System.Globalization.CultureInfo.CurrentCulture))
            {
                while (csv.Read())
                {
                    int id = csv.GetField<int>(0);
                    string firstName = csv.GetField<string>(1);
                    string lastName = csv.GetField<string>(2);
                    decimal hourlyRate = csv.GetField<decimal>(3);
                    bool taxThreshold = false;

                    if (csv.GetField(4) == "Y")
                    {
                        taxThreshold = true;
                    }

                    employees.Add(new Employee(id, firstName, lastName, hourlyRate, taxThreshold));
                }
            }
            return employees;
        }

        /// <summary>
        /// Function to import tax scale with tax free threshold.
        /// </summary>
        /// <returns>A list of objects that represent each row of the tax scale. 
        ///          The list represents the full tax scale.</returns>
        public static List<TaxScale> GetTaxScaleWithThreshold()
        {
            string path = GetFilePath("taxrate-withthreshold.csv");

            List<TaxScale> taxScaleRows = new List<TaxScale>();

            using (StreamReader sr = new StreamReader(path))
            using (CsvReader csv = new CsvReader(sr, System.Globalization.CultureInfo.CurrentCulture))
            {
                while (csv.Read())
                {
                    decimal upperLimit = csv.GetField<decimal>(1);
                    decimal coEfficientA = csv.GetField<decimal>(2);
                    decimal coEfficientB = csv.GetField<decimal>(3);

                    taxScaleRows.Add(new TaxScale(upperLimit, coEfficientA, coEfficientB));
                }
            }
            // each tax scale object is a row of the tax schedule so the list of rows makes up the tax scale.
            return taxScaleRows;
        }

        /// <summary>
        /// Function to import tax scale without tax free threshold.
        /// </summary>
        /// <returns>A list of objects that represent each row of the tax scale. 
        ///          The list represents the full tax scale.</returns>
        public static List<TaxScale> GetTaxScaleNoThreshold()
        {
            string path = GetFilePath("taxrate-nothreshold.csv");

            List<TaxScale> taxScaleRows = new List<TaxScale>();

            using (StreamReader sr = new StreamReader(path))
            using (CsvReader csv = new CsvReader(sr, System.Globalization.CultureInfo.CurrentCulture))
            {
                while (csv.Read())
                {
                    decimal upperLimit = csv.GetField<decimal>(1);
                    decimal coEfficientA = csv.GetField<decimal>(2);
                    decimal coEfficientB = csv.GetField<decimal>(3);

                    taxScaleRows.Add(new TaxScale(upperLimit, coEfficientA, coEfficientB));
                }
            }
            // each tax scale object is a row of the tax schedule so the list of rows makes up the tax scale.
            return taxScaleRows;
        }

        private static string GetFilePath(string fileName)
        {
            string relativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory
                                  ,"..", "..", "..", "import", fileName);

            return Path.GetFullPath(relativePath);
        }
    }
}
