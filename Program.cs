internal class Program
{
    public static int Player = 1;
    public static int[,] Field = new int[6, 7] { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };
    public static int Player_win1 = 0;
    public static int Player_win2 = 0;
    private static void Main(string[] args)
    {
        int ChosenLine;
        while (true)
        {
            Console.Clear();
            ShowField();
            try
            {
                Console.Write("Spalte: ");
                ChosenLine = Convert.ToInt32(Console.ReadLine());
                ChosenLine--; // -- because line 1 is actually line 0...
                if (ChosenLine >= 0 && ChosenLine <= 6)
                {
                    if (Field[0, ChosenLine] == 0) // Chack if you can place
                    {
                        /*
                        Makes the gravity, whitch takes the Plates down
                        */
                        if (Field[1, ChosenLine] == 0)
                        {
                            if (Field[2, ChosenLine] == 0)
                            {
                                if (Field[3, ChosenLine] == 0)
                                {
                                    if (Field[4, ChosenLine] == 0)
                                    {
                                        if (Field[5, ChosenLine] == 0)
                                        {
                                            Field[5, ChosenLine] = SwitchPlayerAndFiedback();
                                        }
                                        else
                                        {
                                            Field[4, ChosenLine] = SwitchPlayerAndFiedback();
                                        }
                                    }
                                    else
                                    {
                                        Field[3, ChosenLine] = SwitchPlayerAndFiedback();
                                    }
                                }
                                else
                                {
                                    Field[2, ChosenLine] = SwitchPlayerAndFiedback();
                                }
                            }
                            else
                            {
                                Field[1, ChosenLine] = SwitchPlayerAndFiedback();
                            }
                        }
                        else
                        {
                            Field[0, ChosenLine] = SwitchPlayerAndFiedback();
                        }
                    }
                }
            }
            catch(Exception ex)
            { }
            TryWin(Player);
        }
    }
    private static void TryWin(int player)
    {
        bool Winn = false;
        // Horizontal
        for (int hight = 0; hight < 6; hight++)
        {
            if (Field[hight, 0] == player && Field[hight, 1] == player && Field[hight, 2] == player && Field[hight, 3] == player)
            {
                Winn = true;
            }
            else if (Field[hight, 1] == player && Field[hight, 2] == player && Field[hight, 3] == player && Field[hight, 4] == player)
            {
                Winn = true;
            }
            else if (Field[hight, 2] == player && Field[hight, 3] == player && Field[hight, 4] == player && Field[hight, 5] == player)
            {
                Winn = true;
            }
            else if (Field[hight, 3] == player && Field[hight, 4] == player && Field[hight, 5] == player && Field[hight, 6] == player)
            {
                Winn = true;
            }
        }
        // Vertical
        for (int lenght = 0; lenght < 5; lenght++)
        {
            if (Field[0, lenght] == player && Field[1, lenght] == player && Field[2, lenght] == player && Field[3, lenght] == player)
            {
                Winn = true;
            }
            else if (Field[1, lenght] == player && Field[2, lenght] == player && Field[3, lenght] == player && Field[4, lenght] == player)
            {
                Winn = true;
            }
            else if (Field[2, lenght] == player && Field[3, lenght] == player && Field[4, lenght] == player && Field[5, lenght] == player)
            {
                Winn = true;
            }
        }
        // Diagonal Left to Right
        for (int a = 0; a < 3; a++)
        {
            for (int b = 0; b < 4; b++)
            {
                if (Field[a, b] == player && Field[a + 1, b + 1] == player && Field[a + 2, b + 2] == player && Field[a + 3, b + 3] == player)
                {
                    Winn = true;
                }
            }
        }
        // Diagonal Right to Left
        for (int a = 0; a < 3; a++)
        {
            for (int b = 6; b > 2; b--)
            {
                if (Field[a, b] == player && Field[a + 1, b - 1] == player && Field[a + 2, b - 2] == player && Field[a + 3, b - 3] == player)
                {
                    Winn = true;
                }
            }
        }
        // Count the win
        if (Winn)
        {
            if (player == 1)
            {
                Player_win1++;
            }
            else if (player == 2)
            {
                Player_win2++;
            }
            Console.WriteLine("Spieler {0} Gewinnt", player);
            Winn = false;
            Console.ReadLine();
            RenewField();
        }
    }

    private static int SwitchPlayerAndFiedback()
    {
        if (Player == 1)
        {
            Player = 2;
            return 1;
        }
        else
        {
            Player = 1;
            return 2;
        }
    }
    private static void RenewField()
    {
         Field = new int[6, 7] { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };
    }
    private static void ShowField()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Console.Write(Field[i, j]);
            }
            Console.WriteLine();
        }
    }
}