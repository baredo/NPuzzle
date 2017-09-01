using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n_puzzle {
    public class BreadthFirstSearch {
        QueueTree tree;
        List<Action> actionList;
        Func<State, List<Action>, List<Action>> actionAllowed;
        Func<State, Action, List<Action>, State> doAction;
        public BreadthFirstSearch(  State firstState, 
                                    List<Action> actionList, 
                                    Func<State, List<Action>, List<Action>> actionAllowed,
                                    Func<State, Action, List<Action>, State> doAction) {
            this.tree = new QueueTree(firstState);
            this.actionList = actionList;
            this.actionAllowed = actionAllowed;
            this.doAction = doAction;
        }

        public Node exec(int depth) {
            while(tree.getNext().depth < depth) {
                List<Action> listActionAllowed = actionAllowed(tree.getNext().state, actionList);
                List<Node> listNode = new List<Node>();
                foreach(var item in listActionAllowed) {
                    State newState = new State(tree.getNext().state);
                    newState = doAction(newState, item, actionList);
                    listNode.Add(new Node(newState, tree.getNext(), item, tree.getNext().cost+1));
                }
                tree.expandFrontier(listNode);
            }
            return tree.getNext().parent;
        }

        public void action() {

        }
    }
}
