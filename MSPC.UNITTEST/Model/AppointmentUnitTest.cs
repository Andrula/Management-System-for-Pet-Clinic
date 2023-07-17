using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSPC.Model;
using System;

namespace MSPC.UNITTEST.Model
{
    [TestClass]
    public class AppointmentUnitTest
    {
        [TestMethod]
        public void Reschedule_Appointment_ReschedulesSuccessfully()
        {
            // Arrange

            // Instantiate necessary objects
            Staff staff = new Staff();
            {
                staff.Name = "Andreas Rasmussen";
                staff.Email = "Andreas@live.dk";
                staff.Address = "Brandholms Alle 25";
                staff.Phone = "24203780";
                staff.DateOfBirth = new DateTime(1998, 5, 1);
                staff.Position = Enum.StaffPosition.Surgeon;
            }

            Customer customer = new Customer();
            {
                customer.Name = "Andreas";
                customer.Address = "Jyllandsgade";
                customer.Email = "Email@live.dk";
                customer.Phone = "24207380";
            }

            Pet pet = new Pet("Max", "Dog", new DateTime(2005, 7, 18, 10, 30, 0), customer);

            // Initial Appointment
            Appointment appointment = new Appointment();
            DateTime initialDateTime = new DateTime(2023, 7, 18, 10, 30, 0);
            appointment.Schedule(initialDateTime, 60, pet, staff, "Routine check-up");

            // Act
            DateTime newDateTime = new DateTime(2023, 7, 19, 14, 0, 0);
            appointment.Reschedule(newDateTime);

            // Assert
            Assert.AreEqual(newDateTime, appointment.DateAndTime);
        }
    }
}
