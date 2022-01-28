using System;
using System.Collections.Generic;
using System.Text;

namespace tinyTransaction.Entites
{
    public class GclQiang : CanTranscationEntity
    {
        public string Name { get; set; }

        public int L { get; set; }

        public GclQiang(string name,int l)
        {
            Name = name;
            L = l;
        }

        public override object Clone()
        {
            return new GclQiang(this.Name, this.L);
        }
    }
}
