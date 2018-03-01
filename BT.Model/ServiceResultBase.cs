using System;
using System.Collections.Generic;
using System.Text;

namespace BT.Model
{
    public class ServiceResultBase
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

    }

    public class ServiceResult<T> : ServiceResultBase
    {
        public T Result { get; set; }
    }
}
