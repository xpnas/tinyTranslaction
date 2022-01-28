using System;
using System.Collections.Generic;
using System.Text;

namespace tinyTransaction
{
    public abstract class CanTranscationEntity
    {
        public int TranscationId { get; internal set; }

        public abstract object Clone();
    }
}
