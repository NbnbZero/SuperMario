﻿using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Commands
{
    class MarioEnemyTowSide : ICommand
    {
        CollisionHandlerMario myhandler;
        public MarioEnemyTowSide(CollisionHandlerMario handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            myhandler.mario.Velocity = new Vector2(myhandler.mario.Velocity.X, -myhandler.mario.Velocity.Y);

        }
    }
}
