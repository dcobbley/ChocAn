using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChocAn
{
    static class Members
    {
        public static bool addMembers(Info info)
        {
            string path = Directory.GetCurrentDirectory();
            try
            {
                using (StreamWriter file = File.AppendText(path + @"\members\members.txt"))
                {
                    file.WriteLine(info.name + "," + info.ID + "," + info.address + "," + info.city + "," + info.state + "," + info.zip + "," + "valid" + " ");
                }
                return true;
            }
            catch (Exception ex) 
            {
                throw new System.ArgumentException(ex.ToString(), "origional");
            }
        }
        public static bool removeMember(string name, int ID)
        {
            List<Info> memberInfo = new List<Info>();

            try
            {
                memberInfo = readMembers();
                foreach(Info member in memberInfo)
                {
                    if(member.name == name && member.ID == ID)
                    {
                        memberInfo.Remove(member);
                    }
                    else
                    {
                        addMembers(member);
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                throw new System.ArgumentException(ex.ToString(), "origional");
            }
        }
        public static string validateMember(int ID)
        {
            List<Info> memberInfo = new List<Info>();
            memberInfo = readMembers();
            foreach (Info member in memberInfo)
            {
                if (member.ID == ID && member.valid =="valid")
                {
                    return (member.valid);
                }
                else if(member.ID ==ID && member.valid != "valid")
                {
                    return (member.valid + member.reason);
                }
            }
            return "Non existent member.";
        }

        public static bool invalidateMember(int ID, string reason)
        {
            List<Info> memberInfo = new List<Info>();
            memberInfo = readMembers();
            bool flag = false;

            foreach (Info member in memberInfo)
            {
                if (member.ID == ID && member.reason == reason)
                {
                    member.valid = "invalid";
                    member.reason = reason;
                    addMembers(member);
                    flag = true;
                }
                else
                {
                    addMembers(member);
                }
            }
            if (flag)
                return true;
            else
                return false;
              
        }
        public static List<Info> readMembers()
        {
            string path = Directory.GetCurrentDirectory();
            System.IO.StreamReader file = new System.IO.StreamReader(path + @"\members\members.txt");

            string rawData;
            string[] tempSplit;
            Info tempInfo=new Info();

            List<Info> tempMemberInfo = new List<Info>();
 
            while((rawData = file.ReadLine()) != null)
            {
                tempSplit=rawData.Split(',');
                tempInfo.name=tempSplit[0];
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
