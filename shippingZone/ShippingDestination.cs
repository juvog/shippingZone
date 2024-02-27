using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shippingZone
{
    public delegate void FeesDelegate(double thePrice, ref double fee);
    abstract class Destination
    {
        public bool isHighRisk;

        public virtual void calculateFees(double price, ref double fee) { }

        public static Destination GetDestination(string destination)
        {
            if (destination == "zone1")
            {
                return new Destination1();
            }
            if (destination == "zone2")
            {
                return new Destination2();
            }
            if (destination == "zone3")
            {
                return new Destination3();
            }
            if (destination == "zone4")
            {
                return new Destination4();
            }
            return null;
        }

    }

    internal class Destination4 : Destination
    {
        public Destination4()
        {
            this.isHighRisk = false;
        }

        public override void calculateFees(double price, ref double fee)
        {
            fee = price * 0.04;
        }
    }

    internal class Destination3 : Destination
    {
        public Destination3()
        {
            this.isHighRisk = false;
        }

        public override void calculateFees(double price, ref double fee)
        {
            fee = price * 0.08;
        }
    }

    internal class Destination2 : Destination
    {
        public Destination2()
        {
            this.isHighRisk = true;
        }

        public override void calculateFees(double price, ref double fee)
        {
            fee = price * 0.12;
        }
    }

    internal class Destination1 : Destination
    {
        public Destination1()
        {
            this.isHighRisk = false;
        }

        public override void calculateFees(double price, ref double fee)
        {
            fee = price * 0.25;
        }

    }
}
