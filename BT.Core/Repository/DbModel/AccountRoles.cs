using System;
using System.Collections.Generic;
using System.Text;

namespace BT.Core.Repository.DbModel
{
    public class AccountRoles
    {
        /// <summary>
		/// auto_increment
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// AccountID
        /// </summary>
        public int AccountID { get; set; }
        /// <summary>
        /// RoleID
        /// </summary>
        public int RoleID { get; set; }
    }
}
