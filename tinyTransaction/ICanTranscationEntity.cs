using System;
using System.Collections.Generic;
using System.Text;

namespace tinyTransaction
{
    public abstract class ICanTranscationEntity
    {
        public int TranscationId { get; internal set; }

        public abstract object Clone();
    }
}
