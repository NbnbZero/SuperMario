﻿using SuperMario.Interfaces;
using SuperMario.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Enums;

namespace SuperMario.SpriteFactories
{
    class ItemSpriteFactory
    {
        public int FlowerSpriteSheetColumn { get; } = 4;
        public int FlowerSpriteSheetRows { get; } = 1;
        public int FlowerAnimeTotalFrame { get; } = 4;

        public int CoinSpriteSheetColumn { get; } = 4;
        public int CoinSpriteSheetRows { get; } = 1;
        public int CoinAnimeTotalFrame { get; } = 4;

        public int SuperMushroomSpriteSheetColumn { get; } = 1;
        public int SuperMushroomSpriteSheetRows { get; } = 1;
        public int SuperMushroomAnimeTotalFrame { get; } = 1;

        public int UpMushroomSpriteSheetColumn { get; } = 1;
        public int UpMushroomSpriteSheetRows { get; } = 1;
        public int UpMushroomAnimeTotalFrame { get; } = 1;

        public int StarSpriteSheetColumn { get; } = 4;
        public int StarSpriteSheetRows { get; } = 1;
        public int StarAnimeTotalFrame { get; } = 4;


        private Texture2D ItemFlowerSpriteSheet;
        private Texture2D ItemCoinSpriteSheet;
        private Texture2D ItemSuperMushroomSpriteSheet;
        private Texture2D ItemUpMushroomSpriteSheet;
        private Texture2D ItemStarSpriteSheet;
        private Texture2D ItemSpriteSheet;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();
        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {

        }
        public void LoadAllTextures(ContentManager content)
        {
            ItemFlowerSpriteSheet = content.Load<Texture2D>("FlowerSheet");
            ItemCoinSpriteSheet = content.Load<Texture2D>("CoinSheet");
            ItemSuperMushroomSpriteSheet = content.Load<Texture2D>("SuperMushroomSheet");
            ItemUpMushroomSpriteSheet = content.Load<Texture2D>("UpMushroomSheet");
            ItemStarSpriteSheet = content.Load<Texture2D>("StarSheet");
            ItemSpriteSheet = content.Load<Texture2D>("ItemSheet");


        }

        public int FlowerWith
        {
            get
            {
                return ItemFlowerSpriteSheet.Width / FlowerSpriteSheetColumn;
            }
        }
        public int FlowerHeight
        {
            get
            {
                return ItemFlowerSpriteSheet.Height / FlowerSpriteSheetRows;
            }
        }
        public int CoinWith
        {
            get
            {
                return ItemCoinSpriteSheet.Width / CoinSpriteSheetColumn;
            }
        }
        public int CoinHeight
        {
            get
            {
                return ItemCoinSpriteSheet.Height / CoinSpriteSheetRows;
            }
        }
        public int SuperMushroomWith
        {
            get
            {
                return ItemSuperMushroomSpriteSheet.Width / SuperMushroomSpriteSheetColumn;
            }
        }
        public int SuperMushroomHeight
        {
            get
            {
                return ItemSuperMushroomSpriteSheet.Height / SuperMushroomSpriteSheetRows;
            }
        }

        public int UpMushroomWith
        {
            get
            {
                return ItemUpMushroomSpriteSheet.Width / UpMushroomSpriteSheetColumn;
            }
        }
        public int UpMushroomHeight
        {
            get
            {
                return ItemUpMushroomSpriteSheet.Height / UpMushroomSpriteSheetRows;
            }
        }

        public int StarWith
        {
            get
            {
                return ItemStarSpriteSheet.Width / StarSpriteSheetColumn;
            }
        }
        public int StarHeight
        {
            get
            {
                return ItemStarSpriteSheet.Height / StarSpriteSheetRows;
            }
        }

        public ItemSprite CreateFlowerSprite(Vector2 location)
        {
            return new FlowerSprite(ItemFlowerSpriteSheet, location) { Color = Color.LightGreen };
        }

        public ItemSprite CreateCoinSprite(Vector2 location)
        {
            return new CoinSprite(ItemCoinSpriteSheet, location) { Color = Color.LightGreen };
        }
        public ItemSprite CreateSuperMushroomSprite(Vector2 location)
        {
            return new SuperMushroomSprite(ItemSuperMushroomSpriteSheet, location) { Color = Color.LightGreen };
        }
        public ItemSprite CreateUpMushroomSprite(Vector2 location)
        {
            return new UpMushroomSprite(ItemUpMushroomSpriteSheet, location) { Color = Color.LightGreen };
        }

        public ItemSprite CreateStarSprite(Vector2 location)
        {
            return new StarSprite(ItemStarSpriteSheet, location) { Color = Color.LightGreen };
        }

        public Sprite CreateDisappearedSprite() {
            return new DisappearedSprite(ItemSpriteSheet);
        }

        public ItemSprite MakeSprite(ItemType sprite, Vector2 location)
        {
            ItemSprite item = null;

            if (sprite == ItemType.UpMushroom)
            {
                item = CreateUpMushroomSprite(location);
            }

            return item;
        }

        public Vector2 FlowerAnimation1 { get; } = new Vector2(0, 0);
        //public Vector2 FlowerAnimation2 = new Vector2(1, 0);
        //public Vector2 FlowerAnimation3 { get; } = new Vector2(2, 0);
        //public Vector2 FlowerAnimation4 { get; } = new Vector2(3, 0);

        public Vector2 CoinAnimation1 { get; } = new Vector2(0, 0);
        //public Vector2 CoinAnimation2 { get; } = new Vector2(1, 0);
        //public Vector2 CoinAnimation3 { get; } = new Vector2(2, 0);
        //public Vector2 CoinAnimation4 { get; } = new Vector2(3, 0);

        public Vector2 SuperMushroomAnimation1 { get; } = new Vector2(0, 0);
        public Vector2 UpMushroomAnimation1 { get; } = new Vector2(0, 0);

        public Vector2 StarAnimation1 { get; } = new Vector2(0, 0);
        //public Vector2 StarAnimation2 { get; } = new Vector2(1, 0);
        //public Vector2 StarAnimation3 { get; } = new Vector2(2, 0);
        //public Vector2 StarAnimation4 { get; } = new Vector2(3, 0);
    }
}
