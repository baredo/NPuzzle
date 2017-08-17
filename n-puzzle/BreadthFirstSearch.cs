using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n_puzzle {
    class BreadthFirstSearch {
        Tree tree;

        Func<string, string> actionList;
        public BreadthFirstSearch(Tree tree, Func<string, string> actionList) {
            this.tree = tree;
            this.actionList = actionList;
            actionList("a");
        }

        public void action() {

        }
    }
}
