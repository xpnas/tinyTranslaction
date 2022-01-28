using System;
using System.Collections.Generic;
using System.Text;

namespace tinyTransaction
{
    public class TTransaction : IDisposable
    {
        internal TTransaction(string name, ICanTranscation canTranscation)
        {
            Path = name.Trim();
            _canTranscation = canTranscation;
            _transcationId = canTranscation.TranscationStack.Count > 0 ? canTranscation.TranscationStack.Peek() + 1 : 1;
            _canTranscation.TranscationStack.Push(_transcationId);
        }

        private int _transcationId;

        private bool _isSbumit = false;

        private ICanTranscation _canTranscation;

        public string Path { get; private set; }

        public TTransaction GetTransaction(string name)
        {
            return new TTransaction(name + "@" + Path, _canTranscation);
        }

        public void Commit()
        {
            TransCheck();
            _canTranscation.CommitDo();
            _canTranscation.TranscationStack.Pop();
            _isSbumit = true;
        }

        public void RoalBack()
        {
            TransCheck();
            _canTranscation.RoalDo();
            _canTranscation.TranscationStack.Pop();
            _isSbumit = true;
        }

        public void Dispose()
        {
            if (!_isSbumit)
                Commit();
        }

        public void TransCheck()
        {
            if (_canTranscation.TranscationId != _transcationId)
                throw new Exception("has other trans not commit or roalback!");
            
        }
    }
}
