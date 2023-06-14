using System;

class TicTacToe
{
    static char[,] tabla; //inicializamos la tabla
    static char jugador = 'X';

    static void Main()
    {
        Console.Write("Enter the number of rows: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the number of columns: ");
        int cols = Convert.ToInt32(Console.ReadLine());

        Initializetabla(rows, cols);
        bool gameover = false;

        while (!gameover)
        {
            Console.Clear();
            Drawtabla();

            Console.WriteLine("Player {0}'s turn.", jugador);
            Console.Write("Enter the row number (0-{0}): ", rows - 1);
            int row = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the column number (0-{0}): ", cols - 1);
            int col = Convert.ToInt32(Console.ReadLine());

            //Comprobamos si los movimientos son validos
            if (IsValidMove(row, col))
            {
                MakeMove(row, col);

                if (CheckWin())
                {
                    Console.Clear();
                    Drawtabla();
                    Console.WriteLine("Player {0} wins!", jugador);
                    gameover = true;
                }
                else if (IstablaFull())
                {
                    Console.Clear();
                    Drawtabla();
                    Console.WriteLine("It's a draw!");
                    gameover = true;
                }
                else
                {
                    jugador = (jugador == 'X') ? 'O' : 'X';
                }
            }
            else
            {
                Console.WriteLine("Invalid move! Try again.");
            }
        }

        Console.ReadLine();
    }

    //Inicializamos la tabla
    static void Initializetabla(int rows, int cols)
    {
        tabla = new char[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                tabla[row, col] = ' ';
            }
        }
    }

    //Dibujar la tabla
    static void Drawtabla()
    {
        int rows = tabla.GetLength(0);
        int cols = tabla.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(tabla[row, col]);
                if (col < cols - 1)
                {
                    Console.Write(" | ");
                }
            }
            Console.WriteLine();

            if (row < rows - 1)
            {
                Console.WriteLine(new string('-', cols * 4 - 1));
            }
        }
    }

    //Funcion para comprobar si el movimiento es valido
    static bool IsValidMove(int row, int col)
    {
        int rows = tabla.GetLength(0);
        int cols = tabla.GetLength(1);

        if (row < 0 || row >= rows || col < 0 || col >= cols)
        {
            return false;
        }

        if (tabla[row, col] != ' ')
        {
            return false;
        }

        return true;
    }

    //Funcion para hacer el movimiento
    static void MakeMove(int row, int col)
    {
        tabla[row, col] = jugador;
    }

    //Funcion para comprobar quien gana
    static bool CheckWin()
    {
        int rows = tabla.GetLength(0);
        int cols = tabla.GetLength(1);

        // Check rows
        for (int row = 0; row < rows; row++)
        {
            if (tabla[row, 0] == jugador)
            {
                bool win = true;
                for (int col = 1; col < cols; col++)
                {
                    if (tabla[row, col] != jugador)
                    {
                        win = false;
                        break;
                    }
                }

                if (win)
                {
                    return true;
                }
            }
        }

        // Check columns
        for (int col = 0; col < cols; col++)
        {
            if (tabla[0, col] == jugador)
            {
                bool win = true;
                for (int row = 1; row < rows; row++)
                {
                    if (tabla[row, col] != jugador)
                    {
                        win = false;
                        break;
                    }
                }

                if (win)
                {
                    return true;
                }
            }
        }

        // Check diagonals
        if (rows == cols)
        {
            // Main diagonal
            if (tabla[0, 0] == jugador)
            {
                bool win = true;
                for (int i = 1; i < rows; i++)
                {
                    if (tabla[i, i] != jugador)
                    {
                        win = false;
                        break;
                    }
                }

                if (win)
                {
                    return true;
                }
            }

            // Anti-diagonal
            if (tabla[0, cols - 1] == jugador)
            {
                bool win = true;
                for (int i = 1; i < rows; i++)
                {
                    if (tabla[i, cols - 1 - i] != jugador)
                    {
                        win = false;
                        break;
                    }
                }

                if (win)
                {
                    return true;
                }
            }
        }

        return false;
    }

    //Cuando la tabla esta llena
    static bool IstablaFull()
    {
        int rows = tabla.GetLength(0);
        int cols = tabla.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (tabla[row, col] == ' ')
                {
                    return false;
                }
            }
        }

        return true;
    }
}
