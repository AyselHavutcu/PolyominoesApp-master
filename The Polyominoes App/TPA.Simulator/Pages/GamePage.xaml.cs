using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TPA.Simulator.Audio;
using TPA.Simulator.Physics;
using TPA.Simulator.Pages;
using System.Reflection;
using System.Linq;

namespace TPA.Simulator.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>

    public partial class GamePage : Page
    {
        public List<Rectangle> mainTetrominoMinoes = new List<Rectangle>();
        public Rectangle mainMinoA;
        public Rectangle mainMinoB;
        public Rectangle mainMinoC;
        public Rectangle mainMinoD;

        public List<int[,]> tetrominoes = new List<int[,]>();
        public int[,] shapeO_0 = new int[4, 4]
        {
            {0,0,0,0 },
            {1,1,0,0 },
            {1,1,0,0 },
            {0,0,0,0 },
        };
        public int[,] shapeI_0 = new int[4, 4]
        {
            {0,1,0,0 },
            {0,1,0,0 },
            {0,1,0,0 },
            {0,1,0,0 },
        };
        public int[,] shapeI_90 = new int[4, 4]
        {
            {0,0,0,0 },
            {1,1,1,1 },
            {0,0,0,0 },
            {0,0,0,0 },
         };
        public int[,] shapeS_0 = new int[4, 4]
        {
            {0,0,0,0 },
            {0,1,1,0 },
            {1,1,0,0 },
            {0,0,0,0 },
        };
        public int[,] shapeS_90 = new int[4, 4]
        {
            {1,0,0,0 },
            {1,1,0,0 },
            {0,1,0,0 },
            {0,0,0,0 },
        };
        public int[,] shapeZ_0 = new int[4, 4]
        {
            {0,0,0,0 },
            {1,1,0,0 },
            {0,1,1,0 },
            {0,0,0,0 },
         };
        public int[,] shapeZ_90 = new int[4, 4]
        {
            {0,0,1,0 },
            {0,1,1,0 },
            {0,1,0,0 },
            {0,0,0,0 },
        };
        public int[,] shapeJ_0 = new int[4, 4]
        {
            {0,1,0,0 },
            {0,1,0,0 },
            {1,1,0,0 },
            {0,0,0,0 },
         };
        public int[,] shapeJ_90 = new int[4, 4]
        {
            {1,0,0,0 },
            {1,1,1,0 },
            {0,0,0,0 },
            {0,0,0,0 },
         };
        public int[,] shapeJ_180 = new int[4, 4]
        {
            {0,1,1,0 },
            {0,1,0,0 },
            {0,1,0,0 },
            {0,0,0,0 },
         };
        public int[,] shapeJ_270 = new int[4, 4]
        {
            {0,0,0,0 },
            {1,1,1,0 },
            {0,0,1,0 },
            {0,0,0,0 },
         };
        public int[,] shapeL_0 = new int[4, 4]
        {
            {0,1,0,0 },
            {0,1,0,0 },
            {0,1,1,0 },
            {0,0,0,0 },
         };
        public int[,] shapeL_90 = new int[4, 4]
        {
            {0,0,0,0 },
            {1,1,1,0 },
            {1,0,0,0 },
            {0,0,0,0 },
         };
        public int[,] shapeL_180 = new int[4, 4]
        {
            {1,1,0,0 },
            {0,1,0,0 },
            {0,1,0,0 },
            {0,0,0,0 },
         };
        public int[,] shapeL_270 = new int[4, 4]
        {
            {0,0,1,0 },
            {1,1,1,0 },
            {0,0,0,0 },
            {0,0,0,0 },
         };
        public int[,] shapeT_0 = new int[4, 4]
        {
            {0,0,1,0 },
            {0,1,1,1 },
            {0,0,0,0 },
            {0,0,0,0 },
         };
        public int[,] shapeT_90 = new int[4, 4]
        {
            {0,0,1,0 },
            {0,0,1,1 },
            {0,0,1,0 },
            {0,0,0,0 },
         };
        public int[,] shapeT_180 = new int[4, 4]
        {
            {0,0,0,0 },
            {1,1,1,0 },
            {0,1,0,0 },
            {0,0,0,0 },
         };
        public int[,] shapeT_270 = new int[4, 4]
        {
            {0,1,0,0 },
            {1,1,0,0 },
            {0,1,0,0 },
            {0,0,0,0 },
         };

        public List<int[]> activeMinoes = new List<int[]>();
        public int[] shapeO_0_Down = { 2, 3 };
        public int[] shapeO_0_Left = { 0, 2 };
        public int[] shapeO_0_Right = { 1, 3 };
        public int[] shapeI_0_Down = { 3 };
        public int[] shapeI_0_Left = { 0, 1, 2, 3 };
        public int[] shapeI_0_Right = { 0, 1, 2, 3 };
        public int[] shapeI_90_Down = { 0, 1, 2, 3 };
        public int[] shapeI_90_Left = { 0 };
        public int[] shapeI_90_Right = { 3 };
        public int[] shapeS_0_Down = { 1, 2, 3 };
        public int[] shapeS_0_Left = { 0, 2 };
        public int[] shapeS_0_Right = { 1, 3 };
        public int[] shapeS_90_Down = { 1, 3 };
        public int[] shapeS_90_Left = { 0, 1, 3 };
        public int[] shapeS_90_Right = { 0, 2, 3 };
        public int[] shapeZ_0_Down = { 0, 2, 3 };
        public int[] shapeZ_0_Left = { 0, 2 };
        public int[] shapeZ_0_Right = { 1, 3 };
        public int[] shapeZ_90_Down = { 2, 3 };
        public int[] shapeZ_90_Left = { 0, 1, 3 };
        public int[] shapeZ_90_Right = { 0, 2, 3 };
        public int[] shapeJ_0_Down = { 2, 3 };
        public int[] shapeJ_0_Left = { 0, 1, 2 };
        public int[] shapeJ_0_Right = { 0, 1, 3 };
        public int[] shapeJ_90_Down = { 1, 2, 3 };
        public int[] shapeJ_90_Left = { 0, 1 };
        public int[] shapeJ_90_Right = { 0, 3 };
        public int[] shapeJ_180_Down = { 1, 3 };
        public int[] shapeJ_180_Left = { 0, 2, 3 };
        public int[] shapeJ_180_Right = { 1, 2, 3 };
        public int[] shapeJ_270_Down = { 0, 1, 3 };
        public int[] shapeJ_270_Left = { 0, 3 };
        public int[] shapeJ_270_Right = { 2, 3 };
        public int[] shapeL_0_Down = { 2, 3 };
        public int[] shapeL_0_Left = { 0, 1, 2 };
        public int[] shapeL_0_Right = { 0, 1, 3 };
        public int[] shapeL_90_Down = { 1, 2, 3 };
        public int[] shapeL_90_Left = { 0, 3 };
        public int[] shapeL_90_Right = { 2, 3 };
        public int[] shapeL_180_Down = { 0, 3 };
        public int[] shapeL_180_Left = { 0, 2, 3 };
        public int[] shapeL_180_Right = { 1, 2, 3 };
        public int[] shapeL_270_Down = { 1, 2, 3 };
        public int[] shapeL_270_Left = { 0, 1 };
        public int[] shapeL_270_Right = { 0, 3 };
        public int[] shapeT_0_Down = { 1, 2, 3 };
        public int[] shapeT_0_Left = { 0, 1 };
        public int[] shapeT_0_Right = { 0, 3 };
        public int[] shapeT_90_Down = { 2, 3 };
        public int[] shapeT_90_Left = { 0, 1, 3 };
        public int[] shapeT_90_Right = { 0, 2, 3 };
        public int[] shapeT_180_Down = { 0, 2, 3 };
        public int[] shapeT_180_Left = { 0, 3 };
        public int[] shapeT_180_Right = { 2, 3 };
        public int[] shapeT_270_Down = { 1, 3 };
        public int[] shapeT_270_Left = { 0, 1, 3 };
        public int[] shapeT_270_Right = { 0, 2, 3 };

        public string[] startingTetrominoesNames = { "shapeO", "shapeI", "shapeS", "shapeZ", "shapeJ", "shapeL", "shapeT" };

        public Color[] startingTetrominoesColors = { Colors.Yellow, Colors.Aqua, Colors.Lime, Colors.Red, Colors.Blue, Colors.Orange, Colors.Purple };

        public Dictionary<string, int> tetrominoShapeDictionary = new Dictionary<string, int>();
        public Dictionary<string, int> tetrominoRotationDictionary = new Dictionary<string, int>();
        public Dictionary<string, int> activeMinoesDictionary = new Dictionary<string, int>();

        public string currentTetrominoName;
        public int currentTetrominoNameNr;
        public string currentTetrominoDirectionName;
        public int[,] currentTetromino;
        public int currentGameScore;
        public int currentRotationDegrees;
        public Random random = new Random();

        private GameTime TetrisGameTime;
        private AudioPlayer TetrisAudio;
        private Collision CollisionCheck;

        private bool GameOver;

        public GamePage()
        {
            InitializeComponent();
            GameOver = false;
            TetrisAudio = new AudioPlayer();
            CollisionCheck = new Collision();

            LoadTetrominoes();
            LoadDictionaryDefinitions();
            LoadGridLineColor();
            AddNewTetromino();


            TetrisGameTime = new GameTime();
            TetrisGameTime.GameTimer.Tick += NewWindowLoop;

            Application.Current.MainWindow.KeyDown += KeyPresses;

        }


        public void KeyPresses(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    MoveTetromino(e.Key);
                    break;
                case Key.Left:
                    MoveTetromino(e.Key);
                    break;
                case Key.Right:
                    MoveTetromino(e.Key);
                    break;
                case Key.Up:
                    RotateTetromino();
                    break;
            }
        }

        // this loop is here until the project is further divided
        public void NewWindowLoop(Object sender, EventArgs e)
        {
            lblTimerContent.Content = TetrisGameTime.ElapsedTime();
            // Move tetris goes away when the business logic has been settled
            if (GameOver)
            {
                lblGameOverText.Visibility = Visibility.Visible;
            }
            else
            {
                MoveTetromino(Key.Down);
            }
        }

        public void LoadTetrominoes()
        {
            tetrominoes.Add(shapeO_0);
            tetrominoes.Add(shapeI_0);
            tetrominoes.Add(shapeI_90);
            tetrominoes.Add(shapeS_0);
            tetrominoes.Add(shapeS_90);
            tetrominoes.Add(shapeZ_0);
            tetrominoes.Add(shapeZ_90);
            tetrominoes.Add(shapeJ_0);
            tetrominoes.Add(shapeJ_90);
            tetrominoes.Add(shapeJ_180);
            tetrominoes.Add(shapeJ_270);
            tetrominoes.Add(shapeL_0);
            tetrominoes.Add(shapeL_90);
            tetrominoes.Add(shapeL_180);
            tetrominoes.Add(shapeL_270);
            tetrominoes.Add(shapeT_0);
            tetrominoes.Add(shapeT_90);
            tetrominoes.Add(shapeT_180);
            tetrominoes.Add(shapeT_270);

            activeMinoes.Add(shapeO_0_Down);
            activeMinoes.Add(shapeO_0_Left);
            activeMinoes.Add(shapeO_0_Right);
            activeMinoes.Add(shapeI_0_Down);
            activeMinoes.Add(shapeI_0_Left);
            activeMinoes.Add(shapeI_0_Right);
            activeMinoes.Add(shapeI_90_Down);
            activeMinoes.Add(shapeI_90_Left);
            activeMinoes.Add(shapeI_90_Right);
            activeMinoes.Add(shapeS_0_Down);
            activeMinoes.Add(shapeS_0_Left);
            activeMinoes.Add(shapeS_0_Right);
            activeMinoes.Add(shapeS_90_Down);
            activeMinoes.Add(shapeS_90_Left);
            activeMinoes.Add(shapeS_90_Right);
            activeMinoes.Add(shapeZ_0_Down);
            activeMinoes.Add(shapeZ_0_Left);
            activeMinoes.Add(shapeZ_0_Right);
            activeMinoes.Add(shapeZ_90_Down);
            activeMinoes.Add(shapeZ_90_Left);
            activeMinoes.Add(shapeZ_90_Right);
            activeMinoes.Add(shapeJ_0_Down);
            activeMinoes.Add(shapeJ_0_Left);
            activeMinoes.Add(shapeJ_0_Right);
            activeMinoes.Add(shapeJ_90_Down);
            activeMinoes.Add(shapeJ_90_Left);
            activeMinoes.Add(shapeJ_90_Right);
            activeMinoes.Add(shapeJ_180_Down);
            activeMinoes.Add(shapeJ_180_Left);
            activeMinoes.Add(shapeJ_180_Right);
            activeMinoes.Add(shapeJ_270_Down);
            activeMinoes.Add(shapeJ_270_Left);
            activeMinoes.Add(shapeJ_270_Right);
            activeMinoes.Add(shapeL_0_Down);
            activeMinoes.Add(shapeL_0_Left);
            activeMinoes.Add(shapeL_0_Right);
            activeMinoes.Add(shapeL_90_Down);
            activeMinoes.Add(shapeL_90_Left);
            activeMinoes.Add(shapeL_90_Right);
            activeMinoes.Add(shapeL_180_Down);
            activeMinoes.Add(shapeL_180_Left);
            activeMinoes.Add(shapeL_180_Right);
            activeMinoes.Add(shapeL_270_Down);
            activeMinoes.Add(shapeL_270_Left);
            activeMinoes.Add(shapeL_270_Right);
            activeMinoes.Add(shapeT_0_Down);
            activeMinoes.Add(shapeT_0_Left);
            activeMinoes.Add(shapeT_0_Right);
            activeMinoes.Add(shapeT_90_Down);
            activeMinoes.Add(shapeT_90_Left);
            activeMinoes.Add(shapeT_90_Right);
            activeMinoes.Add(shapeT_180_Down);
            activeMinoes.Add(shapeT_180_Left);
            activeMinoes.Add(shapeT_180_Right);
            activeMinoes.Add(shapeT_270_Down);
            activeMinoes.Add(shapeT_270_Left);
            activeMinoes.Add(shapeT_270_Right);
        }

        public void LoadDictionaryDefinitions()
        {
            tetrominoShapeDictionary.Add("shapeO", 0);
            tetrominoShapeDictionary.Add("shapeI", 1);
            tetrominoShapeDictionary.Add("shapeS", 2);
            tetrominoShapeDictionary.Add("shapeZ", 3);
            tetrominoShapeDictionary.Add("shapeJ", 4);
            tetrominoShapeDictionary.Add("shapeL", 5);
            tetrominoShapeDictionary.Add("shapeT", 6);

            tetrominoRotationDictionary.Add("shapeO_0", 0);
            tetrominoRotationDictionary.Add("shapeI_0", 1);
            tetrominoRotationDictionary.Add("shapeI_90", 2);
            tetrominoRotationDictionary.Add("shapeS_0", 3);
            tetrominoRotationDictionary.Add("shapeS_90", 4);
            tetrominoRotationDictionary.Add("shapeZ_0", 5);
            tetrominoRotationDictionary.Add("shapeZ_90", 6);
            tetrominoRotationDictionary.Add("shapeJ_0", 7);
            tetrominoRotationDictionary.Add("shapeJ_90", 8);
            tetrominoRotationDictionary.Add("shapeJ_180", 9);
            tetrominoRotationDictionary.Add("shapeJ_270", 10);
            tetrominoRotationDictionary.Add("shapeL_0", 11);
            tetrominoRotationDictionary.Add("shapeL_90", 12);
            tetrominoRotationDictionary.Add("shapeL_180", 13);
            tetrominoRotationDictionary.Add("shapeL_270", 14);
            tetrominoRotationDictionary.Add("shapeT_0", 15);
            tetrominoRotationDictionary.Add("shapeT_90", 16);
            tetrominoRotationDictionary.Add("shapeT_180", 17);
            tetrominoRotationDictionary.Add("shapeT_270", 18);

            activeMinoesDictionary.Add("shapeO_0_Down", 0);
            activeMinoesDictionary.Add("shapeO_0_Left", 1);
            activeMinoesDictionary.Add("shapeO_0_Right", 2);
            activeMinoesDictionary.Add("shapeI_0_Down", 3);
            activeMinoesDictionary.Add("shapeI_0_Left", 4);
            activeMinoesDictionary.Add("shapeI_0_Right", 5);
            activeMinoesDictionary.Add("shapeI_90_Down", 6);
            activeMinoesDictionary.Add("shapeI_90_Left", 7);
            activeMinoesDictionary.Add("shapeI_90_Right", 8);
            activeMinoesDictionary.Add("shapeS_0_Down", 9);
            activeMinoesDictionary.Add("shapeS_0_Left", 10);
            activeMinoesDictionary.Add("shapeS_0_Right", 11);
            activeMinoesDictionary.Add("shapeS_90_Down", 12);
            activeMinoesDictionary.Add("shapeS_90_Left", 13);
            activeMinoesDictionary.Add("shapeS_90_Right", 14);
            activeMinoesDictionary.Add("shapeZ_0_Down", 15);
            activeMinoesDictionary.Add("shapeZ_0_Left", 16);
            activeMinoesDictionary.Add("shapeZ_0_Right", 17);
            activeMinoesDictionary.Add("shapeZ_90_Down", 18);
            activeMinoesDictionary.Add("shapeZ_90_Left", 19);
            activeMinoesDictionary.Add("shapeZ_90_Right", 20);
            activeMinoesDictionary.Add("shapeJ_0_Down", 21);
            activeMinoesDictionary.Add("shapeJ_0_Left", 22);
            activeMinoesDictionary.Add("shapeJ_0_Right", 23);
            activeMinoesDictionary.Add("shapeJ_90_Down", 24);
            activeMinoesDictionary.Add("shapeJ_90_Left", 25);
            activeMinoesDictionary.Add("shapeJ_90_Right", 26);
            activeMinoesDictionary.Add("shapeJ_180_Down", 27);
            activeMinoesDictionary.Add("shapeJ_180_Left", 28);
            activeMinoesDictionary.Add("shapeJ_180_Right", 29);
            activeMinoesDictionary.Add("shapeJ_270_Down", 30);
            activeMinoesDictionary.Add("shapeJ_270_Left", 31);
            activeMinoesDictionary.Add("shapeJ_270_Right", 32);
            activeMinoesDictionary.Add("shapeL_0_Down", 33);
            activeMinoesDictionary.Add("shapeL_0_Left", 34);
            activeMinoesDictionary.Add("shapeL_0_Right", 35);
            activeMinoesDictionary.Add("shapeL_90_Down", 36);
            activeMinoesDictionary.Add("shapeL_90_Left", 37);
            activeMinoesDictionary.Add("shapeL_90_Right", 38);
            activeMinoesDictionary.Add("shapeL_180_Down", 39);
            activeMinoesDictionary.Add("shapeL_180_Left", 40);
            activeMinoesDictionary.Add("shapeL_180_Right", 41);
            activeMinoesDictionary.Add("shapeL_270_Down", 42);
            activeMinoesDictionary.Add("shapeL_270_Left", 43);
            activeMinoesDictionary.Add("shapeL_270_Right", 44);
            activeMinoesDictionary.Add("shapeT_0_Down", 45);
            activeMinoesDictionary.Add("shapeT_0_Left", 46);
            activeMinoesDictionary.Add("shapeT_0_Right", 47);
            activeMinoesDictionary.Add("shapeT_90_Down", 48);
            activeMinoesDictionary.Add("shapeT_90_Left", 49);
            activeMinoesDictionary.Add("shapeT_90_Right", 50);
            activeMinoesDictionary.Add("shapeT_180_Down", 51);
            activeMinoesDictionary.Add("shapeT_180_Left", 52);
            activeMinoesDictionary.Add("shapeT_180_Right", 53);
            activeMinoesDictionary.Add("shapeT_270_Down", 54);
            activeMinoesDictionary.Add("shapeT_270_Left", 55);
            activeMinoesDictionary.Add("shapeT_270_Right", 56);
        }

        public static void LoadGridLineColor()
        {
            //var T = Type.GetType("System.Windows.Controls.Grid+GridLinesRenderer, " +
            //                     "PresentationFramework, Version=4.0.0.0, " +
            //                     "Culture=neutral, PublicKeyToken=31bf3856ad364e35");

            //var GLR = Activator.CreateInstance(T);

            //GLR.GetType().GetField(
            //    "s_oddDashPen", BindingFlags.Static | BindingFlags.NonPublic).SetValue(
            //    GLR, new Pen(Brushes.Black, 0.5));

            //GLR.GetType().GetField(
            //    "s_evenDashPen", BindingFlags.Static | BindingFlags.NonPublic).SetValue(
            //    GLR, new Pen(Brushes.Black, 0.1));

            //mainGrid.ShowGridLines = true;
            //holdGrid.ShowGridLines = true;
            //nextGrid.ShowGridLines = true;
        }

        public void RotateTetromino()
        {
            int testRotationDegrees;

            if (activeMinoesDictionary.ContainsKey(
                TetrominoNameGenerator(
                    currentTetrominoNameNr,
                    currentRotationDegrees + 90,
                    currentTetrominoDirectionName)))
            {
                testRotationDegrees = currentRotationDegrees + 90;
            }
            else
            {
                testRotationDegrees = 0;
            }

            int startRow = Grid.GetRow(mainMinoB) - 1;
            int startColumn = Grid.GetColumn(mainMinoB) - 1;

            RemoveMinoesFromGrid(mainGrid);

            string testShapeAndDegreeName =
                startingTetrominoesNames[currentTetrominoNameNr]
                + "_"
                + testRotationDegrees;
            int[,] testTetrominoShape =
                tetrominoes[tetrominoRotationDictionary[testShapeAndDegreeName]];

            bool flag = false;
            bool rotationPossibility = true;

            for (int row = 0; row < 4 && flag == false; row++)
            {
                for (int column = 0; column < 4 && flag == false; column++)
                {
                    if (testTetrominoShape[row, column] == 1)
                    {
                        int totalRowCount = row + startRow;
                        int totalColumnCount = column + startColumn;

                        if (totalRowCount < 0 | totalRowCount > 19)
                        {
                            flag = true;
                            rotationPossibility = false;
                        }

                        if (totalColumnCount < 0 | totalColumnCount > 9)
                        {
                            flag = true;
                            rotationPossibility = false;
                        }

                        if (CollisionCheck.CheckElementInGridPosition(mainGrid, totalRowCount, totalColumnCount))
                        {
                            flag = true;
                            rotationPossibility = false;
                        }
                    }
                }

                if (flag)
                {
                    AddMinoesToGrid(mainGrid);
                }
            }

            if (rotationPossibility)
            {
                LoadNewMinoes();
                currentTetromino = testTetrominoShape;
                currentRotationDegrees = testRotationDegrees;

                int row = 0;
                int column = 0;
                bool continueCounting = false;

                foreach (Rectangle mino in mainTetrominoMinoes)
                {
                    bool flagTwo = false;
                    mino.Height = 25;
                    mino.Width = 25;
                    mino.StrokeThickness = 1.5;
                    mino.Stroke = Brushes.Black;
                    mino.Fill = new SolidColorBrush(startingTetrominoesColors[currentTetrominoNameNr]);

                    while (row < 4 && !flagTwo)
                    {
                        if (continueCounting)
                        {
                            continueCounting = false;
                        }
                        else
                        {
                            column = 0;
                        }

                        while (column < 4 && flagTwo == false)
                        {
                            if (currentTetromino[row, column] == 1)
                            {
                                Grid.SetRow(mino, row + startRow);
                                Grid.SetColumn(mino, column + startColumn);
                                mainGrid.Children.Add(mino);

                                continueCounting = true;
                                flagTwo = true;
                            }
                            column++;
                        }
                        if (!continueCounting) row++;
                    }
                }
            }
        }

        public string TetrominoNameGenerator(int shapeNr = 0,
            int rotation = 0,
            string direction = "Down")
        {
            string firstPart = startingTetrominoesNames[shapeNr];
            string secondPart = rotation.ToString();
            string thirdPart = direction;
            string result = firstPart + "_" + secondPart + "_" + thirdPart;
            return result;
        }

        public void LoadNewMinoes()
        {
            mainTetrominoMinoes.Clear();

            mainMinoA = new Rectangle();
            mainMinoB = new Rectangle();
            mainMinoC = new Rectangle();
            mainMinoD = new Rectangle();

            mainTetrominoMinoes.Add(mainMinoA);
            mainTetrominoMinoes.Add(mainMinoB);
            mainTetrominoMinoes.Add(mainMinoC);
            mainTetrominoMinoes.Add(mainMinoD);
        }

        public void RemoveMinoesFromGrid(Grid grid)
        {
            grid.Children.Remove(mainMinoA);
            grid.Children.Remove(mainMinoB);
            grid.Children.Remove(mainMinoC);
            grid.Children.Remove(mainMinoD);
        }

        public void AddMinoesToGrid(Grid grid)
        {
            grid.Children.Add(mainMinoA);
            grid.Children.Add(mainMinoB);
            grid.Children.Add(mainMinoC);
            grid.Children.Add(mainMinoD);
        }

        private void AddNewTetromino()
        {
            currentTetrominoNameNr = random.Next(0, startingTetrominoesNames.Length);
            currentRotationDegrees = 0;
            currentTetrominoDirectionName = "Down";

            string shapeNameAndDegrees = startingTetrominoesNames[currentTetrominoNameNr]
                                         + "_"
                                         + currentRotationDegrees.ToString();
            
            currentTetrominoName = TetrominoNameGenerator(
                currentTetrominoNameNr,
                currentRotationDegrees,
                currentTetrominoDirectionName);

            int[,] currentShape = tetrominoes[tetrominoRotationDictionary[shapeNameAndDegrees]];
            currentTetromino = currentShape;
            bool continueCounting = false;

            int column = 0;
            int row = 0;

            LoadNewMinoes();

            foreach (Rectangle mino in mainTetrominoMinoes)
            {
                bool flag = false;

                mino.Height = 25;
                mino.Width = 25;
                mino.StrokeThickness = 1.5;
                mino.Stroke = Brushes.Black;
                mino.Fill = new SolidColorBrush(startingTetrominoesColors[currentTetrominoNameNr]);

                while (row < 4 && !flag)
                {
                    if (continueCounting)
                    {
                        continueCounting = false;
                    }
                    else
                    {
                        column = 0;
                    }

                    while (column < 4 && !flag)
                    {
                        if (currentTetromino[row, column] == 1)
                        {
                            Grid.SetRow(mino, row + 1);
                            Grid.SetColumn(mino, column + 3);
                            GameOver = CollisionCheck.CheckElementInGridPosition(mainGrid, row + 1, column + 3);
                            mainGrid.Children.Add(mino);

                            continueCounting = true;
                            flag = true;
                        }
                        column++;
                    }
                    if (!continueCounting) row++;
                }
            }
        }

        public void SetDirectionName(Key direction)
        {
            switch (direction)
            {
                case Key.Down:
                    currentTetrominoDirectionName = "Down";
                    break;
                case Key.Left:
                    currentTetrominoDirectionName = "Left";
                    break;
                case Key.Right:
                    currentTetrominoDirectionName = "Right";
                    break;
            }
        }

        public void MoveTetromino(Key direction)
        {
            bool collision = false;

            SetDirectionName(direction);

            currentTetrominoName = TetrominoNameGenerator(
                currentTetrominoNameNr,
                currentRotationDegrees,
                currentTetrominoDirectionName);

            foreach (int mino in activeMinoes[activeMinoesDictionary[currentTetrominoName]])
            {
                if (CollisionCheck.CheckElementImpactInDirection(direction, mainGrid, mainTetrominoMinoes[mino])) collision = true;
                if (CollisionCheck.CheckBorderCollision(direction, mainTetrominoMinoes[mino])) collision = true;
            }

            if (!collision)
            {
                foreach (Rectangle mino in mainTetrominoMinoes)
                {
                    switch (direction)
                    {
                        case Key.Left:
                            mainGrid.Children.Remove(mino);
                            Grid.SetColumn(mino, Grid.GetColumn(mino) - 1);
                            mainGrid.Children.Add(mino);
                            break;
                        case Key.Right:
                            mainGrid.Children.Remove(mino);
                            Grid.SetColumn(mino, Grid.GetColumn(mino) + 1);
                            mainGrid.Children.Add(mino);
                            break;
                        case Key.Down:
                            mainGrid.Children.Remove(mino);
                            Grid.SetRow(mino, Grid.GetRow(mino) + 1);
                            mainGrid.Children.Add(mino);
                            break;
                    };
                }
            }
            else if (direction == Key.Down && !GameOver)
            {

                RemoveFullRowsFromGrid(mainGrid);
                AddNewTetromino();
            }
        }

        public void RemoveFullRowsFromGrid(Grid grid)
        {
            List<int> fullRows = CollisionCheck.ReturnFullRowNumbers(grid);
            bool isEmpty = !fullRows.Any();

            if (!isEmpty)
            {
                foreach (int fullRowNumber in fullRows)
                {
                    CollisionCheck.DeleteRowElementsFromGrid(grid, fullRowNumber);
                    CollisionCheck.LowerElementsAboveRowInGrid(grid, fullRowNumber);
                    currentGameScore += 10;
                    lblScoreContent.Content = currentGameScore;
                }
                TetrisAudio.PlayDeleteLine();
            }
            else
            {
                TetrisAudio.PlayCollisionSound();
            }
        }

        private void ButtonClickLeftArrow(object sender, RoutedEventArgs e)
        {
            MoveTetromino(Key.Left);
        }

        private void ButtonClickDownArrow(object sender, RoutedEventArgs e)
        {
            MoveTetromino(Key.Down);
        }

        private void ButtonClickRightArrow(object sender, RoutedEventArgs e)
        {
            MoveTetromino(Key.Right);
        }

        private void ButtonClickUpArrow(object sender, RoutedEventArgs e)
        {
            RotateTetromino();
        }

        private void ButtonClickMuteTheme(object sender, RoutedEventArgs e)
        {
            TetrisAudio.StopMainThemeLoop();
        }
        private void ButtonClickUnMuteTheme(object sender, RoutedEventArgs e)
        {
            TetrisAudio.PlayMainThemeInLoop();
        }

        private void ButtonClickEndGame(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
