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
            Entities.RemoveAll(new Predicate<CanTranscationEntity>(e => { return e.TranscationId + TranscationId == 0; }));
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
            Entities.ForEach(e =>
            {
                if (e.TranscationId < 0 && (e.TranscationId + TranscationId) > 0)
                    e.TranscationId = 0 - e.TranscationId;
            });
            Entities.RemoveAll(new Predicate<CanTranscationEntity>(e => { return e.TranscationId + TranscationId == 0; }));
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

        public void RemoveEntity(CanTranscationEntity entity)
        {
            if (Entities.Contains(entity))
            {
                entity.TranscationId =-entity.TranscationId;
            }
        }

        public List<T> OfType<T>() where T:CanTranscationEntity
        {
            return Entities.OfType<T>().Where(e=>e.TranscationId>=0).ToList();
        }
    }
}
