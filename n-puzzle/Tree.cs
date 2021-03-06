﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n_puzzle {
    public abstract class Tree {
        public Tree(State state) {
            if(state == null)
                throw new ArgumentNullException("Argument state not initialized.");
        }
        public abstract void expandFrontier(List<Node> childNode);
        public abstract bool isEmpty();
        public abstract Node pop(string key = "");
        public abstract void push(Node node, string key = "");

    }

    public class QueueTree : Tree {
        Queue<Node> frontier;
        public QueueTree(State state) : base (state){
            Node node = new Node(state, null, null, 0);
            frontier = new Queue<Node>();
            frontier.Enqueue(node);
        }

        public override void expandFrontier(List<Node> childNode) {
            for(int i = 0; i < childNode.Count; i++) push(childNode.ElementAt(i));
        }

        public override bool isEmpty() {
            if(frontier.Count == 0) return true;
            return false;
        }

        public Node getNext() {
            return frontier.First();
        }

        public override Node pop(string key = "") {
            return frontier.Dequeue();
        }

        public override void push(Node node, string key = "") {
            frontier.Enqueue(node);
        }
    }

    public class StackTree : Tree {
        Stack<Node> frontier;
        public StackTree(State state) : base(state) {
            Node node = new Node(state, null, null, 0);
            frontier = new Stack<Node>();
            frontier.Push(node);
        }

        public override void expandFrontier(List<Node> childNode) {

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

    public class SortedTree : Tree {
        SortedSet<Node> frontier;
        public SortedTree(State state) : base(state) {
            Node node = new Node(state, null, null, 0);
            frontier = new SortedSet<Node>();
            frontier.Add(node);
        }

        public override bool isEmpty() {
            if(frontier.Count == 0) return true;
            return false;
        }

        public override Node pop(string id) {
            return frontier.Min;
        }

        public override void push(Node node, string key = "") {
            frontier.Add(node);
        }

        public int getCost(int cost) {
            Node node = new Node(null, null, null, 1);
            return frontier.Min.cost;
        }

        public override void expandFrontier(List<Node> childNode) {
        }
    }
}
