using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using n_puzzle;

namespace n_puzzleTest {
    /// <summary>
    /// Descripción resumida de StateTest
    /// </summary>
    [TestClass]
    public class StateTest {
        public StateTest() {
            
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void SetRandom3x3() {
            //Arrange
            State state = new State(3, 3);
            List<int> lista = new List<int>();
            for(int i = 0; i < 9; i++) lista.Add(i);

            //Act
            state.setRandom();
            
            //Assert
            for(int i = 0; i < 3; i++) {
                for(int j = 0; j < 3; j++) {
                    if(!lista.Remove(state.state[i][j])) Assert.Fail();
                }
            }
            if(lista.Count != 0) Assert.Fail();
        }

        [TestMethod]
        public void SetRandom4x4() {
            //Arrange
            State state = new State(4, 4);
            List<int> lista = new List<int>();
            for(int i = 0; i < 16; i++) lista.Add(i);

            //Act
            state.setRandom();

            //Assert
            for(int i = 0; i < 4; i++) {
                for(int j = 0; j < 4; j++) {
                    if(!lista.Remove(state.state[i][j])) Assert.Fail();
                }
            }
            if(lista.Count != 0) Assert.Fail();
        }
    }
}
