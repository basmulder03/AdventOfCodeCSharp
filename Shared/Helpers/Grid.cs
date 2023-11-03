namespace Shared.Helpers
{
    public class Grid<T>
    {
        private T[,] _grid { get; set; }

        public T[,] FullGrid => _grid;

        public int ColumnCount => _grid.GetLength(0);

        public int RowCount => _grid.GetLength(1);

        public Grid(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException($"Invalid dimensions: Width={width}, Height={height}");
            }
            _grid = new T[width, height];
        }

        public Grid(Coordinate<int> c1, Coordinate<int> c2) : this(Math.Abs(c2.X - c1.X) + 1, Math.Abs(c2.Y - c1.Y) + 1)
        { }

        public static Grid<T> From(T[,] gridArray)
        {
            var grid = new Grid<T>(gridArray.GetLength(0), gridArray.GetLength(1));
            grid.Map((value, x, y) => gridArray[x, y]);
            return grid;
        }

        public T[] GetColumn(int columnNumber)
        {
            return Enumerable.Range(0, _grid.GetLength(0))
                .Select(x => _grid[x, columnNumber])
                .ToArray();
        }

        public T[] GetRow(int rowNumber)
        {
            return Enumerable.Range(0, _grid.GetLength(1))
                .Select(y => _grid[rowNumber, y])
                .ToArray();
        }

        public T Get(int x, int y)
        {
            return _grid[x, y];
        }

        public T Get(Coordinate<int> c)
        {
            return Get(c.X, c.Y);
        }

        public void Set(int x, int y, T value)
        {
            if (x < ColumnCount && y < RowCount) _grid[x, y] = value;
        }

        public void Set(Coordinate<int> c, T value)
        {
            Set(c.X, c.Y, value);
        }

        public void SetAll(T value)
        {
            for (int i = 0; i < ColumnCount; i++)
            {
                for (int j = 0; j < RowCount; j++)
                {
                    Set(i, j, value);
                }
            }
        }

        public Grid<T> GetSubsection(int x1, int y1, int x2, int y2)
        {
            var smallestX = x1 < x2 ? x1 : x2;
            var biggestX = x1 > x2 ? x1 : x2;
            var smallestY = y1 < y2 ? y1 : y2;
            var biggestY = y1 > y2 ? y1 : y2;

            int sliceRowCount = biggestY - smallestY + 1;
            int sliceColCount = biggestX - smallestX + 1;

            var slicedGrid = new Grid<T>(sliceColCount, sliceRowCount);

            slicedGrid.Map((value, x, y) => Get(smallestX + x, smallestY + y));

            return slicedGrid;
        }

        public Grid<T> GetSubsection(Coordinate<int> c1, Coordinate<int> c2)
        {
            return GetSubsection(c1.X, c1.Y, c2.X, c2.Y);
        }

        public void SetSubsection(int startX, int startY, Grid<T> grid)
        {
            for (var i = 0; i < grid.ColumnCount; i++)
            {
                for (var j = 0; j < grid.RowCount; j++)
                {
                    Set(i + startX, j + startY, grid.Get(i, j));
                }
            }
        }

        public void SetSubsection(Coordinate<int> c, Grid<T> grid)
        {
            SetSubsection(c.X, c.Y, grid);
        }

        public void ForEach(Action<T, int, int> lambda)
        {
            for (var i = 0; i < ColumnCount; i++)
            {
                for (var j = 0; j < RowCount; j++)
                {
                    lambda(Get(i, j), i, j);
                }
            }
        }

        public void ForEach(Action<T> lambda)
        {
            for (var i = 0; i < ColumnCount; i++)
            {
                for (var j = 0; j < RowCount; j++)
                {
                    lambda(Get(i, j));
                }
            }
        }

        public void Map(Func<T, T> lambda)
        {
            for (var i = 0; i < ColumnCount; i++)
            {
                for (var j = 0; j < RowCount; j++)
                {
                    Set(i, j, lambda(Get(i, j)));
                }
            }
        }

        public void Map(Func<T, int, int, T> lambda)
        {
            for (var i = 0; i < ColumnCount; i++)
            {
                for (var j = 0; j < RowCount; j++)
                {
                    Set(i, j, lambda(Get(i, j), i, j));
                }
            }
        }

        public void Print()
        {
            Print((T value) => Console.Write($" {value} "));
        }

        public void Print(Action<T> valueAction)
        {
            Print(valueAction, () => Console.WriteLine("\n\n"));
        }

        public void Print(Action<T> valueAction, Action newLineAction)
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    valueAction(Get(j, i));
                }
                newLineAction();
            }
        }
    }
}
