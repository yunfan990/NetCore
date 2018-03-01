using System;
using System.Collections.Generic;
using System.Text;

namespace BT.Model.ViewModel.Account
{
    public class RolesEntity
    {
        /// <summary>
        /// auto_increment
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// Powers
        /// </summary>
        public string Powers { get; set; }
    }
}
