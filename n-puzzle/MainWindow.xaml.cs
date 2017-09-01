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
            nPuzzle game = new nPuzzle();
            Node estado = game.nextStep();

            int width = 3;
            int height = 3;

            grid.Background = new SolidColorBrush(Colors.LightSteelBlue);
            for(int i = 0; i < width; i++) {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for(int i = 0; i < height; i++) {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            
            List<Label> listLabel = new List<Label>();
            for(int i =0; i<height; i++) {
                for(int j=0; j<width; j++) {

                    Label label = new Label();
                    label.Content = estado.state.state[i][j];
                    label.Width = 100;
                    label.Height = 100;
                    label.Foreground = new SolidColorBrush(Colors.Black);
                
                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, j);
                
                    grid.Children.Add(label);
                    listLabel.Add(label);
                }
            }


        }

        
    }
}
