using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalculator
{
    public class Operator
    {
        public int Id { get; set; }
        public string OpName { get; set; }
        public double OpListPriceUsd30 { get; set; }
        public double OpListPriceUsd43 { get; set; }
        public double OpListPriceUsd55 { get; set; }
        public double Cost { get; set; }
        public double LandingCost { get; set; }
        public double FreightToMidam { get; set; } 

        public Operator(int id, string opName, double opListPrice, double freightToMidam)
        {
            Id = id;
            OpName = opName;
            OpListPriceUsd30 = opListPrice;
            OpListPriceUsd43 = OpListPriceUsd30 * .97;
            OpListPriceUsd55 = OpListPriceUsd30 * .95;
            Cost = OpListPriceUsd30 * .9;
            
            
            
            LandingCost = CalculateLandingCost(Cost, freightToMidam);

            
        }

        //Sert à calculer le cost final après les frais de transport de Liftmaster à MidAmerica
        public double CalculateLandingCost(double cost, double freightToMidam)
        {
            LandingCost = cost + freightToMidam;
            return LandingCost;

        }




    }
}
