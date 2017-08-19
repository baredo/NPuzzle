using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n_puzzle {
    abstract class Tree {
        public Tree(State state) {
            
        }
        public void expandFrontier(Action action) {
            //queue.Enqueue();
        }
        public abstract bool isEmpty();
        public abstract Node pop(string key = "");
        public abstract void push(Node node, string key = "");

    }

    class QueueTree : Tree {
        Queue<Node> frontier;
        public QueueTree(State state) : base (state){
            Node node = new Node(state, null, null, 0);
            frontier.Enqueue(node);
        }

        public override bool isEmpty() {
            if(frontier.Count == 0) return true;
            return false;
        }

        public override Node pop(string id) {
            return frontier.Dequeue();
        }

        public override void push(Node node, string key = "") {
            frontier.Enqueue(node);
        }
    }

    class StackTree : Tree {
        Stack<Node> frontier;
        public StackTree(State state) : base(state) {
            Node node = new Node(state, null, null, 0);
            frontier.Push(node);
        }

        public override bool isEmpty() {
            if(frontier.Count == 0) return true;
            return false;
        }

        public override Node pop(string id) {
            return frontier.Pop();
        }

        public override void push(Node node, string key = "") {
            frontier.Push(node);
        }
    }

    class SortedTree : Tree {
        SortedSet<Node> frontier;
        public SortedTree(State state) : base(state) {
            Node node = new Node(state, null, null, 0);
            push(node);
        }

        public override bool isEmpty() {
            if(frontier.Count == 0) return true;
            return false;
        }

        public override Node pop(string id) {
            return frontier.First<Node>();
        }

        public override void push(Node node, string key = "") {
            frontier.Add(node);
        }

        public Node getCost(int cost) {
            Node node = new Node(null, null, null, 1);
            return node;
        }
    }
}
