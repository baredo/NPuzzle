using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n_puzzle {
    class Tree {
        Queue<Node> queue;
        public Tree(State state) {
            Node node = new Node(state, null, null, 0);
        }

    }
}
