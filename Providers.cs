using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChocAn
{
    class Providers
    {
        public static bool addProvider(Info info)
        {
            string path = Directory.GetCurrentDirectory();
            try
            {
                using (StreamWriter file = File.AppendText(path + @"\provider"))
                {
                    file.WriteLine(info.name + "," + info.ID + "," + info.address + "," + info.city + "," + info.state + "," + info.zip);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.ToString(), "origional");
            }
        }
        public static bool removeProvider(string name, int ID)
        {
            List<Info> memberInfo = new List<Info>();

            try
            {
                memberInfo = readProvider();
                foreach (Info member in memberInfo)
                {
                    if (member.name == name && member.ID == ID)
                    {
                        memberInfo.Remove(member);
                    }
                    else
                    {
                        addProvider(member);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.ToString(), "origional");
            }
        }
        public static List<Info> readProvider()
        {
            string path = Directory.GetCurrentDirectory();
            System.IO.StreamReader file = new System.IO.StreamReader(path + @"\provider\provider.txt");

            string rawData;
            string[] tempSplit;
            Info tempInfo = new Info();

            List<Info> tempMemberInfo = new List<Info>();

            while ((rawData = file.ReadLine()) != null)
            {
                tempSplit = rawData.Split(',');
                tempInfo.name = tempSplit[0];
                tempInfo.ID = Convert.ToInt32(tempSplit[1]);
                tempInfo.address = tempSplit[2];
                tempInfo.city = tempSplit[3];
                tempInfo.state = tempSplit[4];
                tempInfo.zip = Convert.ToInt32(tempSplit[5]);

                tempMemberInfo.Add(tempInfo);
            }
            return tempMemberInfo;
        }
    }
}
