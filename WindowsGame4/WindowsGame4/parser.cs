using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame4
{
    class parser
    {
        private String playerName;
        private Cell[,] board;
        private tank[] tanks;
        private int nuOfTanks=5;

        public parser()
        {
            tanks = new tank[nuOfTanks];
            this.initializeCellPositions();
            tanks[0] = new tank(Vector2.Zero,"0");
            tanks[1] = new tank(Vector2.Zero, "0");
            tanks[2] = new tank(Vector2.Zero, "0");
            tanks[3] = new tank(Vector2.Zero, "0");
            tanks[4] = new tank(Vector2.Zero, "0");
        }

        public tank getTank(int index)
        {
            try
            {
                return this.tanks[index];
            }
            catch (Exception e)
            {
                return new tank(new Vector2(0, 0), "0");
            }
        }

        //this method calls relevent function as wish
        public void decoder(String para)
        {
            Console.WriteLine("*************+++++++++++++++++++++++++decoder+++++++++++++*****************");
            String key = "";
            try
            {
                key = para.Substring(0, 1);
            }
            catch (Exception e) { }
            if (key.Equals("I"))
            {
                //this.gameInitializer(para.Substring(2,para.Length-2));
                this.gameInitializer(para);
            }
            if (key.Equals("G"))
            {
                //this.movingAndShooting(para.Substring(2, para.Length - 2));
                this.movingAndShooting(para);
            }
            if (key.Equals("S"))
            {
                this.tankDetails(para);
            }
        }

        public void gameInitializer(String get)
        {
            Console.WriteLine("---------------------------initiater-------------------------------------------");
            this.playerName = get.Substring(2, 2);
            String dots = get.Substring(5, get.Length - 7);
            String[] groups = dots.Split(':');
            String[] brickString = groups[0].Split(';'); //array contains string coordinats
            String[] stoneString = groups[1].Split(';'); // array contains string cordinates of stone
            String[] waterString = groups[2].Split(';'); //array contains string cordinates of water

            foreach (String value in brickString)
            {
                int x = Int32.Parse(value.Substring(2, 1));
                int y = Int32.Parse(value.Substring(0, 1));
                board[x, y].setType("B");
            }

            foreach (String value in stoneString)
            {
                int x = Int32.Parse(value.Substring(2, 1));
                int y = Int32.Parse(value.Substring(0, 1));
                board[x, y].setType("S");
            }

            foreach (String value in waterString)
            {
                int x = Int32.Parse(value.Substring(2, 1));
                int y = Int32.Parse(value.Substring(0, 1));
                board[x, y].setType("W");
            }
            //this.initializeCellPositions();
        }

        //shooting method
        public void movingAndShooting(String get)
        {
            Console.WriteLine("------------------------------------movingAndShooting movingAndShooting shooting----------------------------");
            String myString = get.Substring(2, get.Length - 4);
            String[] parts = myString.Split(':');

            foreach (String value in parts)
            {
                if (value.Substring(0, 2).Equals("P0"))
                {
                    String[] p1 = parts[0].Split(';'); //["p1","2,3".........]
                    Vector2 pos = new Vector2((Int32.Parse(p1[1].Substring(0, 1)))*50, Int32.Parse(p1[1].Substring(2, 1))*50);
                    tanks[0] = new tank(pos, p1[2]); //0,1,2,3
                    tanks[0].changeHealth(Int32.Parse(p1[4]));
                    tanks[0].changeCoin(Int32.Parse(p1[5]));
                    tanks[0].setPoints(Int32.Parse(p1[6]));
                }

                if (value.Substring(0, 2).Equals("P1"))
                {
                    String[] p2 = parts[1].Split(';'); //["p1","2,3".........]
                    Vector2 pos = new Vector2(Int32.Parse(p2[1].Substring(0, 1))*50, Int32.Parse(p2[1].Substring(2, 1))*50);
                    tanks[1] = new tank(pos, p2[2]); //0,1,2,3
                    tanks[1].changeHealth(Int32.Parse(p2[4]));
                    tanks[1].changeCoin(Int32.Parse(p2[5]));
                    tanks[1].setPoints(Int32.Parse(p2[6]));
                }

                if (value.Substring(0, 2).Equals("P2"))
                {
                    String[] p3 = parts[2].Split(';'); //["p1","2,3".........]
                    Vector2 pos = new Vector2(Int32.Parse(p3[1].Substring(0, 1))*50, Int32.Parse(p3[1].Substring(2, 1))*50);
                    tanks[2] = new tank(pos, p3[2]); //0,1,2,3
                    tanks[2].changeHealth(Int32.Parse(p3[4]));
                    tanks[2].changeCoin(Int32.Parse(p3[5]));
                    tanks[2].setPoints(Int32.Parse(p3[6]));

                }

                if (value.Substring(0, 2).Equals("P3"))
                {
                    String[] p4 = parts[3].Split(';'); //["p1","2,3".........]
                    Vector2 pos = new Vector2(Int32.Parse(p4[1].Substring(0, 1))*50, Int32.Parse(p4[1].Substring(2, 1))*50);
                    tanks[3] = new tank(pos, p4[2]); //0,1,2,3
                    tanks[3].changeHealth(Int32.Parse(p4[4]));
                    tanks[3].changeCoin(Int32.Parse(p4[5]));
                    tanks[3].setPoints(Int32.Parse(p4[6]));
                }

                if (value.Substring(0, 2).Equals("P4"))
                {
                    String[] p5 = parts[4].Split(';'); //["p1","2,3".........]
                    Vector2 pos = new Vector2(Int32.Parse(p5[1].Substring(0, 1))*50, Int32.Parse(p5[1].Substring(2, 1))*50);
                    tanks[4] = new tank(pos, p5[2]); //0,1,2,3
                    tanks[4].changeHealth(Int32.Parse(p5[4]));
                    tanks[4].changeCoin(Int32.Parse(p5[5]));
                    tanks[4].setPoints(Int32.Parse(p5[6]));

                }

                else
                {
                    String[] damages = value.Split(';');
                }
            }
        }
        public Cell[,] getBoard()
        {
            return this.board;
        }


        public void initializeCellPositions()
        {
            this.board = new Cell[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (this.board[i, j] == null)
                    {
                        this.board[i, j] = new Cell();
                    }
                    else
                    {
                        this.board[i, j].setPossition(new Vector2(i * 50, j * 50));
                    }

                    //Console.Write(board[i, j] + " ");
                }

            }
        }
        public void tankDetails(String para)
        {
            String myData=para.Substring(2,para.Length-4);
            String[] tanksDetails = myData.Split(':');
            int len = tanksDetails.Length;
            this.nuOfTanks = len;
            int number=0;
            foreach (String value in tanksDetails)
            {
                this.tanks[number].setPosition(new Vector2(Int32.Parse(value.Substring(0, 1)) * 50, Int32.Parse(value.Substring(2, 1)) * 50));
                number++;
            }
        }
    }
}