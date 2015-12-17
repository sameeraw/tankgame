using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

namespace WindowsGame4
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Thread listenerThread;
        private connect con;
        Texture2D tank0;
        Texture2D tank1;
        Texture2D tank2;
        Texture2D tank3;
        Texture2D tank4;

        Texture2D brick100;
        Texture2D brick75;
        Texture2D brick50;
        Texture2D brick25;

        Texture2D water;
        Texture2D stone;
        Texture2D empty;

        private Cell[,] Board;
        Vector2 possition0 = Vector2.Zero;
        Vector2 possition1 = Vector2.Zero;
        Vector2 possition2 = Vector2.Zero;
        Vector2 possition3 = Vector2.Zero;
        Vector2 possition4 = Vector2.Zero;

        private parser parserInstance;
        public Game1()
        {
            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.parserInstance = new parser();

            this.con = new connect();
            this.listenerThread=new Thread(new ThreadStart(con.listener));
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tank0 = Content.Load<Texture2D>("icon");
            tank1 = Content.Load<Texture2D>("icon");
            tank2 = Content.Load<Texture2D>("icon");
            tank3 = Content.Load<Texture2D>("icon");
            tank4 = Content.Load<Texture2D>("icon");

            water = Content.Load<Texture2D>("water");
            stone = Content.Load<Texture2D>("stone");
            brick100 = Content.Load<Texture2D>("brick");
            empty = Content.Load<Texture2D>("empty");
            //*********************************************
            

            con.cli_start();

            //draw the map
            
            

            //con.listener();
            //*********************************************
            // TODO: use this.Content to load your game content here
        }

        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            AI ai = new AI();
            ai.shoot();
            Console.WriteLine("awa");
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            //con.listener();
            
            //this.listenerThread.Start();
            Console.WriteLine("iwarai");
            String fromConnect = con.getData();
            Boolean trigger = true;
            while (trigger)
            {
                if (!fromConnect.Equals(""))
                {
                    trigger = false;
                    this.parserInstance.decoder(fromConnect);
                    this.Board = this.parserInstance.getBoard();
                    Console.WriteLine(this.Board);
                }
                fromConnect = con.getData();
            }
            /*
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(this.Board[i, j].getType() + " ");
                }
                Console.Write("\n");
            }*/

                possition0 = this.parserInstance.getTank(0).getPossition();
            possition1 = this.parserInstance.getTank(1).getPossition();
            possition2 = this.parserInstance.getTank(2).getPossition();
            possition3 = this.parserInstance.getTank(3).getPossition();
            possition4 = this.parserInstance.getTank(4).getPossition();
            Console.WriteLine("harii");
            Console.WriteLine(possition1);
            Console.WriteLine("kasun");
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
           GraphicsDevice.Clear(Color.AntiqueWhite);

            // TODO: Add your drawing code here
            Console.WriteLine("00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
           //SpriteSortMode.FrontToBack, BlendState.AlphaBlend
            //*******************draw the tanks**************************************
            spriteBatch.Draw(tank0, possition0, Color.Black);
            spriteBatch.Draw(tank1, possition1, Color.Red);
            spriteBatch.Draw(tank2, possition2, Color.White);
            spriteBatch.Draw(tank3, possition3, Color.Green);
            spriteBatch.Draw(tank4, possition4, Color.Blue);
            //*****************end draw tanks************************************


            //****************draw the map****************************************
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Vector2 place = new Vector2(this.Board[i, j].getPossition().X * 51, this.Board[i, j].getPossition().Y * 51);
                    String type = this.Board[i, j].getType();
                    if (type.Equals("S"))
                    {
                        this.Board[i, j].setImage(stone);
                    }
                    if (type.Equals("W"))
                    {
                        this.Board[i, j].setImage(water);
                    }
                    if(type.Equals("B"))
                    {
                        this.Board[i, j].setImage(brick100);
                    }
                    else
                    {
                        this.Board[i, j].setImage(empty);
                    }
                    spriteBatch.Draw(this.Board[i, j].getImage(), place, Color.Green);

                }
            }

            //***************end draw the map*************************************
            spriteBatch.End();
            base.Draw(gameTime);
            Thread.Sleep(500);
        }
        public Cell[,] getcellinfo()
        {
            return this.Board;
        }
        
            
        
    }
}
