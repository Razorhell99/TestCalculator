using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalculator
{
    public class PriceMatch
    {
        public int Id { get; set; }
        public DateTime PriceMatchDate { get; set; }
        public Operator OpId { get; set; }
        public double PriceToMatch { get; set; }
        public double FreightFromCompetitorToCustomer { get; set; }
        
        public double FreightFromMidamToCustomer { get; set; }
        public double FreightToMidAm { get; set; }
        
        public double CompetitorLandingPriceToMatch { get; set; }
        public double MidamLandingPriceToMatch { get; set; }

        public PriceMatch()
        {
            PriceMatchDate = DateTime.Now;
            

        }


        

        //Sert à calculer la marge restante. La value priceToMatch doit être le resultat de la méthode CalculateLandingPriceToMatch et la value 
        //cost doit être le résultat de la méthode CalculateLandingCost
        public double MarginIfPriceIsMatch(double priceToMatch ,double cost)
        {
            var margin = ((priceToMatch - cost) / priceToMatch) * 100;
            return margin;


        }
        
        //Sert à calculer le prix total à matcher. Prends en compte le priceToMatch et le transport du competiteur au client


        public double CalculateCustomerCostWithFreight(double priceToMatch, double freightToCustomer)
        {
            priceToMatch = PriceToMatch;
            freightToCustomer = FreightFromCompetitorToCustomer;
            CompetitorLandingPriceToMatch = priceToMatch + freightToCustomer;
            return CompetitorLandingPriceToMatch;
        }

        public double CalculateMidamPriceToMatchWithFreightToCustomer(double competitorPriceToMatch, double freightFromMidam)
        {

            FreightFromMidamToCustomer = freightFromMidam;
            MidamLandingPriceToMatch = competitorPriceToMatch - FreightFromMidamToCustomer;


            return MidamLandingPriceToMatch;
        }

        


        //Sert à calculer le flyer à recommander 
        public string FlyerMatch(double priceToMatch, double flyer30, double flyer43, double flyer55)
        {
            string result = "";

            if (priceToMatch > flyer30)
            {
                result = "We recommend using flyer MIDAM-3-0";
            }
            else if(priceToMatch < flyer30 && priceToMatch > flyer43)
            {
                result = "We recommend using flyer MIDAM-4-3";
            }

            else if (priceToMatch < flyer43 && priceToMatch > flyer55)
            {
                result = "We recommend using flyer MIDAM-5-5";
            }
            else if(priceToMatch < flyer55)
            {
                result =  "We can't match that";
            }
            return result;
        }
        
            
        




    }
}
