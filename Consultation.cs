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
        public string currentDate, currentTime, dateProvided, comments;
        int providerId, memberId, serviceCode;

        public Consultation()
        { }
        
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
            try
            {
                string path = Directory.GetCurrentDirectory();
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path + @"\provider"))
                {
                    file.WriteLine(currentDate + " " + currentTime + "," + dateProvided  + "," + providerId  + "," + memberId  + "," + serviceCode  + "," + comments);
                }
                return true;
            }
            catch(Exception ex)
            {
                throw new System.ArgumentException(ex.ToString(), "origional");
            }
        }
    }
}
