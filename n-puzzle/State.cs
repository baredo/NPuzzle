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

    class State {
        private int[][] state { get; }
        private List<Action> allowedActionList;
        private List<Action> actionList;

        public State(int width, int height, List<Action> actionList) {           
            state = new int[height][];
            for(int i = 0; i < height; i++) {
                state[i] = new int[width];
            }
            this.actionList = actionList;
            setRandom();
            allowedAction();
        }

        public State(State state) {
            this.state = state.state;
            this.actionList = state.actionList;
            allowedAction();
        }

        public void setGoal() {
            for(int i = 0; i < state.Length; i++) {
                for(int j = 0; j < state[i].Length; j++) {
                    state[i][j] = i * 3 + j;
                }
            }
        }

        public void setRandom() {
            List<int> numChoose = new List<int>(9);
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

        public State doAction(Action action) {
            Point zPoint = getPosition(0);
            State newState = new State(this);
            foreach(var allowedAct in allowedActionList) {
                if(action.id == allowedAct.id) {
                    switch(action.id) {
                        case 0: //MoveUp
                            newState.state[zPoint.x][zPoint.y] = newState.state[zPoint.x][zPoint.y - 1];
                            newState.state[zPoint.x][zPoint.y - 1] = 0;
                            break;
                        case 1: //MoveDown
                            newState.state[zPoint.x][zPoint.y] = newState.state[zPoint.x][zPoint.y + 1];
                            newState.state[zPoint.x][zPoint.y + 1] = 0;
                            break;
                        case 2: //MoveLeft
                            newState.state[zPoint.x][zPoint.y] = newState.state[zPoint.x - 1][zPoint.y];
                            newState.state[zPoint.x - 1][zPoint.y] = 0;
                            break;
                        case 3: //MoveRight
                            newState.state[zPoint.x][zPoint.y] = newState.state[zPoint.x + 1][zPoint.y];
                            newState.state[zPoint.x + 1][zPoint.y] = 0;
                            break;
                        default:
                            return null;
                    }
                }
            }
            return new State(this);
        }

        private List<Action> allowedAction() {
            allowedActionList = new List<Action>();
            foreach(var item in actionList) {
                allowedActionList.Add(item);
            }
            Point zeroValue = getPosition(0);
            int fix = 1;
            if(zeroValue.x == 0) allowedActionList.RemoveAt(0);
            else if(zeroValue.x == state[0].Length-1) allowedActionList.RemoveAt(1);
            else fix = 0;
            if(zeroValue.y == 0) allowedActionList.RemoveAt(2-fix);
            else if(zeroValue.y == state.Length-1) allowedActionList.RemoveAt(3-fix);

            return allowedActionList;
        }

        private Point getPosition(int value) {
            for(int i=0; i<state.Length; i++) {
                for(int j = 0; j < state[i].Length; j++) {
                    if(state[i][j] == value) return new Point(i,j);
             
                }
            }
            return new n_puzzle.Point(-1,-1);
        }
    }
}
