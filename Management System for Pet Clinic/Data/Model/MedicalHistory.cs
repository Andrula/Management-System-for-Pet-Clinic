using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Model
{
    public abstract class MedicalHistory
    {
        public int ID { get; set; }
        public Pet Pet { get; set; }
        public Staff StaffMember { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }

    }

    public class VaccinationHistory : MedicalHistory
    {
        public string VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
    }

    public class SurgeryHistory : MedicalHistory
    {
        public Staff SurgeonName { get; set; }
        public DateTime SurgeryDate { get; set; }
    }
}
