using System;
using System.Collections.Generic;
using System.Text;

namespace BT.Core.Repository.DbModel
{
    public class Account
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime AddTime { get; set; }
    }
}
