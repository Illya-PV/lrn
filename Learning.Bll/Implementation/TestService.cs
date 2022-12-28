using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Dal;
using Learning.Dal.Models;
using Learning.Dal.Context;
using Learning.Bll.Interfaces;

namespace Learning.Bll.Implementation
{
    public class TestService : ITestService
    {
        TestContext testContext;

        
        public TestModel InsertTest(TestModel testid)
        {
            testContext.InsertTestToMongoDb(testid);
            return testid;
        }

        /*public TestModel ReadTestGuid(Guid SomeIDGuid)
        {

            testContext.ReadTestGuidFromMongoDb(SomeIDGuid);
            return SomeIDGuid;
        }*/
        public int ReadTestInt(int SomeIdInt) 
        {
            testContext.ReadTestIntFromMongoDb(SomeIdInt);
            return SomeIdInt;
        }
        public string ReadTestStr(string SomeIdStr) 
        {
            return testContext.ReadTestStringFromMongoDb(SomeIdStr);
        }

        TestModel ITestService.ReadTestGuid(Guid SomeIDGuid)
        {
            throw new NotImplementedException();
        }

        TestModel ITestService.ReadTestInt(int SomeIdInt)
        {
            throw new NotImplementedException();
        }

        TestModel ITestService.ReadTestStr(string SomeIdStr)
        {
            throw new NotImplementedException();
        }
    }
}
