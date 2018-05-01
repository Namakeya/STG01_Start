using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.entity
{
    class Player:Entity
    {
        public override void Update()
        {
            base.Update();
            if (MoveCooldown < 0)
            {
                bool moved=false;
                // もし、上ボタンが押されていたら、位置に(0,-1)を足す。
                if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Hold)
                {
                    Position = Position + new asd.Vector2DI(0, -1);
                    moved = true;
                }

                // もし、下ボタンが押されていたら、位置に(0,+1)を足す。
                if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Hold)
                {
                    Position = Position + new asd.Vector2DI(0, +1);
                    moved = true;
                }

                // もし、左ボタンが押されていたら、位置に(-1,0)を足す。
                if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold)
                {
                    Position = Position + new asd.Vector2DI(-1, 0);
                    moved = true;
                }

                // もし、右ボタンが押されていたら、位置に(+1,0)を足す。
                if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold)
                {
                    Position = Position + new asd.Vector2DI(+1, 0);
                    moved = true;
                }
                if (moved)
                {
                    MoveCooldown = MaxMoveCooldown;
                }
            }
            MoveCooldown--;
        }
    }
}
