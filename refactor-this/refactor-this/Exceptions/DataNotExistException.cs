using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_this.Exceptions
{
    public class DataNotExistException: Exception
    {
        public DataNotExistException(): base()
        {

        }

        public DataNotExistException(string message): base(message)
        {

        }
    }
}