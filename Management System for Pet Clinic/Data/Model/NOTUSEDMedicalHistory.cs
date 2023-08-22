using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Model
{
    public abstract class NOTUSEDMedicalHistory
    {
        public int ID { get; set; }
        public Pet Pet { get; set; }
        public Staff StaffMember { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }

    }

    public class VaccinationHistory : NOTUSEDMedicalHistory
    {
        public string VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
    }

    public class SurgeryHistory : NOTUSEDMedicalHistory
    {
        public Staff SurgeonName { get; set; }
        public DateTime SurgeryDate { get; set; }
    }
}
