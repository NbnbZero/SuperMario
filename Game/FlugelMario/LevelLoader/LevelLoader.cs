﻿using SuperMario.Interfaces;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using SuperMario.Enums;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using TileDefinition;
using SuperMario.GameObjects;
using System;
using SuperMario.GameObjects.ItemGameObjects;
using FlugelMario.GameObjects.PipeGameObjects;
using SuperMairo.GameObjects;

namespace SuperMario
{
    public class LevelLoader
    {
        private GameObjectManager objectMagager;
        public LevelLoader(GameObjectManager gameManager)
        {
            objectMagager = gameManager;            
        }

        public void Load()
        {
            LoadBlocks();
            LoadEnemies();
            LoadItems();
            LoadPipe();
            LoadObject();
        }


        public void LoadBlocks()
        {
            List<BlockData> myObjects = new List<BlockData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<BlockData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("../../../../LevelLoader/Level1.xml"))
            {
                myObjects = (List<BlockData>)serializer.Deserialize(reader);
            }
            for (int i = 0; i < 1200; i += 16)
            {
                GameObjectManager.blockList.Add(new FloorBlock(new Vector2(i, 400)));
            }
            for (int i = 1250; i < 1500; i += 16)
            {
                GameObjectManager.blockList.Add(new FloorBlock(new Vector2(i, 400)));
            }
            for (int i = 1550; i < 2300; i += 16)
            {
                GameObjectManager.blockList.Add(new FloorBlock(new Vector2(i, 400)));
            }
            for (int i = 2350; i < 3700; i += 16)
            {
                GameObjectManager.blockList.Add(new FloorBlock(new Vector2(i, 400)));
            }

            foreach (BlockData block in myObjects)
                {                                           
                    switch (block.State)
                        {
                            case BlockType.Brick:
                                GameObjectManager.blockList.Add(new BrickBlock(new Vector2(block.xLocation, block.yLocation)));
                                break;
                            case BlockType.Stair:
                                GameObjectManager.blockList.Add(new StairBlock(new Vector2(block.xLocation, block.yLocation)));
                                break;
                            case BlockType.Broken:
                                GameObjectManager.blockList.Add(new FloorBlock(new Vector2(block.xLocation, block.yLocation)));
                                break;
                            case BlockType.Question:
                                QuestionBlock question = new QuestionBlock(new Vector2(block.xLocation, block.yLocation));
                                if (block.itemType == ItemType.Flower)
                                {
                                      question.hiddenItem = ItemType.Flower;
                                      GameObjectManager.blockList.Add(question);
                                }
                                else if (block.itemType == ItemType.Star)
                                {
                                    question.hiddenItem = ItemType.Star;
                                    GameObjectManager.blockList.Add(question);
                                }
                                else if (block.itemType == ItemType.UpMushroom)
                                {
                                    question.hiddenItem = ItemType.UpMushroom;
                                    GameObjectManager.blockList.Add(question);
                                }
                                else if (block.itemType == ItemType.SuperMushroom)
                                {
                                     question.hiddenItem = ItemType.SuperMushroom;
                                     GameObjectManager.blockList.Add(question);
                                }                                 
                                else if (block.itemType == ItemType.Coin)
                                {
                                    question.hiddenItem = ItemType.Coin;
                                    GameObjectManager.blockList.Add(question);
                                } 
                                        break;
                        
                        }
                }
            
        }


        public void LoadItems()
        {
            List<ItemData> myObjects = new List<ItemData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<ItemData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("../../../../LevelLoader/Level1.xml"))
            {
                myObjects = (List<ItemData>)serializer.Deserialize(reader);
            }

                foreach (ItemData item in myObjects)
                {
                    switch (item.itemType)
                    {
                        case ItemType.Coin:
                            GameObjectManager.itemList.Add(new Coin(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.Flower:
                            GameObjectManager.itemList.Add(new FireFlower(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.SuperMushroom:
                            GameObjectManager.itemList.Add(new SuperMushroom(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.UpMushroom:
                            GameObjectManager.itemList.Add(new UpMushroom(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.Star:
                            GameObjectManager.itemList.Add(new Star(new Vector2(item.xLocation, item.yLocation)));
                            break;
                    }

                }
            
        }

        public void LoadEnemies()
        {
            List<EnemyData> myObjects = new List<EnemyData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<EnemyData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("../../../../LevelLoader/Level1.xml"))
            {
                myObjects = (List<EnemyData>)serializer.Deserialize(reader);
            }
           
            foreach (EnemyData enemy in myObjects)
            {
                switch (enemy.enemyType)
                {
                    case EnemyType.Koopa:
                        GameObjectManager.enemyList.Add(new Koopa(new Vector2(enemy.xLocation, enemy.yLocation)));
                        break;
                    case EnemyType.Goomba:
                        GameObjectManager.enemyList.Add(new Goomba(new Vector2(enemy.xLocation, enemy.yLocation)));
                        break;

                }
            }
            
        }

        private void LoadPipe()
        {
            List<PipeData> myObjects = new List<PipeData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<PipeData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("../../../../LevelLoader/Level1.xml"))
            {
                myObjects = (List<PipeData>)serializer.Deserialize(reader);
            }

            //TODO: add more cases
            foreach (PipeData pipe in myObjects)
            {
                switch (pipe.PipeType)
                {
                    case PipeType.Pipe:
                        GameObjectManager.pipeList.Add(new Pipe(new Vector2(pipe.xLocation, pipe.yLocation)));
                        break;
                    case PipeType.MediumPipe:
                        GameObjectManager.pipeList.Add(new MediumPipe(new Vector2(pipe.xLocation, pipe.yLocation)));
                        break;
                    case PipeType.BigPipe:
                        GameObjectManager.pipeList.Add(new BigPipe(new Vector2(pipe.xLocation, pipe.yLocation)));
                        break;
                }
            }
        }

        private void LoadObject()
        {
            List<ObjectData> myObjects = new List<ObjectData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<ObjectData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("../../../../LevelLoader/Level1.xml"))
            {
                myObjects = (List<ObjectData>)serializer.Deserialize(reader);
            }

            //TODO: add more cases && fix bug
            foreach (ObjectData obj in myObjects)
            {
                switch (obj.BackgourndObj)
                {
                    case BackgroundObjType.Castle:
                        GameObjectManager.objectList.Add(new Castle(new Vector2(obj.xLocation, obj.yLocation)));
                        break;
                    case BackgroundObjType.BigHill:
                        GameObjectManager.objectList.Add(new BigHill(new Vector2(obj.xLocation, obj.yLocation)));
                        break;
                }
            }
        }
    }
}
