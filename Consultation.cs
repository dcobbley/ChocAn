using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChocAn
{
    class Consultation
    {
        const int MAX_CONSULTATIONS = 1000;
        public string currentDate, currentTime, dateProvided, comments;
        int providerId, memberId, serviceCode;

        public Consultation()
        {
            currentDate = "";
        }
        
        public Consultation(string tempCurrentDate, string tempCurrentTime, string tempDateProvided, string tempComments, int tempProviderId, int tempMemberId, int tempServiceCode)
        {
            currentDate = tempCurrentDate;
            currentTime = tempCurrentTime;
            dateProvided = tempDateProvided;
            comments = tempComments;
            providerId = tempProviderId;
            memberId = tempMemberId;
            serviceCode = tempServiceCode;
        }
        
        public bool writeServiceToDisk()
        {
            if (currentDate == "")
                return false;
            try
            {
                int x;
                string path = Directory.GetCurrentDirectory();
                for(x=0; x<MAX_CONSULTATIONS; ++x)
                {
                    if(!Directory.Exists(path + @"\provider\consultation"+x ))
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(path + @"\provider"))
                        {
                            file.WriteLine(currentDate + " " + currentTime + "," + dateProvided  + "," + providerId  + "," + memberId  + "," + serviceCode  + "," + comments);
                        }
                        return true;
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new System.ArgumentException(ex.ToString(), "origional");
            }
        }
    }
}
