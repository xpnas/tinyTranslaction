using System;
using System.Collections.Generic;
using System.Text;

namespace tinyTransaction.Entites
{
    public class GclZhu : CanTranscationEntity
    {
        public GclZhu()
        {

        }

        public GclZhu(string name, int h, int w, int l)
        {
            this.Name = name;
            this.W = w;
            this.L = l;
            this.H = h;
        }

        public string Name { get; set; }

        public int H { get; set; }

        public int W { get; set; }

        public int L { get; set; }

        public override object Clone()
        {
            return new GclZhu()
            {
                Name = this.Name,
                H = this.H,
                W = this.W,
                L = this.L,
            };
        }
    }
}
