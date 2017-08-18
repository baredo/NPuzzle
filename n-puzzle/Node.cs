using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n_puzzle {
    class Node {
        State state;
        Node parent;
        Action action;
        public int cost { get; }

        public Node(State state, Node parent, Action action, int cost) {
            this.state = state;
            this.parent = parent;
            this.action = action;
            this.cost = cost;
        }
    }
}
