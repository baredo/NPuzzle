using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n_puzzle {
    public class Node {
        public State state { get; }
        public Node parent { get; }
        Action action;
        public int depth { get; }
        public int cost { get; }

        public Node(State state, Node parent, Action action, int cost) {
            this.state = state;
            this.parent = parent;
            this.action = action;
            this.cost = cost;
            if(parent == null) this.depth = 0;
            else this.depth = parent.depth + 1;
        }
    }
}
