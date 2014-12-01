using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChocAn
{
    class Accouting
    {
        public Consultation consultation;
        public List<Consultation> listOfConsultations;
        public List<Info> members;
        public List<Info> providers;
        public List<Info> serviceDirectory;

        public Accouting()
        {
            consultation = new Consultation();
            listOfConsultations = consultation.readAllConsultations();
            members=Members.readMembers();
            providers = Providers.readProvider();
            serviceDirectory = ProviderServiceDirectory.readInServices();
        }

        public void memberReports()
        {
            string path = Directory.GetCurrentDirectory();
            string tempProviderName="";
            string tempServiceCode="";

            foreach(Info mem in members)
            {
                //start a new file and add the consultation to the list
                using (StreamWriter file = File.AppendText(path + @"\accounting\"+mem.name+@".txt"))
                {
                    file.WriteLine(mem.name + "," + mem.ID + "," + mem.address + "," + mem.city + "," + mem.state + "," + mem.zip);
                }

                //check each member in entire list against all consultations
                foreach(Consultation cons in listOfConsultations)
                {
                    if(mem.ID==cons.memberId)
                    {
                        //grab name of the provider
                        foreach(Info prov in providers)
                        {
                            if (cons.providerId == prov.ID)
                                tempProviderName = prov.name;
                        }
                        
                        //grab service name
                        foreach(Info code in serviceDirectory)
                        {
                            if(code.ID == cons.serviceCode)
                            {
                                //Found a match
                                tempServiceCode = code.serviceName;
                            }
                        }

                        using (StreamWriter file = File.AppendText(path + @"\accounting\" + mem.name + @".txt"))
                        {
                            file.WriteLine(cons.dateProvided +" " +tempProviderName+ " " + tempServiceCode);

                        }
                        
                    }
                }
            }
        }
        public void providerReports()
        {

            string path = Directory.GetCurrentDirectory();
            string tempMemberName;
            int amountDue;
            int numOfConsultations;
            int tempAmountDue;

            foreach (Info prov in providers)
            {
                tempAmountDue = 0;
                numOfConsultations = 0;
                amountDue = 0;
                tempMemberName = "";
                //start a new file and add the consultation to the list
                using (StreamWriter file = File.AppendText(path + @"\accounting\" + prov.name + @".txt"))
                {
                    file.WriteLine(prov.name + "," + prov.ID + "," + prov.address + "," + prov.city + "," + prov.state + "," + prov.zip);
                }

                //check each member in entire list against all consultations
                foreach (Consultation cons in listOfConsultations)
                {
                    if (prov.ID == cons.providerId)
                    {
                        ++numOfConsultations;
                        //grab name of the member
                        foreach (Info mem in members)
                        {
                            if (cons.memberId == mem.ID)
                                tempMemberName = mem.name;
                        }

                        //grab service name
                        foreach (Info code in serviceDirectory)
                        {
                            if (code.ID == cons.serviceCode)
                            {
                                //Found a match
                                amountDue += code.dollarAmount;
                                tempAmountDue = code.dollarAmount;
                            }
                        }

                        using (StreamWriter file = File.AppendText(path + @"\accounting\" + prov.name + @".txt"))
                        {
                            file.WriteLine(cons.dateProvided + " " + cons.currentDate + " " + cons.currentTime + " " + tempMemberName + " " + cons.memberId + " " + cons.serviceCode + " " + +"$" + tempAmountDue+ "Due");

                        }

                    }
                }
                using (StreamWriter file = File.AppendText(path + @"\accounting\" + prov.name + @".txt"))
                {
                    file.WriteLine("Number of consultations: " + numOfConsultations);
                    file.WriteLine("Total Due for the week: "+amountDue );
                }
                accountsPayable(amountDue, prov.name);

                //update totals 
            }
        }
        public void accountsPayable(int amount,string providerName)
        {
            string path = Directory.GetCurrentDirectory();
            using (StreamWriter file = File.AppendText(path + @"\accounting\EFT" + providerName + @".txt"))
            {
                file.WriteLine("Total to be payed to Provider for the week: " + amount);
            }
        }
        public void managerReport()
        {
            //list out
            //Provider name who serviced 
            //consultations each had.
            //individual total amount to be payed
            
            //Total num of providers who serviced
            //total consultations
            //overall fee from everyone.
            managerReportFinish();
        }
        public void managerReportFinish()
        {

        }
    }
}
