using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using n_puzzle;
using System.Collections.Generic;
namespace n_puzzleTest {
    [TestClass]
    public abstract class TreeTest {
        protected Tree tree;
        /*[ClassInitialize()]
        public void TreeTestInit() {
            List<n_puzzle.Action> actionList;
            try {
                tree = new QueueTree(null);
            } catch {
                actionList = new List<n_puzzle.Action>();
                actionList.Add(new n_puzzle.Action("goUp", 0));
                actionList.Add(new n_puzzle.Action("goDown", 1));
                actionList.Add(new n_puzzle.Action("goLeft", 2));
                actionList.Add(new n_puzzle.Action("goRight", 3));
                tree = new QueueTree(new State(1, 1, actionList));
            }
            
            actionList = new List<n_puzzle.Action>();
            actionList.Add(new n_puzzle.Action("goUp", 0));
            actionList.Add(new n_puzzle.Action("goDown", 1));
            actionList.Add(new n_puzzle.Action("goLeft", 2));
            actionList.Add(new n_puzzle.Action("goRight", 3));
            tree = new QueueTree(new State(1, 1, actionList));
        }*/

        [TestInitialize()]
        public void Initialize() {
            try {
                tree = new QueueTree(null);
            } catch {
                tree = new QueueTree(new State(1, 1));
            }
        }

        [TestMethod]
        public abstract void isEmptyTest();
    }

    [TestClass]
    public class QueueTreeTest : TreeTest {

        

        [TestMethod]
        public override void isEmptyTest() {
            tree.isEmpty();
        }
    }
}
