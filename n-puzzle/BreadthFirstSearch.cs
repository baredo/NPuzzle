using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n_puzzle {
    public class BreadthFirstSearch {
        QueueTree tree;
        State goal;
        List<Action> actionList;
        Func<State, List<Action>, List<Action>> actionAllowed;
        Func<State, Action, List<Action>, State> doAction;
        public BreadthFirstSearch(  State firstState,
                                    State goalState,
                                    List<Action> actionList, 
                                    Func<State, List<Action>, List<Action>> actionAllowed,
                                    Func<State, Action, List<Action>, State> doAction) {
            this.tree = new QueueTree(firstState);
            this.goal = goalState;
            this.actionList = actionList;
            this.actionAllowed = actionAllowed;
            this.doAction = doAction;
        }

        public Node exec(int depth){
            for(Node fatherNode = tree.pop(); fatherNode.depth < depth; fatherNode = tree.pop()){
                List<Action> listActionAllowed = actionAllowed(fatherNode.state, actionList);
                List<Node> listNode = new List<Node>();
                listNode = goDeep(listActionAllowed, fatherNode);
                tree.expandFrontier(listNode);
            }
            return tree.getNext().parent;
        }

        private Node openNode(Action action, Node fatherNode) {
            State newState = new State(fatherNode.state);
            newState = doAction(newState, action, actionList);
            return new Node(newState, fatherNode, action, fatherNode.cost + 1);
        }

        /* Develops a branch of the tree. Returns the nodes of that operation, 
         * if the optimal is found it cuts the search and returns the list of 
         * used nodes, being the last the optimal one.
         * */
        private List<Node> goDeep(List<Action> listActionAllowed, Node fatherNode) {
            List<Node> listNode = new List<Node>();
            foreach(var item in listActionAllowed) {
                if(fatherNode.action != null) {
                    if(fatherNode.action.id != item.id) {
                        Node node = openNode(item, fatherNode);
                        listNode.Add(node);
                        if(node.state.isEqual(goal)) return listNode;
                    }
                }else {
                    Node node = openNode(item, fatherNode);
                    listNode.Add(node);
                    if(node.state.isEqual(goal)) return listNode;
                }  
            }
            return listNode;
        }
    }
}
