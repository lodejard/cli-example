using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Output
{
    public class Etc : IEtc
    {
        void IEtc.Etc(string etc)
        {
            Console.WriteLine(etc);
        }
    }

    public interface IEtc
    {
        void Etc(string etc);
    }
}
