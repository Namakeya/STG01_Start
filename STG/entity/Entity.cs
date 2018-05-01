using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.entity
{
    class Entity
    {
        public asd.Vector2DI Position=new asd.Vector2DI();
        public int Health;
        public int Atk;
        public int Def;
        public int Dex;
        public int Sen;
        asd.TextureObject2D TextureObject = new asd.TextureObject2D();
        public int MaxMoveCooldown=20;
        public int MoveCooldown;
        public Room RoomIn;

        public virtual void Initialize()
        {
            AddToRenderLayer();
        }
            

        public virtual void Update()
        {
        }

        public virtual void SetTexture(asd.Texture2D tex)
        {
            TextureObject.Texture = tex;
            TextureObject.CenterPosition = new asd.Vector2DF(tex.Size.X / 2f, Program.BlockSize/2);
         
        }

        public virtual void Render()
        {
           
            TextureObject.Position = (Position*Program.BlockSize).To2DF() - Program.CameraPos;
           
        }

        public virtual void AddToRenderLayer()
        {
            TextureObject.DrawingPriority = 100;
            asd.Engine.AddObject2D(TextureObject);
        }

        public virtual void Move(asd.Vector2DI dir)
        {
            if (CanMove(Position + dir))
            {
                Position += dir;
            }
        }

        public virtual bool CanMove(asd.Vector2DI pos)
        {
            if (pos.X > 0 && pos.Y > 0 && pos.X < RoomIn.Width && pos.Y < RoomIn.Height)
            {
                if (RoomIn.GetBlock(pos).Wall)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
