using shippingZone;
using System;

FeesDelegate theDel;
Double thePrice;
string theZone;
Destination theDest;

do
{
    Console.WriteLine("What is the destination zone?");
    theZone = Console.ReadLine();

    if (theZone != "exit" & theZone != null)
    {
        // Find destination of shipping
        theDest = Destination.GetDestination(theZone);
    
        if (theDest != null)
        {
            Console.WriteLine("What is the price of shipping?");
            string thePriceStr = Console.ReadLine();
            if (thePriceStr != null)
            {
                // price of shipping
                thePrice = Double.Parse(thePriceStr);


                // the delegates that calculates fees change when destination changes
                theDel = theDest.calculateFees;
                if (theDest.isHighRisk)
                {
                    theDel += delegate (double thePrice, ref double theFee)
                    {
                        theFee += 25;
                    };
                }

                // we can now use the delegate to calculate fees
                double theFee = 0;
                theDel(thePrice, ref theFee);
                Console.WriteLine($"The destination fees are : {theFee} $");
            }
        
        }
        else
        {
            Console.WriteLine("Wrong destination. Try again or type 'exit'");
        }
        

    }
        
}
while (theZone != "exit");



