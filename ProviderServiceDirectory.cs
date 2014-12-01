using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChocAn
{
    static class ProviderServiceDirectory
    {
        public static bool addServiceCode(string serviceName, int serviceNumber, int dollars)
        {
            string path = Directory.GetCurrentDirectory();
            try
            {
                using (StreamWriter file = File.AppendText(path + @"\providerServiceCodes\providerServiceCodes.txt"))
                {
                    file.WriteLine(serviceName + serviceNumber + dollars);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.ToString(), "origional");
            }
        }
        public static string verifyServiceCode(int serviceID)
        {
            List<Info> serviceCodes = readInServices();
            foreach(Info code in serviceCodes)
            {
                if (serviceID == code.serviceCode)
                    return (code.serviceName);
            }
            return "service code does not exist!";
            
        }
        public static List<Info> readInServices()
        {
            //providerServiceCodes
            try
            {
                string path = Directory.GetCurrentDirectory();
                System.IO.StreamReader file = new System.IO.StreamReader(path + @"\providerServiceCodes\providerServiceCodes.txt");

                string rawData;
                string[] tempSplit;
                Info tempInfo = new Info();

                List<Info> tempMemberInfo = new List<Info>();

                while ((rawData = file.ReadLine()) != null)
                {
                    tempSplit = rawData.Split(',');

                    tempInfo.serviceName = tempSplit[0];
                    tempInfo.serviceCode = Convert.ToInt32(tempSplit[1]);
                    tempInfo.dollarAmount = Convert.ToInt32(tempSplit[2]);

                    tempMemberInfo.Add(tempInfo);
                }
                return tempMemberInfo;
            }
            catch(Exception ex)
            {
                throw new System.ArgumentException(ex.ToString(), "origional");
            }
        }
    }
}
