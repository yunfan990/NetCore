using System;
using System.Collections.Generic;
using System.Text;

namespace BT.Model.ViewModel.Account
{
    public class AccountEntity
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime AddTime { get; set; }
    }

    public class AccountLoginEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }
    }
    /// <summary>
    /// 注册类
    /// </summary>
    public class AccountRegisterEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }

    }

    public class QueryAccount
    {
        public int ID { get; set; }

        public string UserName { get; set; }
    }
}
