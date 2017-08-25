using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using n_puzzle;
using System.Collections.Generic;
namespace n_puzzleTest {
    [TestClass]
    public abstract class TreeTest {
        protected Tree tree;

        [TestInitialize()]
        public void Initialize() {
            try {
                tree = new QueueTree(null);
            } catch {
                tree = new QueueTree(new State(1, 1));
            }
        }

    }

    [TestClass]
    public class QueueTreeTest : TreeTest {

        

        [TestMethod]
        public void EmptyFrontier() {
            Assert.IsFalse(tree.isEmpty());
        }

        [TestMethod]
        public void NotEmptyFrontier() {
            //Arrange
            List<Node> emptyListChildNode = new List<Node>();
            tree.expandFrontier(emptyListChildNode);
            //Act
            bool isEmpty = tree.isEmpty();
            //Assert
            Assert.IsTrue(isEmpty);
        }
    }
}
