using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using n_puzzle;

namespace n_puzzleTest {
    /// <summary>
    /// Descripción resumida de nPuzzle
    /// </summary>
    [TestClass]
    public class nPuzzleTest {
        public nPuzzleTest() {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [TestMethod]
        public void getPosition0() {
            //Arrange
            nPuzzle game = new nPuzzle();
            PrivateObject obj = new PrivateObject(game);
            State state = new State(2, 2);
            state.state[0][0] = 1; state.state[0][1] = 0;
            state.state[1][0] = 1; state.state[1][1] = 1;

            //Act
            Point result = (Point)obj.Invoke("getPosition", state, 0);

            //Assert
            Assert.AreEqual(0, result.y);
            Assert.AreEqual(1, result.x);
        }
    }
}
