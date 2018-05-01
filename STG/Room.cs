using STG.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class Room
    {
        public int Width, Height;
        public Block[,] Blocks;
        public List<Entity> EntityList;
        public asd.Vector2DI GlobalPos;

        public static asd.Texture2D Stone =asd.Engine.Graphics.CreateTexture2D("Resources/Stone1.png");

        public virtual void OnGenerated() {
            Blocks = new Block[Width, Height];
            for(int w = 0; w < Width; w++)
            {
                for (int h = 0; h < Height; h++)
                {
                    Blocks[w, h] = new Block();
                    Blocks[w, h].AddToRoom(this, new asd.Vector2DI(w, h));
                    Blocks[w, h].Texture = Stone;
                }
            }
            EntityList = new List<Entity>();
        }
        public virtual void OnLoaded() {
            for (int w = 0; w < Width; w++)
            {
                for (int h = 0; h < Height; h++)
                {
                    Blocks[w, h].Load();
                }
            }
        }
        public virtual void Render()
        {
            for (int w = 0; w < Width; w++)
            {
                for (int h = 0; h < Height; h++)
                {
                    Blocks[w, h].Render();
                }
            }
        }

    }
}
