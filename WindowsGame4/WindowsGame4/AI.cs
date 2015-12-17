using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading;

namespace WindowsGame4
{
    class AI
    {
        private tank[] tank;
        private connect connection;
        private Cell[,] Board ;
        Game1 GME = new Game1();
        parser p;
        public AI()
        {
            p = new parser();
            this.Board = p.getBoard();
            this.connection = new connect();
            
            this.tank[0] = p.getTank(0);
        }
        public void shoot() { 
             Vector2 pos,pos1,pos2,pos3,pos4;
             float x ;
             float y;
           
           // for(float i=y ;i>-1;i--)
            while(1==1){
                 pos=tank[0].getPossition();
                pos1=tank[1].getPossition();
                 pos2=tank[2].getPossition();
                 pos3=tank[3].getPossition();
                 pos4=tank[4].getPossition();
                  x = pos.X;
                 y= pos.Y;
                int yo,xo;
                yo=(int)y;
                xo=(int)x ;
                for(int i=yo-1 ;yo>-1;i--){    // checking forward direction
                if(this.Board[xo,i]==null){
                 continue;
                }else{
                  if(xo==pos1.X && i==pos1.Y || xo==pos2.X && i==pos2.Y ||xo==pos3.X && i==pos3.Y  ||xo==pos4.X && i==pos4.Y ){
                   shootTank();
                  }else break;
                }
                }

                for(int i=yo+1 ;yo<11;i++){   // checking backward direction
                if(this.Board[xo,i]==null){
                 continue;
                }else{
                  if(xo==pos1.X && i==pos1.Y || xo==pos2.X && i==pos2.Y ||xo==pos3.X && i==pos3.Y  ||xo==pos4.X && i==pos4.Y){
                   shootTank();
                  }else break;
                }
                }

                for(int i=xo+1 ;xo<11;i++){   //checking right
                if(this.Board[i,yo]==null){
                 continue;
                }else{
                  if(i==pos1.X && yo==pos1.Y || i==pos2.X && yo==pos2.Y ||i==pos3.X && yo==pos3.Y  ||i==pos4.X && yo==pos4.Y){
                   shootTank();
                  }else break;
                }
                }

                for(int i=xo-1 ;xo>-1;i--){    //checking left
                if(this.Board[i,yo]==null){
                 continue;
                }else{
                  if(i==pos1.X && yo==pos1.Y || i==pos2.X && yo==pos2.Y ||i==pos3.X && yo==pos3.Y  ||i==pos4.X && yo==pos4.Y){
                   shootTank();
                  }else break;
                }
                }

   
               
                 if(this.Board[xo,yo-1]==null){
                moveUp(1);
                }
                 if(xo==pos1.X && yo-1==pos1.Y || xo==pos2.X && yo-1==pos2.Y ||xo==pos3.X && yo-1==pos3.Y  ||xo==pos4.X && yo-1==pos4.Y){
               shootTank();
                }
                if(this.Board[xo,yo-1].getType().Equals("S") || this.Board[xo,yo-1].getType().Equals("W") ){
                    moveRight(1);
                    //moveUp(1);
                
                }
                if(this.Board[xo,yo-1].getType().Equals("B")){
                 shootTank();
                
                }
                
                if(this.Board[xo,yo+1].getType().Equals("E")){
                moveUp(1);
                }

                if(xo==pos1.X && yo+1==pos1.Y || xo==pos2.X && yo+1==pos2.Y ||xo==pos3.X && yo+1==pos3.Y  ||xo==pos4.X && yo+1==pos4.Y){
                shootTank();
               }

                if(this.Board[xo,yo+1].getType().Equals("S") || this.Board[xo,yo+1].getType().Equals("W")){
                    moveRight(1);
                    //moveUp(1);
                
                }

                if(this.Board[xo,yo+1].getType().Equals("B")){
                 shootTank();
                
                }
 
                if(this.Board[xo-1,yo].getType().Equals("E")){
                moveUp(1);
                }

                if(xo-1==pos1.X && yo==pos1.Y || xo-1==pos2.X && yo==pos2.Y ||xo-1==pos3.X && yo==pos3.Y  ||xo-1==pos4.X && yo==pos4.Y){
                shootTank();
                }

                if(this.Board[xo-1,yo].getType().Equals("S") || this.Board[xo-1,yo].getType().Equals("W")){
                    moveRight(1);
                   // moveUp(1);
                
                }
                if(this.Board[xo-1,yo].getType().Equals("B")){
                 shootTank();
                
                }

                if(this.Board[xo+1,yo].getType().Equals("E")){
                moveUp(1);
                }

                if(xo+1==pos1.X && yo==pos1.Y || xo+1==pos2.X && yo==pos2.Y ||xo+1==pos3.X && yo==pos3.Y  ||xo+1==pos4.X && yo==pos4.Y){
                shootTank();
                }

                if(this.Board[xo+1,yo].getType().Equals("S")|| this.Board[xo+1,yo].getType().Equals("W")){
                    moveRight(1);
                  //  moveUp(1);
                
                }
                if(this.Board[xo+1,yo].getType().Equals("B")){
                 shootTank ();
                
                }


            }
     
        }
        public void shootTank() {

            ThreadPool.QueueUserWorkItem(new WaitCallback(state => connection.write_to_server("SHOOT#")));
        
        
        }

        public void moveRight(int distance)
        {
            for (int i = 0; i < distance; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(state => connection.write_to_server("RIGHT#")));
            }
        }

        public void moveLeft(int distance)
        {
            for (int i = 0; i < distance; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(state => connection.write_to_server("LEFT#")));
            }
        }

        public void moveUp(int distance)
        {
            for (int i = 0; i < distance; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(state => connection.write_to_server("UP#")));
            }
        }

        public void moveDown(int distance)
        {
            for (int i = 0; i < distance; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(state => connection.write_to_server("DAWN#")));
            }
        }

        public int getShootableTankCount(Vector2 tankPossition, tank[] tanks, Cell[,] map)
        {
            int tankCount = 0;
            float x, y;
            x = tankPossition.X;
            y = tankPossition.Y;
            foreach (tank Value in tanks)
            {
                float i = Value.getPossition().X;
                float j = Value.getPossition().Y;

                if (i == x)
                {
                    for (int n = min(j, y); n < max(j, y); n++)
                    {
                        if (!("N".Equals(map[(int)Math.Ceiling(i), n].getType())))
                        {

                        }
                    }
                }
                if (j == y)
                {

                }
            }
            return tankCount;
        }

        public int min(float x, float y)
        {
            if (x > y)
            {
                return (int)Math.Ceiling(y);
            }
            else
            {
                return (int)Math.Ceiling(x);
            }
        }

        public float max(float x, float y)
        {
            if (x > y)
            {
                return (int)Math.Ceiling(x);
            }
            else
            {
                return (int)Math.Ceiling(y);
            }
        }





    }     
           
}
