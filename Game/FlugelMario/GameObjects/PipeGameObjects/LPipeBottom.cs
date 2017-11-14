﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.Sound;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperMario.GameObjects.GameObjectType;

namespace SuperMario.GameObjects.PipeGameObjects
{
    class LPipeBottom:IPipe
    {
        private ISprite sprite;
        public ObjectType Type { get; } = ObjectType.Pipe;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }
        private Vector2 teleLocation;
        public bool IsTelable { get; set; } = false;
        private List<IGameObject> pipeList { get; }
        Random rd = new Random();
        private static int random;
        
        public LPipeBottom(Vector2 location, Vector2 teleLocation)
        {
            sprite = PipeSpriteFactory.Instance.CreateLPipeBottomSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
            this.teleLocation = teleLocation;
            IsTelable = true;
            pipeList = GameObjectManager.pipeList;
        }

        public LPipeBottom(Vector2 location)
        {
            sprite = PipeSpriteFactory.Instance.CreateLPipeBottomSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.Location);
        }

        public void Warp(IMario mario)
        {
            if (IsTelable)
            {
                random = rd.Next(0, pipeList.Count-1);
                IPipe pipe = (IPipe)pipeList[random];
                while (pipe.Location.Y>420)
                {
                    random = rd.Next(0, pipeList.Count - 1);
                    pipe = (IPipe)pipeList[random];
                }
                Camera.SetCamera(new Vector2(pipe.Destination.X - 16 * 5, 0));
                mario.Velocity = Vector2.Zero;
                mario.Location = new Vector2(pipe.Destination.X - 8, pipe.Destination.Y - mario.Destination.Height);
                SoundManager.Instance.PlayPipeSound();
                SoundManager.Instance.PlayOverWorldSong();
            }
        }

        public void Update()
        {
            Destination = sprite.MakeDestinationRectangle(Location);
            sprite.Update();
        }
    }
}
