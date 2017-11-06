﻿using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;
using FlugelMario.GameObjects.EnemyGameObjects;
using SuperMario.SpriteFactories;
using SuperMario.States.EnemyStates;

namespace FlugelMario.States.EnemyStates
{
    public class GoombaAliveState : IEnemyState
    {
        public ISprite StateSprite { get; set; }

        private Goomba goomba;

        public GoombaAliveState(Goomba goomba)
        {
            StateSprite = EnemySpriteFactory.Instance.CreateGoombaSprite();
            this.goomba = goomba;
        }

        public void ChangeDirection()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            StateSprite.Draw(spriteBatch, location);
        }

        public void Terminate(string direction)
        {
            if (direction.ToUpper().Equals("TOP"))
                goomba.State = new GoombaDeadState();
        }

        public void Update()
        {
            StateSprite.Update();
        }
    }
}
