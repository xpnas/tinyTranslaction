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
            Entities = new List<ICanTranscationEntity>();
        }

        public int TranscationId { get { return TranscationStack.Peek(); } }

        public Stack<int> TranscationStack { get; private set; }

        public void CommitDo()
        {
            Entities.ForEach(e => {
            
            });
        }

        public TTransaction GetTransaction(string name) 
        {
            if (TranscationStack.Count > 0)
                throw new Exception("only one transcation at one time");

            return new TTransaction(name,this);
        }

        public void RoalDo()
        {
            Entities.RemoveAll(new Predicate<ICanTranscationEntity>(e => { return e.TranscationId >= TranscationId; }));
        }

        public void Save() 
        { 
        
        }

        public List<ICanTranscationEntity> Entities { get; private set; }

        public void AddEntity(ICanTranscationEntity entity)
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
