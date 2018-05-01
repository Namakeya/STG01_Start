using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STG.entity;

namespace STG
{
    class Program
    {
        public static asd.Vector2DF CameraPos = new asd.Vector2DF();
        public static int BlockSize=32;
        public static Random Rand =new System.Random();
        public static asd.Vector2DI Center = new asd.Vector2DI(480, 270);

        [STAThread]
        static void Main(string[] args)
        {

            // Altseedを初期化する。
            asd.Engine.Initialize("STG", 960, 540, new asd.EngineOption());
            
            Player player = new Player();
            player.SetTexture(asd.Engine.Graphics.CreateTexture2D("Resources/Player.png"));
            player.Initialize();

            Room room = new Room();
            room.Width = 50;
            room.Height = 100;
            room.OnGenerated();
            room.EntityList.Add(player);
            room.OnLoaded();
            // Altseedのウインドウが閉じられていないか確認する。
            while (asd.Engine.DoEvents())
            {
                player.Update();

                CameraPos = (player.Position * BlockSize-Center).To2DF();

                room.Render();
                
                player.Render();

                // もし、Escキーが押されていたらwhileループを抜ける。
                if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Escape) == asd.KeyState.Push)
                {
                    break;
                }

                // Altseedを更新する。
                asd.Engine.Update();
            }

            // Altseedの終了処理をする。
            asd.Engine.Terminate();
        }
    }
}
