using System;

namespace Lift.Core.Domain
{
    public class PassengerNode
    {
        public Node Node { get; protected set; }
        public Passenger Passenger { get; protected set; }

        protected PassengerNode(Passenger passenger, Node node)
        {
        }

        public static PassengerNode Create(Passenger passenger, Node node)
            => new PassengerNode(passenger, node);
        
    }
}