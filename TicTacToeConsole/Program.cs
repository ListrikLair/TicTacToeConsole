namespace TicTacToeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameEnd = false;
            var gameState = new GameState();
            Console.CursorVisible = false;

            while (!gameEnd)
            {
                Console.Clear();
                gameState.DrawGrid();
                gameState.DrawInstructions();
                gameState.SetMarkOnPosition();
                if (gameState.CheckIfWin()) gameEnd = true;
            }
        }
    }
}