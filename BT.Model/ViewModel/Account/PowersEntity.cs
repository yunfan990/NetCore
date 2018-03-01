using System;
using System.Collections.Generic;
using System.Text;

namespace BT.Model.ViewModel.Account
{
    public class PowersEntity
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
        /// ParentID
        /// </summary>
        public int ParentID { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Sort
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// State
        /// </summary>
        public bool State { get; set; }
    }
}
