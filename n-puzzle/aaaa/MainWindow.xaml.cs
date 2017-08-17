using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace n_puzzle {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>

    enum Direction : short { up, down, left, right }
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();

            List<Action> actionList = new List<Action>();
            actionList.Add(new Action("goUp", (short)Direction.up));
            actionList.Add(new Action("goDown", (short)Direction.down));
            actionList.Add(new Action("goLeft", (short)Direction.left));
            actionList.Add(new Action("goRight", (short)Direction.right));

            State initState = new State(3, 3, actionList);
            State goalState = new State(3, 3, actionList);
            goalState.setGoal();

            Func<State, List<Action>> convertMethod = actionAllowed;

            State newState = initState.doAction(actionList.ElementAt(0));
            int b = 3;

        }

        private static List<Action> actionAllowed(State state) {
            return null;
        }

    }
}
