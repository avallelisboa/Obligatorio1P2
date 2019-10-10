using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    public class Common:Client
    {
        private string name;
        private string address;
        private Common(int number, string name, string celular, string address, string mail, string user, string password, bool isFromMontevideo) : base(number, address,mail,user, password, isFromMontevideo)
        {
            this.name = name;
            this.address = address;
        }

        public static Common AddCommonClient(string name, string celular, string address, string mail, string user, string password, bool isFromMontevideo)
        {
            int number = 6464654;
            return new Common(number, name, celular, address, mail, user, password, isFromMontevideo);
        }
    }
}
