using DiceRollGame_Assignment.Game;

var guessingGame = new GuessingGame(new Dice(new Random() ));

GameResult PalyResult = guessingGame.Play();

GuessingGame.PrintResult(PalyResult);

//string message = dice.Play() == GameResult.Victory ? "You Win!" : "You Lose";
//Console.WriteLine(message);

//if (PalyResult == GameResult.Victory)
//{
//    Console.WriteLine("You Win!");
//} else
//{
//    Console.WriteLine("You Lose");
//}

Console.ReadKey();


