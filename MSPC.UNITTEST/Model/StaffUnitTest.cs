using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSPC.Model;
using System;

namespace MSPC.UNITTEST.Model
{
    [TestClass]
    public class StaffUnitTest

    {
        [TestMethod]
        public void InvalidBirthDate()
        {
            // Arrange
            // Instantiate necessary objects
            Staff staff = new Staff();

            // Act and Assert
            Assert.ThrowsException<Exception>(() => staff.DateOfBirth = new DateTime(1800, 1, 1));
        }
    }
}
