using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProgramming.Test
{
    public class IntegrationTest
    {
        [Test]
        public void ImportTaxScaleWithThreshold_ShouldReturnListOfRows()
        {
            List<TaxScale> taxScales = DataImport.GetTaxScaleWithThreshold();

            Assert.Multiple(() =>
            {
                Assert.That(taxScales[0].UpperLimit, Is.EqualTo(359m));
                Assert.That(taxScales[0].CoEfficientA, Is.EqualTo(0m));
                Assert.That(taxScales[0].CoEfficientB, Is.EqualTo(0m));
                Assert.That(taxScales[taxScales.Count-1].UpperLimit, Is.EqualTo(99999999m));
                Assert.That(taxScales[taxScales.Count-1].CoEfficientA, Is.EqualTo(0.4700m));
                Assert.That(taxScales[taxScales.Count-1].CoEfficientB, Is.EqualTo(563.5196m));
            });
        }
    }
}
