using System;
using System.Collections.Generic;

namespace n_puzzle {

    public class nPuzzle {
        List<Action> actionList;
        State initState;
        State goalState;
        BreadthFirstSearch searcher;

        public nPuzzle() {
            actionList = new List<Action>();
            actionList.Add(new Action("goUp", (short)Direction.up));
            actionList.Add(new Action("goDown", (short)Direction.down));
            actionList.Add(new Action("goLeft", (short)Direction.left));
            actionList.Add(new Action("goRight", (short)Direction.right));

            initState = new State(3, 3);
            goalState = new State(3, 3);
            goalState.setGoal();

            Func<State, List<Action>, List<Action>> convertMethod = actionAllowed;
            Func<State, Action, List<Action>, State> convertMethod2 = doAction;
            searcher = new BreadthFirstSearch(initState, goalState, actionList, convertMethod,
                                                                convertMethod2);
        }

        public Node nextStep() {
            return searcher.exec(16);
        }

        private List<Action> actionAllowed(State state, List<Action> actionList) {
            List<Action> allowedActionList = new List<Action>();
            foreach(var item in actionList) {
                allowedActionList.Add(item);
            }
            Point zeroValue = getPosition(state, 0);
            if(zeroValue.x == 0) allowedActionList.RemoveAt(2);
            else if(zeroValue.x == state.height - 1) allowedActionList.RemoveAt(3);
            if(zeroValue.y == 0) allowedActionList.RemoveAt(0);
            else if(zeroValue.y == state.width - 1) allowedActionList.RemoveAt(1);

            return allowedActionList;
        }

        private Point getPosition(State state, int value) {
            for(int i = 0; i < state.height; i++) {
                for(int j = 0; j < state.width; j++) {
                    if(state.getValue(i, j) == value) return new Point(j, i);

                }
            }
            return new n_puzzle.Point(-1, -1);
        }

        private State doAction(State state, Action action, List<Action> allowedActionList) {
            Point zPoint = getPosition(state, 0);
            if(zPoint.x < 0) throw new System.InvalidOperationException();
            State newState = new State(state);
            foreach(var allowedAct in allowedActionList) {
                if(action.id == allowedAct.id) {
                    switch(action.id) {
                        case 0: //MoveUp
                            newState.state[zPoint.y][zPoint.x] = newState.state[zPoint.y - 1][zPoint.x];
                            newState.state[zPoint.y - 1][zPoint.x] = 0;
                            break;
                        case 1: //MoveDown
                            newState.state[zPoint.y][zPoint.x] = newState.state[zPoint.y + 1][zPoint.x];
                            newState.state[zPoint.y + 1][zPoint.x] = 0;
                            break;
                        case 2: //MoveLeft
                            newState.state[zPoint.y][zPoint.x] = newState.state[zPoint.y][zPoint.x - 1];
                            newState.state[zPoint.y][zPoint.x - 1] = 0;
                            break;
                        case 3: //MoveRight
                            newState.state[zPoint.y][zPoint.x] = newState.state[zPoint.y][zPoint.x + 1];
                            newState.state[zPoint.y][zPoint.x + 1] = 0;
                            break;
                        default:
                            return null;
                    }
                }
            }
            return new State(newState);
        }
    }
}
