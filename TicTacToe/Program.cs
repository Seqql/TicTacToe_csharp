using System;
using System.Xml.Serialization;

namespace TicTacToe
{
    class Program
    {

        static bool?[] tictactoe = new bool?[9]; //True equals X, False equals O, null equals unassigned
        static int currPos = 0;

        static bool currPlayer = false; //True equals X, false equals O

        static bool win = false;

        static void Main(string[] args)
        {
            do
            {
                draw();
                var key = Console.ReadKey();

                determinePos(key.Key);
                setMark(key.Key);
            } while (!win);

            draw();

            Console.ReadLine();
        }


        static private void draw()
        {
            string draw = "";

            for (int i = 1; i <= tictactoe.Length; i++)
            {
                draw += "." + getMark(tictactoe[i - 1], i - 1) + ".|";
                if (i % 3 == 0)
                {
                    draw = draw.Remove(draw.Length - 1, 1);

                    if (i < tictactoe.Length)
                    {
                        draw += Environment.NewLine;
                        draw += "-----------";
                        draw += Environment.NewLine;

                    }
                }
            }

            draw += Environment.NewLine;
            draw += Environment.NewLine;
            if (win)
                draw += "Player " + getMark() + " WINS!!!";
            else
                draw += "Player " + getMark() + "'s turn! (Use arrows to move and space to set your mark)";

            Console.Clear();
            Console.Write(draw);
        }

        static private bool check4win()
        {
            //Horizontal
            for (int i = 0; i < tictactoe.Length / 3; i += 3)
            {
                if (tictactoe[i] == currPlayer)
                    if (tictactoe[i + 1] == currPlayer)
                        if (tictactoe[i + 2] == currPlayer) return true;
            }

            //Vertical
            for (int i = 0; i < 3; i++)
            {
                if (tictactoe[i] == currPlayer)
                    if (tictactoe[i + 3] == currPlayer)
                        if (tictactoe[i + 6] == currPlayer) return true;
            }

            //Diagonal (l to r)
            if (tictactoe[0] == currPlayer)
                if (tictactoe[4] == currPlayer)
                    if (tictactoe[8] == currPlayer) return true;

            //Diagonal (r to l)
            if (tictactoe[2] == currPlayer)
                if (tictactoe[4] == currPlayer)
                    if (tictactoe[6] == currPlayer) return true;

            return false;
        }

        static private void determinePos(ConsoleKey pressed)
        {
            if (ConsoleKey.RightArrow == pressed)
            {
                if (currPos % 3 == 1)
                {
                    if (tictactoe[currPos + 1] == null)
                    {
                        currPos++;
                    }
                }
                else if (currPos % 3 == 0)
                {
                    if (tictactoe[currPos + 1] == null)
                    {
                        currPos++;
                    }
                    else if (tictactoe[currPos + 2] == null)
                    {
                        currPos += 2;
                    }
                }
            }
            if (ConsoleKey.LeftArrow == pressed)
            {
                if (currPos % 3 == 1)
                {
                    if (tictactoe[currPos + 1] == null)
                    {
                        currPos--;
                    }
                }
                else if (currPos % 3 == 2)
                {
                    if (tictactoe[currPos - 1] == null)
                    {
                        currPos--;
                    }
                    else if (tictactoe[currPos - 2] == null)
                    {
                        currPos -= 2;
                    }
                }
            }
            if (ConsoleKey.UpArrow == pressed)
            {
                if (currPos / 3 == 1)
                {
                    if (tictactoe[currPos - 3] == null)
                    {
                        currPos -= 3;
                    }
                }
                else if (currPos / 3 == 2)
                {
                    if (tictactoe[currPos - 3] == null)
                    {
                        currPos -= 3;
                    }
                    else if (tictactoe[currPos - 6] == null)
                    {
                        currPos -= 6;
                    }
                }
            }
            if (ConsoleKey.DownArrow == pressed)
            {
                if (currPos / 3 == 1)
                {
                    if (tictactoe[currPos + 3] == null)
                    {
                        currPos += 3;
                    }
                }
                else if (currPos / 3 == 0)
                {
                    if (tictactoe[currPos + 3] == null)
                    {
                        currPos += 3;
                    }
                    else if (tictactoe[currPos + 6] == null)
                    {
                        currPos += 6;
                    }
                }
            }

        }

        static private void setMark(ConsoleKey pressed)
        {
            if (ConsoleKey.Spacebar == pressed)
            {
                tictactoe[currPos] = currPlayer;
                winAnim();
            }
        }

        static private void winAnim()
        {
            if (check4win())
            {
                win = true;
                return;
            }
            currPlayer = !currPlayer;
        }

        static private string getMark(bool? value, int index)
        {
            if (value == true)
                return "X";
            else if (value == false)
                return "O";
            else
            {
                if (currPos == index)
                    return "_";
                else
                    return ".";
            }

        }

        static private string getMark()
        {
            if (currPlayer)
                return "X";
            else
                return "O";
        }
    }
}
