using OOProgramming.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProgramming.Test
{
    public class PayCalculatorTest
    {
        [Test]
        public void GetCalculatedGrossPay_ShouldReturnValue()
        {
            decimal hourlyWage = 25;
            decimal hoursWorked = 30;
            
            decimal grossPay = PayCalculator.CalculateGrossPay(hourlyWage, hoursWorked);
            
            Assert.That(grossPay, Is.EqualTo(750m));
        }
        
        [Test]
        public void GetCalculatedTaxWithThreshold_ShouldReturnValue()
        {
            PayCalculator.LoadTaxScales();
            decimal grossPay = 750m;
            bool taxThreshold = true;

            decimal tax = PayCalculator.CalculateTax(grossPay, taxThreshold);

            Assert.That(tax, Is.EqualTo(89.63m));
        }

        [Test]
        public void GetCalculatedTaxNoThreshold_ShouldReturnValue()
        {
            PayCalculator.LoadTaxScales();
            decimal grossPay = 750m;
            bool taxThreshold = false;

            decimal tax = PayCalculator.CalculateTax(grossPay, taxThreshold);

            Assert.That(tax, Is.EqualTo(196.69m));
        }

        [Test]
        public void GetCalculatedNetPay_ShouldReturnValue()
        {
            decimal grossPay = 750m;
            decimal taxToDeduct = 89.63m;

            decimal net = PayCalculator.CalculateNetPay(grossPay, taxToDeduct);

            Assert.That(net, Is.EqualTo(660.37m));
        }

        [Test]
        public void GetCalculatedSupperannuationAmount_ShouldReturnValue()
        {
            decimal grossPay = 750m;

            decimal superAmount = PayCalculator.CalculateSuperAnnuation(grossPay);

            Assert.That(superAmount, Is.EqualTo(78.75m));
        }
    }
}
