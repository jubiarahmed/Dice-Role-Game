var random = new Random();
var dice = new Dice(random);
var guessingGame = new GuessingGame(dice);

GameResult gameResult = guessingGame.Play();

Console.ReadKey();

class GuessingGame
{
    private readonly Dice _dice;
    private const int InitialTries = 3;

    public GuessingGame(Dice dice)
    {
        _dice = dice;
    }
    public GameResult Play()
    {
        var diceRollResult = _dice.Roll();
        Console.WriteLine($"Dice rolled. Guess what number it shows in {InitialTries} tries.");

        var triesLeft = InitialTries;
        while (triesLeft > 0)
        {
            var guess = ConsoleReader.ReadInteger("Enter a number (1-6): ");
            if (guess == diceRollResult)
            {
                return GameResult.Win;
            }
            Console.WriteLine("Wrong number");
            --triesLeft;
        }
        return GameResult.Loss;
    }
}

public enum GameResult
{
    Win,
    Loss
}
public static class ConsoleReader
{

    public static int ReadInteger(string message)
    {
        int result;
        do
        {
            Console.WriteLine(message);
        }
        while (!int.TryParse(message, out result));
        return result;
    }
}

public class Dice
{
    private readonly Random _random;
    private const int SidesCount = 6;

    public Dice(Random random)
    {
        _random = random;
    }
    public int Roll() => _random.Next(1, SidesCount + 1);
   
    public void Descrive() =>
        Console.WriteLine($"This is a Dice With {SidesCount} 6 sides.");
}