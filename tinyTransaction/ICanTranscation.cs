using System;
using System.Collections.Generic;
using System.Text;

namespace tinyTransaction
{
    public interface ICanTranscation
    {
        public int TranscationId { get; }

        public Stack<int> TranscationStack { get; }

        public void RoalDo();

        public void CommitDo();
    }
}
