/*Fabian Narvaez
 * C# Project 
 * two dimensional Array pratice 
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AverageUnitsShippedByEmployeeCSharp
{
    public partial class frmAverageUnitsShippedByEmployee : Form
    {
        //Variables
        int employee = 0;
        int day = 0;
        const int numberOfDays = 7;
        const int numberOfEmployee = 3;
        double TotalEmploymentShipment;
        double AverageByEmployee;
        double totalOverAllEmployeeShipment;
        double averageForAllEmployees;
       
        TextBox[] textBoxesUnitsEnteredByEmployees;
        Label[] labelTotalAverageDisplayEmployees;
        double[,] valuesEntered = new double [numberOfEmployee  , numberOfDays ];
        public frmAverageUnitsShippedByEmployee()
        {
            InitializeComponent();
        }

        private void frmAverageUnitsShippedByEmployee_Load(object sender, EventArgs e)
        {
            textBoxesUnitsEnteredByEmployees = new TextBox[] { txtBigDisplayEmployee1, txtBigDisplayEmployee2, txtBigDisplayEmployee3 };
            labelTotalAverageDisplayEmployees = new Label[] { lblAverageEmployee1, lblAverageEmployee2, lblAverageEmployee3 };

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtboxUserInput.Text, out valuesEntered[employee, day]))
            {
                if (valuesEntered[employee, day] >= 0 && valuesEntered[employee, day] <= 100)
                {
                    textBoxesUnitsEnteredByEmployees[employee].Text += valuesEntered[employee, day].ToString() + System.Environment.NewLine;
                    day += 1;
                    txtboxUserInput.Clear();
                    if (day == numberOfDays )
                    {
                        TotalEmploymentShipment = 0;
                        for (int index = 0; index < numberOfDays ; index++)
                        {
                            TotalEmploymentShipment += valuesEntered[employee, index];
                        }

                        AverageByEmployee = Math.Round(TotalEmploymentShipment / numberOfDays,2);
                        labelTotalAverageDisplayEmployees[employee].Text = AverageByEmployee.ToString();
                        day = 0;
                        employee ++;
                       
                       
                    }
                    lblDayCounter .Text= "Day " + (day + 1).ToString();
                    if (employee == numberOfEmployee)
                    {
                        totalOverAllEmployeeShipment = 0;
                        foreach (double values in valuesEntered)
                        {
                            totalOverAllEmployeeShipment += values;
                        }

                        averageForAllEmployees = Math.Round(totalOverAllEmployeeShipment / valuesEntered.Length,2);
                        lblOverallAverage.Text = "Total Average: " + averageForAllEmployees.ToString();
                        BtnReset.Focus();
                        txtboxUserInput.ReadOnly = true;
                        btnEnter.Enabled = false;
                       

                    }
                }
                else
                {
                    MessageBox.Show("The Value Entered Must be between 1 and 100");
                    txtboxUserInput.Clear();
                    txtboxUserInput.Focus();
                }

            }
            else
                MessageBox.Show("The Value Entered Must be Numeric");
            txtboxUserInput.Clear();
            txtboxUserInput.Focus();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            clearTextBoxes(textBoxesUnitsEnteredByEmployees);
            clearLabels(labelTotalAverageDisplayEmployees);
            lblDayCounter.Text = "Day";
            txtboxUserInput.ReadOnly = false;
            btnEnter.Enabled = true;
            txtboxUserInput.Focus();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        public void clearTextBoxes(TextBox[] txtBoxArray)
        {
            foreach (TextBox textBox in txtBoxArray)
            {
                textBox.Text = string.Empty;
            }
        }
        public void clearLabels(Label[] labelArray)
        {
            foreach (Label label in labelArray)
            {
               label.Text = string.Empty;
            }
        }
    }
}
