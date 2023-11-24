using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace OOProgramming
{
    /// <summary>
    /// Class to create a row of the tax schedules, lower limit not included.
    /// </summary>
    public class TaxScale
    {
        private decimal _upperLimit;
        private decimal _coEfficientA;
        private decimal _coEfficientB;

        /// <summary>
        /// Constructor for tax scale object.
        /// </summary>
        /// <param name="upperLimit">Upper tax bracket limit for gross pay.</param>
        /// <param name="columnA">Coefficient A of the tax scale.</param>
        /// <param name="columnB">Coefficient B of the tax scale.</param>
        public TaxScale(decimal upperLimit, decimal columnA, decimal columnB)
        {
            this._upperLimit = upperLimit;
            this._coEfficientA = columnA;
            this._coEfficientB = columnB;
        }

        /// <summary>
        /// Returns the value stored for the upper limit of a row in the tax scale.
        /// </summary>
        public decimal UpperLimit { get { return this._upperLimit; } }

        /// <summary>
        /// Returns the value stored for the coefficient A of a row in the tax scale. 
        /// </summary>
        public decimal CoEfficientA { get { return this._coEfficientA; } }

        /// <summary>
        /// Returns the value stored for the coefficent B of a row in the tax scale.
        /// </summary>
        public decimal CoEfficientB { get { return this._coEfficientB; } }
    }
}
