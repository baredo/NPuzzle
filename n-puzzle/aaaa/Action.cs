using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n_puzzle {
    class Action {
        //string name;
        //short id;
        int cost;

        public string name { get; }
        public short id { get; }

        public Action(string name, short id, int cost=1) {
            this.name = name;
            this.cost = cost;
            this.id = id;
        }

        public bool isPossible(State state) {

            return false;
        }
    }
}
