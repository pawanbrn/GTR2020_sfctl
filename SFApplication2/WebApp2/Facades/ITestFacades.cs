using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2.Facades
{
    public interface ITestFacades
    {
        void RunTestsAsync(DTO runParameters);
    }
}
