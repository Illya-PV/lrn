using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Learning.Bll.Interfaces
{
    public interface ITestService
    {
        TestModel InsertTest(TestModel testid);
        TestModel ReadTestInt(int SomeIdInt);
        TestModel ReadTestStr(string SomeIdStr);
        TestModel ReadTestGuid(Guid SomeIDGuid);


    }
}
