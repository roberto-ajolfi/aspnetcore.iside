using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Demo
{
    //public interface ITestService
    //{
    //    List<string> GetData();
    //}

    public class TestService    // : ITestService
    {
        public List<string> GetData()
        {
            return new List<string>
            {
                "value1",
                "value2"
            };
        }
    }
}
