using System;
using System.Collections.Generic;
using System.Text;

namespace tinyTransaction
{
    public class TranscationException:Exception
    {
        public TranscationException(string message):base(message)
        {

        }
    }
}
