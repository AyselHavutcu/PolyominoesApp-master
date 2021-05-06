using System.Windows;
using TPA.Simulator.Pages;

namespace TPA.Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Use 'http://tetris.wikia.com/wiki/Tetris_Wiki' for Tetris terminology
        // 
        // Quick Ref:
        // Tetris means you cleared 4 lines at once.
        // Tetromino(plural: Tetrominoes) is a single shape of 4 equal squares
        // connected to each other.A single square is called a Mino (plural: Minoes).
        // These are mathematical terms.Shapes of two are Dominoes,
        // three Trominoes, etc etc.

        // TODO: Remove all shapes and minoes to a object oriented class based system
        // TODO: Breakdown the MoveTetromino
        // TODO: Breakdown the RotateTetromino
        // TODO: Breakdown the AddNewTetromino
        // TODO: Make Tetrominoes appear first in the NEXT screen.Then the main grid.
        // TODO: Add ability to HOLD Tetromino shapes.
        // TODO: Add level system (increase speed of game based on time / points)
        // TODO: Add game over mechanics 
        // TODO: Add highscore system to the game.

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new MenuPage());
        }
    }
}
