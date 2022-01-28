using System;
using System.Collections.Generic;
using System.Text;

namespace tinyTransaction
{
    [Serializable]
    public class TranscationException:Exception
    {
        public TranscationException(string message):base(message)
        {

        }
    }
}
