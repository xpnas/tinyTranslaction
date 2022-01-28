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

        private readonly int _transcationId;

        private readonly ICanTranscation _canTranscation;

        private bool _isSbumit = false;


        public string Path { get; private set; }

        public TTransaction GetTransaction(string name)
        {
            return new TTransaction(name + "@" + Path, _canTranscation);
        }

        public void Commit()
        {
            TransCheck();
            _canTranscation.DoCommit();
            _canTranscation.TranscationStack.Pop();
            _isSbumit = true;
        }

        public void RoalBack()
        {
            TransCheck();
            _canTranscation.DoRoal();
            _canTranscation.TranscationStack.Pop();
            _isSbumit = true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isSbumit)
                Commit();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void TransCheck()
        {
            if (_canTranscation.TranscationId != _transcationId)
                throw new TranscationException("has other trans not commit or roalback!");
            
        }
    }
}
