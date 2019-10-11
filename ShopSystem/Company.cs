using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    class Company:Client
    {
        private string companyName;
        private string bussinesName;
        private int rut;

        private Company(int id,string companyName, string bussinesName, int rut, string address, string mail, string user, string password, bool isFromMontevideo) : base(id,address,mail,user,password,isFromMontevideo)
        {
            this.companyName = companyName;
            this.bussinesName = bussinesName;
            this.rut = rut;
        }

        public static Company AddCompanyClient(int id, string companyName, string bussinesName, int rut, string address, string mail, string user, string password, bool isFromMontevideo)
        {
            return new Company(id,companyName,bussinesName, rut, address, mail, user, password, isFromMontevideo);
        }
    }
}