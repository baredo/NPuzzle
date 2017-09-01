using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n_puzzle {

    public struct Point {
        public int x, y;
        public Point(int x, int y){ this.x = x; this.y = y;}
    };

    public class State {
        public int[][] state { get; }
        public int height { get; }
        public int width { get; }

        public int getValue(int y, int x) {
            return state[y][x];
        }
        public State(int width, int height) {           
            state = new int[height][];
            for(int i = 0; i < height; i++) {
                state[i] = new int[width];
            }
            this.width = width;
            this.height = height;
            setRandom();
        }

        public State(State state) {
            this.state = state.state;
        }

        public void setGoal() {
            for(int i = 0; i < state.Length; i++) {
                for(int j = 0; j < state[i].Length; j++) {
                    state[i][j] = i * width + j;
                }
            }
        }

        public void setRandom() {
            List<int> numChoose = new List<int>(width*height);
            for(int i = 0; i < state.Length * state[0].Length; i++) {
                numChoose.Add(i);
            }
            Random randomFactor = new Random();
            int randomNumber;
            for(int i = 0; i < state.Length; i++) {
                for(int j = 0; j < state[i].Length; j++) {
                    randomNumber = randomFactor.Next() % numChoose.Count;
                    state[i][j] = numChoose.ElementAt(randomNumber);
                    numChoose.RemoveAt(randomNumber);
                }
            }
        }
    }
}
