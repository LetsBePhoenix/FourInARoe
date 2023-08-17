internal class Program
{
    public static int Player = 1;
    public static int[,] Field = new int[6, 7] { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };
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