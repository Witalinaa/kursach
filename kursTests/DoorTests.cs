using Microsoft.VisualStudio.TestTools.UnitTesting;
using kurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs.Tests
{
    [TestClass()]
    public class DoorTests
    {
        [TestMethod()]
        public void LoginingTest()
        {
            string Password = "1234567899";
            string Email = "ekaterina@mail.ru";
            bool expected = true;
            //act
            bool actual = Door.Logining(Email, Password);

            Assert.AreEqual(expected, actual);
        }
    }
}