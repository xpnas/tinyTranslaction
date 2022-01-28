using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace tinyTransaction
{
    public class TDocument: ICanTranscation
    {

        public TDocument()
        {
            TranscationStack = new Stack<int>();
            Entities = new List<CanTranscationEntity>();
        }

        public int TranscationId { get { return TranscationStack.Peek(); } }

        public Stack<int> TranscationStack { get; private set; }

        public void DoCommit()
        {
            Entities.ForEach(e => {
            
            });
        }

        public TTransaction GetTransaction(string name) 
        {
            if (TranscationStack.Count > 0)
                throw new TranscationException("only one transcation at one time");

            return new TTransaction(name,this);
        }

        public void DoRoal()
        {
            Entities.RemoveAll(new Predicate<CanTranscationEntity>(e => { return e.TranscationId >= TranscationId; }));
        }

        public void Save() 
        { 
            // TODO
        }

        public List<CanTranscationEntity> Entities { get; private set; }

        public void AddEntity(CanTranscationEntity entity)
        {
            entity.TranscationId = TranscationId;
            Entities.Add(entity);
        }

        public List<T> OfType<T>()
        {
            return Entities.OfType<T>().ToList();
        }
    }
}
