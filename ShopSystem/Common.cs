using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    public class Common:Client
    {
        private string name;
        private string address;
        private Common(int id, string name, string celular, string address, string mail, string user, string password, bool isFromMontevideo) : base(id, address,mail,user, password, isFromMontevideo)
        {
            this.name = name;
            this.address = address;
        }

        public static Common AddCommonClient(int id, string name, string celular, string address, string mail, string user, string password, bool isFromMontevideo)
        {
            return new Common(id, name, celular, address, mail, user, password, isFromMontevideo);
        }
    }
}
