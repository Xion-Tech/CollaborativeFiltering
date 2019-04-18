using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CollaborativeFiltering
{
    class Association
    {
        int UserId { get; set; }
        List<int, int> SimilarityMatrix {get;set;}// = new List<int, int>();
        public Association()
        {
            this.SimilarityMatrix = new List<int, int>();
        }
       // new List<int, int>() SimilarityMatrix{get;set;}
    }
}
