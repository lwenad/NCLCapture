using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCLCapture
{
    public  class Itinerary
    {
     
        public string StateRoom { get; set; }
        public string Code { get; set; }
        public int CombinePrice { get; set; }
        public int Duration { get; set; }
        public int PricePerday { get { return CombinePrice / Duration; } }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturndateTime { get; set; }
        public string DestinationCodes { get; set; }
        
       


        public double EstimateJunkFee  {
            get
            {
                double feePercentage = 0;
                if (StateRoom == "OCEANVIEW")
                {
                    feePercentage = 0.2;
                }
                
                if (StateRoom == "BALCONY")
                {
                    feePercentage = 0.15;
                }
                return   CombinePrice * 2 * feePercentage; 
            }
        }
        public double Totalfor2 { get { return CombinePrice *2 * 1 + (EstimateJunkFee); } }
        
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            return stringBuilder.Append("Code:").Append(Code).AppendLine()
                .Append("DestinationCodes:").Append(DestinationCodes).AppendLine()
                            .Append("Duration:").Append(Duration).AppendLine()
                         .Append("DepartureDate:").Append(DepartureDate).AppendLine()
                         .Append("ReturndateTime:").Append(ReturndateTime).AppendLine()
                         .Append("CombinePrice:").Append(CombinePrice).AppendLine()
                         .Append("PricePerday:").Append(PricePerday).AppendLine()
                         .Append("EstimateJunkFee:").Append(EstimateJunkFee).AppendLine()
                         .Append("Totalfor2 bfore gov, tax, and port fee:").Append(Totalfor2).AppendLine()
                         .ToString();
                        


        }
    }

    
}
