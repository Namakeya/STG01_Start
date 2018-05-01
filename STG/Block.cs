using STG.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
     class Block
    {
        public Room Room;
        public asd.Vector2DI Position;
        public bool Pressed;
        public asd.TextureObject2D TextureObject;
        //easy use. u can igonore this
        public asd.Texture2D Texture;
        public bool Wall;
        public bool Found;
        public int RenderX;
        public int RenderY;
        public int RenderRotate;

        public virtual void Initialize() { }
        public virtual void AddToRoom(Room room, asd.Vector2DI pos)
        {
            Room = room;
            Position = pos;
            Pressed = false;
           
        }
        public virtual void Load()
        {
            TextureObject = new asd.TextureObject2D();
            TextureObject.Texture = GetTexture();
            /*
            int RenderHash = Program.Rand.Next();
            RenderX = (RenderHash % ((Texture.Size.X) / Program.BlockSize)) * Program.BlockSize;
            RenderHash /= ((Texture.Size.X ) / Program.BlockSize);
            RenderY = (RenderHash % ((Texture.Size.Y) / Program.BlockSize)) * Program.BlockSize;
            RenderHash /= ((Texture.Size.Y ) / Program.BlockSize);
            RenderRotate = (RenderHash % 4) * 90;
            

            TextureObject.Src = new asd.RectF(RenderX, Program.BlockSize, RenderY, Program.BlockSize);
            TextureObject.Angle = 90 * RenderRotate;
            */
            TextureObject.CenterPosition = new asd.Vector2DF(Program.BlockSize / 2, Program.BlockSize / 2);
            RenderX = 0;
            RenderY = 0;
            RenderRotate = 0;
            AddToRenderLayer();

            //Console.WriteLine(RenderX + "," + RenderY);
        }
        public virtual void Update()
        {
            bool pressed = Pressed;
            Pressed = false;
            foreach (Entity e in Room.EntityList)
            {
                if(e.Position.X==Position.X && e.Position.Y == Position.Y)
                {
                    if (!pressed)
                    {
                        OnPressed(e);
                    }
                    OnPressing(e);
                    Pressed = true;
                }
            }
        }

        public virtual void OnPressed(Entity entity) { }
        public virtual void OnPressing(Entity entity) { }
        public virtual asd.Texture2D GetTexture() {
            return Texture;
        }


        public virtual void Render()
        {

            TextureObject.Position = (Position * Program.BlockSize).To2DF() - Program.CameraPos;

        }

        public virtual void AddToRenderLayer()
        {
            asd.Engine.AddObject2D(TextureObject);
        }

    }
}
