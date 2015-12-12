namespace Lokf.Library.Lending
{
    using Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public sealed class Lending : AggregateRoot
    {
        public Lending(Guid lendingId) 
            : base(lendingId)
        {

        }
    }
}
