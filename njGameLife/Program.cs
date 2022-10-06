// See https://aka.ms/new-console-template for more information

public class Game
{
    private char[,] life;
    private const int LifeRowSize = 30;
    private const int LifeColSize = 30;
    private Random random;
    public Game()
    {
        life = new char[LifeRowSize,LifeColSize];
        random = new Random();
        this.GenerateEmptyLife(life, true);
    }

    private void GenerateEmptyLife(char[,] newlife, bool randomFill = false)
    {
        for (int i = 0; i < LifeRowSize; i++)
            for (int j = 0; j < LifeColSize; j++)
                if (randomFill)
                    newlife[i, j] = random.NextDouble() < 0.5? '+' : ' ';
                else
                    newlife[i, j] = ' ';
    }
    public void NextLife()
    {
        var newlife = new char[LifeRowSize, LifeColSize];
        this.GenerateEmptyLife(newlife, false);

        for (int i = 0; i < LifeRowSize; i++)
            for (int j = 0; j < LifeColSize; j++)
            {
                int numberLives = 0;

                for (int cell_i = i - 1; cell_i <= i + 1; cell_i++)
                {
                    for (int cell_j = j - 1; cell_j <= j + 1; cell_j++)
                    {
                        int i2 = (cell_i + LifeRowSize-1) % (LifeRowSize-1);
                        int j2 = (cell_j + LifeColSize-1) % (LifeColSize-1);
                        if (life[i2, j2] != ' ') numberLives++;
                    }
                }
                   bool isLive = life[i, j] != ' ';
             if (isLive) numberLives--;
                bool nextLive = (isLive && numberLives == 2) || (numberLives == 3);
                newlife[i, j] = nextLive ? '+' : ' ';
            }

        for (int i = 0; i < LifeRowSize; i++)
            for (int j = 0; j < LifeColSize; j++)
            {
                life[i, j] = newlife[i, j];
            }
    }
    public void ShowLife()
    {
        Console.Clear();
        for(int i=0; i < LifeRowSize; i++)
        {
            for(int j=0; j < LifeColSize; j++) 
                Console.Write(life[i, j]);

            Console.WriteLine();
        }
    }
    public void StartGame()
    {
        bool running = true;
        while (running)
        {
            this.ShowLife();
            Thread.Sleep(500);
            this.NextLife();
        }
    }
    public void Pause() { Console.ReadKey(); }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Game game = new Game();
        game.ShowLife();
        game.StartGame();
        game.Pause();

    }

    }


