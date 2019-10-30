using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetNinjectSample.Models
{
    class SubSample
    {
        public Guid Id { get; }

        public SubSample()
        {
            Id = Guid.NewGuid();
        }

        public void Output()
        {
            Console.WriteLine($"This is sub guid = {Id.ToString()}");
        }
    }
}
