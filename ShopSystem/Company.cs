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

        private Company(string companyName, string bussinesName, int rut, int number, string address, string mail, string user, string password, bool isFromMontevideo) : base(number,address,mail,user,password,isFromMontevideo)
        {
            this.companyName = companyName;
            this.bussinesName = bussinesName;
            this.rut = rut;
        }

        public static Company AddCompanyClient(string companyName, string bussinesName, int rut, string address, string mail, string user, string password, bool isFromMontevideo)
        {
            int number = 6464654;
            return new Company(companyName,bussinesName, rut, number, address, mail, user, password, isFromMontevideo);
        }
    }
}