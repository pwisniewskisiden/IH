using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Model;
using BusinessLogic;

namespace UnitTest
{
    [TestClass]
    public class ParserTEST
    {
        
        [TestMethod]
        public void TestMethodParser()
        {
            var tC = new StringDealerPartsMaster
            {
              ItemCode="code1", 
              WarehouseCode="warcode1"
            };
            var result = tC.ParseToLine(); 
            Assert.AreEqual("code1|warcode1||||||||||||||||||||||||||||||", result);
        }


    }
}
