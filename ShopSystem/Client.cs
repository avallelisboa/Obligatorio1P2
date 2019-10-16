using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    public class Client
    {
        private int id;
        private string phone;
        private string address;
        private string mail;
        private DateTime registerDate;
        private string user;
        private string password;
        private bool isFromMontevideo;

        public class clientValidation
        {
            public clientValidation(bool isMailUsed, bool isUserUsed)
            {
                this.isMailUsed = isMailUsed;
                this.isUserUsed = isUserUsed;
            }
            public bool isMailUsed;
            public bool isUserUsed;
        }

        public int Id { get { return id; } }
        public string Phone { get { return phone; } }
        public string Address { get { return address; } }
        public string Mail { get { return mail; } }
        public DateTime RegisterDate { get { return registerDate; } }
        public string User { get { return user; } }
        public string Password { get { return password; } }
        public bool IsFromMontevideo { get { return isFromMontevideo; } }

        internal Client(int id, string address, string mail, string phone, string user, string password, bool isFromMontevideo)
        {
            this.id = id;
            this.address = address;
            this.mail = mail;
            this.phone = phone;
            this.user = user;
            this.password = password;
            this.isFromMontevideo = isFromMontevideo;
            registerDate = DateTime.Today;
        }

        public static clientValidation isInformationCorrect(List<Client>clients, string user, string mail)
        {
            int id = clients.Count;
            bool isMailUsed = false;
            bool isUserUsed = false;
            foreach (Client c in clients)
            {
                if (c.Mail == mail)
                {
                    isMailUsed = true;
                }
                if (c.User == user)
                {
                    isUserUsed = true;
                }
                if (isUserUsed || isUserUsed) break;
            }            
            clientValidation clientValidation = new clientValidation(isMailUsed, isUserUsed);
            return clientValidation;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
