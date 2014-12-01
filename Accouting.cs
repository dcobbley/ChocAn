using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocAn
{
    class Accouting
    {
        public Consultation consultation;
        public List<Consultation> listOfConsultations;
        public List<Info> members;
        public List<Info> providers;
 
        public Accouting()
        {
            consultation = new Consultation();
            listOfConsultations = consultation.readAllConsultations();
            members=Members.readMembers();
            providers = Providers.readProvider();
        }

        public void memberReports()
        {
            foreach(Info mem in members)
            {
                //check each member in entire list against all consultations

            }
        }
        public void providerReports()
        {

        }
        public void accountsPayable()
        {

        }

    }
}
