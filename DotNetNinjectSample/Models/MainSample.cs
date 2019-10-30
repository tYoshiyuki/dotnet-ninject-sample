using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetNinjectSample.Models
{
    class MainSample
    {
        public Guid Id { get; }
        public SubSample SubSample { get; }


        public MainSample()
        {
            Id = Guid.NewGuid();
        }

        public MainSample(SubSample subSample) : this()
        {
            SubSample = subSample;
        }

        public void Output()
        {
            Console.WriteLine($"This is main guid = {Id.ToString()}");
            SubSample?.Output();
        }
    }
}
