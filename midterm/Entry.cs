using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace midterm
{
    [Serializable]
    public class Entry
    {
        [XmlAttribute] public int _id;
        private string _name;
        private string email;
        private string phone_number;
       
        public Entry(int _id, string _name, string email, string phone_number)
        {
            this._id = _id;
            this._name = _name;
            this.email = email;
            this.phone_number = phone_number;
        }
        public Entry() { }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Phone_number
        {
            get { return phone_number; }
            set { phone_number = value; }
        }
    }
}