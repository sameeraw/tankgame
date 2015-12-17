using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame4
{
    class tank
    {
        private Vector2 possition=Vector2.Zero;
        private String direction;
        private int coin;
        private int health;
        Texture2D icon;
        private Boolean isShoot;
        private String playerName;
        private int points;

        public tank(Vector2 pos,String dir)
        {
            this.direction = dir;
            this.possition = pos;
        }

        public void setPoints(int p)
        {
            this.points = p;
            Console.Write(this.points);
        }
        public void setDirection(String dir)
        {
            this.direction = dir;
            Console.Write(this.direction);
        }
        public void setPosition(Vector2 pos)
        {
            this.possition = pos;
            Console.Write(this.possition+"nuwan");
        }
        public Vector2 getPossition()
        {
            return this.possition;
        }
        public void changeCoin(int count)
        {
            this.coin = count;
            Console.Write(this.coin+"nuwan");
        }
        public void changeHealth(int count)
        {
            this.health = count;
            Console.Write(this.health+"nuwan");
        }
        public void setIsShoot()
        {
            this.isShoot = true;
        }
        public void setName(String name)
        {
            this.playerName = name;
        }
        public void updateTank()
        {

        }
    }
}
