using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OOProgramming.Domain;

namespace OOProgramming.UI
{
    /// <summary>
    /// Class for the user interface.
    /// </summary>
    public partial class Form1 : Form
    {
        private BindingSource _employees;
        private PaySlip _paySlip;

        /// <summary>
        /// Constructor to initialize user interface on start up.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Get employee details on load and display.
            _employees = new BindingSource();
            _employees.DataSource = DataImport.GetEmployeeDetails();

            listBox1.DataSource = _employees;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            object selected = listBox1.SelectedItem;

            if (selected == null)
            {
                return;
            }

            if (!maskedTextBox1.MaskCompleted)
            {
                MessageBox.Show("Invalid hours worked input\nformat required 00.00", "Error!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Employee emp = selected as Employee;

            if (emp != null)
            {
                string hours = maskedTextBox1.Text;
                decimal.TryParse(hours, out decimal hoursWorked);

                emp.HoursWorked = hoursWorked;

                _paySlip = PayCalculator.CreatePaySlip(emp);

                textBox2.Text = _paySlip.ToString();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_paySlip != null)
            {
                DataExport.SavePaySlip(_paySlip);
                textBox2.Clear();
                MessageBox.Show("Pay slip has been saved.", "Completed",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Pay slip has not been generated.", "Error!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Set payslip back to null so no repeat saves can be carried out without re-calculating first.
            _paySlip = null;
        }
    }
}
