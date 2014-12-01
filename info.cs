using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocAn
{
    public class Info
    {
        //used for members and providers
        public string name, address, city, state, valid, reason;
        public int zip, ID;

        //used for providerServiceDirectory
        public string serviceName;
        public int serviceCode;
        public int dollarAmount;

        public Info()
        { }
    }
}
