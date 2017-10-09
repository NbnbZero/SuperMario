﻿using System;
using System.Collections.Generic;
using SuperMario.Enums;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;

namespace TileDefinition
{
    public class StartData
    {
        public int xLocation;
        public int yLocation;
        public int yMax;
        public int xMax;
    }
    public class BlockData
    {  
        public BlockType State;
        public ItemType itemType;
        public int xLocation;
        public int yLocation;
    }
    public class ItemData
    {
        public ItemType itemType;
        public int xLocation;
        public int yLocation;
    }

    public class EnemyData
    {
        public EnemyType enemyType;
        public int xLocation;
        public int yLocation;
    }
}