using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApp2.Facades
{
    public class TestFacade 
    {
       

        public void RunTestsAsync(DTO dto)
        {
            //Assembly assembly = TestLibrary
        }

        private List<Type> GetAllTypes(string Namespace)
        {
            var listType = new List<Type>();
            var list = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(t => t.GetTypes())
                       .Where(t => t.IsClass && t.Namespace == Namespace);
            listType.AddRange(list);
            var uniqueTests = listType.Distinct().ToList();

            return uniqueTests;
        }
    }
}
