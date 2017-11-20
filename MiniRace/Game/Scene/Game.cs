﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniRace.Resources;

namespace MiniRace.Game.Scene {
    public class Game : Scene {

        private ushort[,] map, carr;
        private int size = 40;
        private int tileSize = 25;
        private Random rnd = new Random();
        private int time = 0;
        private int wall;
        private int offset;

        private ushort oldCarLeft, oldCarRight, oldCarBack;
        private int x, y;
        private ushort[] car =
        {
            0, 2, 0,
            2, 2, 2,
            0, 2, 0,
            2, 2, 2
        };

        public Game(Main main) : base(main) {
            map = new ushort[size, size];
            carr = new ushort[size, size];

            for (int i = 0; i < size; i++)
                for(int j = 0; j < size; j++)
                    map[j, i] = 1;

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    carr[j, i] = 0;
            

            wall = 0;
            x = size / 2;
            y = x;
        }

        public override void paint(Graphics g) {
            //List<Point> pacmanCords = new List<Point>();

            for (int i = 0; i < main.screen.Width/tileSize; i++)
                for (int j = 0; j < main.screen.Height/tileSize; j++)
                    g.DrawImage(Bundle.wall, i*tileSize, j*tileSize, tileSize, tileSize);

            int offsetCenter = -main.screen.Height / 2 + (main.screen.Width - size) / 2 + tileSize;

            //int offsetCenter = (Width/side)*8

            for (int j = 0; j < main.screen.Height / tileSize; j++) {
                for (int i = 0; i < main.screen.Height / tileSize; i++) {
                    double relX = i / (main.screen.Height / (double)tileSize);
                    double relY = j / (main.screen.Height / (double)tileSize);
                    int x = (int)(relX * size);
                    int y = (int)(relY * size);

                    //Layer 1
                    if (map[x, y] == 0)
                        g.DrawImage(Bundle.wall, offsetCenter + i * tileSize, j * tileSize, tileSize, tileSize);
                    else
                        g.DrawImage(Bundle.floor, offsetCenter + i * tileSize, j * tileSize, tileSize, tileSize);
                    ////Layer 2
                    if (carr[x, y] == 1)
                        g.DrawImage(Bundle.car, offsetCenter + i * tileSize, j * tileSize, tileSize, tileSize);
                }
            }
                roll();
            
            carr[x, y] = 1;

            if(main.screen.left)
            {
                carr[x, y] = 0;
                x--;
                carr[x, y] = 1;
            } else if(main.screen.right)
            {
                carr[x, y] = 0;
                x++;
                carr[x, y] = 1;
            }

            if (map[x, y] == 0)
                currentScene = main.recordsScene;


            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        map[x + j, y + i] = clear[j * 4 + i];
            //    }
            //}

            //for (int i = 0; i < 4; i++) {
            //    for (int j = 0; j < 3; j++) {
            //        map[x + j, y + i] = car[j*4+i];
            //    }
            //}
        }

        private void roll() {
            for (int i = size - 1; i > 0; i--) {
                for (int j = 0; j < size; j++) {
                    map[j, i] = map[j, i - 1];
                    map[j, i - 1] = 1;
                }
            }
            //If not near the left corner
            wall += rnd.Next(-2, 3);
            wall += rnd.Next(-3, 2);

            for (int j = 0; j < size; j++)
                if(!(j>wall+3 && j <size-wall-3))
                    map[j, 0] = 0;
            
            if(wall < 5)
                wall += rnd.Next(3, 5);
            if (wall > size/2-5)
                wall += rnd.Next(-5, -3);
        }
    }
}
