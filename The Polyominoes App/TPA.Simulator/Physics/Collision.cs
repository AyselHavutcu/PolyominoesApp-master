using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TPA.Simulator.Physics
{
    class Collision
    {
        public bool CheckElementInGridPosition(Grid grid, int row, int column)
        {
            foreach (UIElement child in grid.Children)
            {
                if (Grid.GetRow(child) != row) continue;
                if (Grid.GetColumn(child) == column) return true;
            }

            return false;
        }

        public void LowerElementsAboveRowInGrid(Grid grid, int row)
        {
            UIElement child;

            for (int i = grid.Children.Count - 1; i >= 0; i--)
            {
                if (Grid.GetRow(child = grid.Children[i]) < row)
                {
                    Grid.SetRow(child, Grid.GetRow(child) + 1);
                }
            }
        }

        public void DeleteRowElementsFromGrid(Grid grid, int row)
        {
            UIElement child;

            for (int i = grid.Children.Count - 1; i >= 0; i--)
            {
                if (Grid.GetRow(child = grid.Children[i]) == row)
                {
                    grid.Children.Remove(child);
                }
            }
        }

        public List<int> ReturnFullRowNumbers(Grid grid)
        {
            List<int> result = new List<int>();

            for (int row = 0; row < 20; row++)
            {
                int blockCount = 0;

                for (int column = 0; column < 10; column++)
                {
                    if (CheckElementInGridPosition(grid, row, column))
                    {
                        blockCount++;
                    }

                    if (blockCount == 10)
                    {
                        result.Add(row);
                    }
                }
            }

            return result;
        }

        public bool CheckElementImpactInDirection(Key direction, Grid grid, UIElement currentBlock)
        {
            int row = Grid.GetRow(currentBlock);
            int column = Grid.GetColumn(currentBlock);

            switch (direction)
            {
                case Key.Down:
                    if (CheckElementInGridPosition(grid, row + 1, column)) return true;
                    break;
                case Key.Left:
                    if (CheckElementInGridPosition(grid, row, column - 1)) return true;
                    break;
                case Key.Right:
                    if (CheckElementInGridPosition(grid, row, column + 1)) return true;
                    break;
            }
            return false;
        }

        public bool CheckBorderCollision(Key direction, UIElement currentBlock)
        {
            int row = Grid.GetRow(currentBlock);
            int column = Grid.GetColumn(currentBlock);

            switch (direction)
            {
                case Key.Down:
                    if (row == 19) return true;
                    break;
                case Key.Left:
                    if (column == 0) return true;
                    break;
                case Key.Right:
                    if (column == 9) return true;
                    break;
            }
            return false;
        }

    }
}
