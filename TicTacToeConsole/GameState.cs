using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsole
{
    internal class GameState
    {
        int _currentPlayer = 1;
        char[] _gameMarkers = {'1', '2', '3', '4', '5', '6', '7', '8', '9'};

        public GameState()
        {
            
        }

        internal void DrawInstructions()
        {
            Console.SetCursorPosition(0,7);
            Console.WriteLine("Player 1 = X");
            Console.WriteLine("Player 2 = O");
            Console.WriteLine("Press the number coresponding to the cell you want to fill");
            Console.WriteLine($"Player {_currentPlayer}'s turn");
            // Console.WriteLine("1 | 2 | 3");
            // Console.WriteLine("4 | 5 | 6");
            // Console.WriteLine("7 | 8 | 9");
        }

        internal void DrawGrid()
        {
            Console.WriteLine($" {_gameMarkers[0]} | {_gameMarkers[1]} | {_gameMarkers[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {_gameMarkers[3]} | {_gameMarkers[4]} | {_gameMarkers[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {_gameMarkers[6]} | {_gameMarkers[7]} | {_gameMarkers[8]} ");
        }

        public void DrawInCell(int player)
        {
            if (_currentPlayer == 1)
            {
                Console.WriteLine('X');
            }
            else
            {
                Console.WriteLine('O');
            }
        }

        public int GetNextPlayer()
        {
            return _currentPlayer == 1 ? 2 : 1;
        }

        public void SetMarkOnPosition()
        {
            var playerMarker = _currentPlayer == 1 ? 'X' : 'O';
            var reply = Console.ReadKey(true);
            var intReply = char.IsDigit(reply.KeyChar) ? int.Parse(reply.KeyChar.ToString()) : 0;
            if (intReply is < 1 or > 9) return;
            if (_gameMarkers[intReply - 1] is 'X' or 'O')
            {
                Console.WriteLine($"Cell {intReply} already filled, choose another one");
                Thread.Sleep(1500);
                return;
            }
            switch (intReply)
            {
                case 1:
                    _gameMarkers[0] = playerMarker;
                    break;
                case 2:
                    _gameMarkers[1] = playerMarker;
                    break;
                case 3:
                    _gameMarkers[2] = playerMarker;
                    break;
                case 4:
                    _gameMarkers[3] = playerMarker;
                    break;
                case 5:
                    _gameMarkers[4] = playerMarker;
                    break;
                case 6:
                    _gameMarkers[5] = playerMarker;
                    break;
                case 7:
                    _gameMarkers[6] = playerMarker;
                    break;
                case 8:
                    _gameMarkers[7] = playerMarker;
                    break;
                case 9:
                    _gameMarkers[8] = playerMarker;
                    break;
                default:
                    return;
            }
        }

        public bool CheckIfWin()
        {
            if (CheckIfWinningCombination(_gameMarkers, 0, 1, 2) ||
                CheckIfWinningCombination(_gameMarkers, 3, 4, 5) ||
                CheckIfWinningCombination(_gameMarkers, 6, 7, 8) ||
                CheckIfWinningCombination(_gameMarkers, 0, 3, 6) ||
                CheckIfWinningCombination(_gameMarkers, 1, 4, 7) ||
                CheckIfWinningCombination(_gameMarkers, 2, 5, 8) ||
                CheckIfWinningCombination(_gameMarkers, 0, 4, 8) ||
                CheckIfWinningCombination(_gameMarkers, 2, 4, 6)
                )
            {
                EndScreen(_currentPlayer);
                return true;
            }

            if (!CheckIfDraw())
            {
                _currentPlayer = GetNextPlayer();
                return false;
            }
            EndScreen();
            return true;

        }

        private bool CheckIfWinningCombination(char[] testGameMarkers, int pos1, int pos2, int pos3)
        {
            return testGameMarkers[pos1].Equals(testGameMarkers[pos2]) &&
                   testGameMarkers[pos2].Equals(testGameMarkers[pos3]);
        }

        public bool CheckIfDraw()
        {
            return _gameMarkers[0] != '1' &&
                   _gameMarkers[1] != '2' &&
                   _gameMarkers[2] != '3' &&
                   _gameMarkers[3] != '4' &&
                   _gameMarkers[4] != '5' &&
                   _gameMarkers[5] != '6' &&
                   _gameMarkers[6] != '7' &&
                   _gameMarkers[7] != '8' &&
                   _gameMarkers[8] != '9';
        }

        private void EndScreen(int winningPlayer)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            string s = $"Player {winningPlayer} Wins!";
            Console.SetCursorPosition(Console.WindowWidth/2-s.Length/2, Console.WindowHeight/2);
            Console.WriteLine(s);
        }

        private void EndScreen()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            string s = "It's a draw!";
            Console.SetCursorPosition(Console.WindowWidth/2-s.Length/2, Console.WindowHeight/2);
            Console.WriteLine(s);
        }
    }
}
