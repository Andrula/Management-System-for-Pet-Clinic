﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Model
{
    public class Appointment
    {
        // Fields
        private static int _nextAppointmentID = 1;
        private int _appointmentID;
        private DateTime _dateTime;

        // Properties
        public int ID
        {
            get { return _appointmentID; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("An error has occured!");
                }
                _appointmentID = value;
            }
        }
      
        public DateTime DateAndTime {
           get { return _dateTime; }
           set { if (value < DateTime.Now)
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

        // Constructor
        public Appointment()
        {
            ID = _nextAppointmentID++;
        }

        // Methods
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

    }
}
