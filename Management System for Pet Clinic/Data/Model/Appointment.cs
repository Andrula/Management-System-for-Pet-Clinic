using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Model
{
    public class Appointment
    {
        private static List<Appointment> appointmentList = new List<Appointment>();

        #region Fields
        private static int _appointmentID = 1;
        private DateTime _dateTime;

        #endregion

        #region Properties
        public int ID { get ; }

        public DateTime DateAndTime {
           get { return _dateTime; }
           set { 
                if (value < DateTime.Now)
                {
                    throw new Exception("Date is incorrect!");
                }
                _dateTime = value;
            } 
        }

        public int DurationInMinutes { get; set; }

        public Pet Patient { get; set; }

        public Staff ResponsibleStaff { get; set; }

        public string Purpose { get; set; }

        public string Status { get; set; }

        public string Note { get; set; }
        #endregion

        #region Constructor(s)
        // Constructor
        public Appointment()
        {
            ID = _appointmentID;
            _appointmentID++;
        }
        #endregion


        #region Methods
        public void Schedule(DateTime dateAndTime, int durationInMinutes, Pet patient, Staff responsibleStaff, string purpose)
        {
            DateAndTime = dateAndTime;
            DurationInMinutes = durationInMinutes;
            Patient = patient;
            ResponsibleStaff = responsibleStaff;
            Purpose = purpose;
            Status = "Scheduled";
        }

        public void Reschedule(DateTime newDateAndTime)
        {
            DateAndTime = newDateAndTime;
        }

        public void Cancel()
        {
            Status = "Canceled";
        }

        public void Complete()
        {
            Status = "Completed";
        }

        public static void AddAppointment(Appointment appointment)
        {
            appointmentList.Add(appointment);
        }

        public static List<Appointment> GetAllApointments()
        {
            return appointmentList;
        }

        public void PrintAppointmentDetails()
        {
            Console.WriteLine($"Appointment ID: {ID}");
            Console.WriteLine($"Date and Time: {DateAndTime}");
            Console.WriteLine($"Duration: {DurationInMinutes} minutes");
            Console.WriteLine($"Patient: {Patient.Name}");
            Console.WriteLine($"Responsible Staff: {ResponsibleStaff.Name}");
            Console.WriteLine($"Purpose: {Purpose}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Additional Information: {Note}");
        }
        #endregion
    }
}
