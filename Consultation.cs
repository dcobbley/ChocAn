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
        public int providerId, memberId, serviceCode;

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
                string path = Directory.GetCurrentDirectory();
               
                int count = 0;
                DirectoryInfo dir = new DirectoryInfo(path + @"\consultation");
                FileSystemInfo[] infos = dir.GetFileSystemInfos();
                foreach (FileSystemInfo fsi in infos)
                {
                    ++count;
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path + @"\consultation\consultation" + count + @".txt"))
                {
                    file.WriteLine(currentDate + " " + currentTime + "," + dateProvided + "," + providerId + "," + memberId + "," + serviceCode + "," + comments);
                }
                return true;

            }
            catch(Exception ex)
            {
                throw new System.ArgumentException(ex.ToString(), "origional");
            }
        }
        public List<Consultation> readAllConsultations()
        {
            List<Consultation> tempList = null;
            string path = Directory.GetCurrentDirectory();
            int x=0;
            int count = 0;
            DirectoryInfo dir = new DirectoryInfo(path + @"\consultation");
            FileSystemInfo[] infos = dir.GetFileSystemInfos();
            foreach (FileSystemInfo fsi in infos)
            {
                ++count;
            }


            if (count == 0)
                return tempList;
            else
            {
                tempList = new List<Consultation>();
                while (x < count)
                {
                    Consultation tempConsultation=null;

                    string rawData;
                    string[] tempSplit;
                    System.IO.StreamReader file = new System.IO.StreamReader(path + @"\consultation\consultation" + x + @".txt");
                    while ((rawData = file.ReadLine()) != null)
                    {
                        tempSplit = rawData.Split(',');
                        tempConsultation = new Consultation(tempSplit[0], tempSplit[1], tempSplit[2], tempSplit[3], Convert.ToInt32(tempSplit[4]), Convert.ToInt32(tempSplit[5]), Convert.ToInt32(tempSplit[6]));
                    }
                    tempList.Add(tempConsultation);
                    ++x;
                }
                return tempList;
            }
        }
        
    }
}
