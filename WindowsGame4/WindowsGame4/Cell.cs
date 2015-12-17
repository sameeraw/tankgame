using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;


namespace WindowsGame4
{
    class Cell
    {
        private Vector2 possition=Vector2.Zero;

        private int damageLevel=0;
        public Texture2D cell;
        private String type;

        private Texture2D image;

        public Cell( )
        {
            //Content.RootDirectory = "Content";
            
            this.type = "N";
        }

        public void setImage(Texture2D img)
        {
            this.image = img;
        }
        public Texture2D getImage()
        {
            return this.image;
        }

        public void setPossition(Vector2 pos)
        {
            this.possition = pos;
        }

        public void setType(String type)
        {
            this.type = type;
            //Console.Write(type+"nuwan");
        }
        public Vector2 getPossition ()
        {
            return this.possition;
        }
        public void decDamage()
        {
            if (this.damageLevel>0)
            {
                this.damageLevel -= 25;
            }
        }

        public String getType()
        {
            return this.type;
        }
        public void updateCell()
        {
  
        }
    }
}
