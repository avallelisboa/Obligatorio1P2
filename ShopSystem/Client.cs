using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    public class Client
    {
        private int number;
        private string phone;
        private string address;
        private string mail;
        private DateTime registerDate;
        private string user;
        private string password;
        private bool isFromMontevideo;

        public int Number { get { return number; } }
        public string Phone { get { return phone; } }
        public string Address { get { return address; } }
        public string Mail { get { return mail; } }
        public DateTime RegisterDate { get { return registerDate; } }
        public string User { get { return user; } }
        public string Password { get { return password; } }
        public bool IsFromMontevideo { get { return isFromMontevideo; } }

        internal Client(int number, string address, string mail, string user, string password, bool isFromMontevideo)
        {
            this.number = number;
            this.address = address;
            this.mail = mail;
            this.user = user;
            this.password = password;
            this.isFromMontevideo = isFromMontevideo;
            registerDate = DateTime.Today;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
