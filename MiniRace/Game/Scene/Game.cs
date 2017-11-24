using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniRace.Resources;

namespace MiniRace.Game.Scene {
    public class Game : Scene {

        private ushort[,] map, oil, carr, oiledd;
        private int size = 40;
        private int tileSize = 25;
        private Random rnd = new Random();
        public int score { get; set; } = 0;
        public int time { get; set; } = 0;
        private int timesToDirection = 0;
        private int wall;
        private int offset;
        private bool oiled = false;

        enum tiles {
            wall,
            floor,
            oil,
            oilpath
        }

        enum car {
            air,
            car
        }

        private ushort oldCarLeft, oldCarRight, oldCarBack;
        private int x, y;

        public Game(Main main) : base(main) {
            map = new ushort[size, size];
            carr = new ushort[size, size];
            oil = new ushort[size, size];
            oiledd = new ushort[size, size];

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
            int offsetX = main.screen.Width / 2 - (size * tileSize) / 2;
            int offsetY = main.screen.Height / 2 - (size * tileSize) / 2;

            tileSize = main.screen.Height / size;

            for (int i = 0; i < main.screen.Width / tileSize; i++)
                for (int j = 0; j < main.screen.Height / tileSize; j++)
                    g.DrawImage(Bundle.wall, i * tileSize, offsetY + j * tileSize, tileSize, tileSize);

            //int offsetCenter = (Width/side)*8

            for (int j = 0; j < size; j++) {
                for (int i = 0; i < size; i++) {

                    //Layer 1
                    if (map[i, j] == (int)tiles.wall)
                        g.DrawImage(Bundle.wall, offsetX + i * tileSize, offsetY + j * tileSize, tileSize, tileSize);
                    else if(map[i, j] == (int)tiles.floor)
                        g.DrawImage(Bundle.floor, offsetX + i * tileSize, offsetY + j * tileSize, tileSize, tileSize);

                    //if (oil[i, j] == (int)tiles.oil)
                        //    g.DrawImage(Bundle.oil[rnd.Next(0,6)], offsetX + i * tileSize, offsetY + j * tileSize, tileSize, tileSize);

                        //if (oiled && oiledd[i, j] == (int)tiles.oilpath)
                        //    g.DrawImage(Bundle.oilpath, offsetX + i * tileSize, offsetY + j * tileSize, tileSize, tileSize);

                        //Layer 2
                     if (carr[i, j] == (int)car.car)
                        g.DrawImage(Bundle.car, offsetX + i * tileSize, offsetY + j * tileSize, tileSize, tileSize);

                }
            }

            roll();

            carr[x, y] = 1;

            if (main.screen.left) {
                carr[x, y] = (int)car.air;
                x--;
                carr[x, y] = (int)car.car;
            } else if (main.screen.right) {
                carr[x, y] = (int)car.air;
                x++;
                carr[x, y] = (int)car.car;
            }

            if(oiled) {
                    int direction = rnd.Next(0,100);
                    if (direction < 20) {
                    
                        if (!main.screen.right) {
                            carr[x, y] = (int)car.air;
                            x--;
                            carr[x, y] = (int)car.car;
                        }
                    
                    } else if(direction > 20 && direction <= 80) {
                        if (!main.screen.left) {
                            carr[x, y] = (int)car.air;
                            x++;
                            carr[x, y] = (int)car.car;
                        }
                    
                }
                
                if (time > 0) {
                    time--;
                } else {
                    time = 0;
                    oiled = false;

                    for (int i = 0; i < size; i++)
                        for (int j = 0; j < size; j++)
                            oiledd[j, i] = 0;
                }

                oiledd[x, y] = (int)tiles.oilpath;

                if (oil[x, y] == (int)tiles.oil)
                    time += 2;
            }

            if (map[x, y] == (int)tiles.wall) {
                Records recordScene = new Records(main);
                recordScene.score = score;
                main.recordsScene = recordScene;
                currentScene = main.recordsScene;
            }

            
            if(score < int.MaxValue)
                score += 1 + score / 60;

            //if (!oiled && oil[x, y] == (int)tiles.oil) {
            //    oiled = true;
            //    time += 50;
            //}
                

            try {
                g.DrawString($"Score = {score.ToString()}\nOiled = {time}", Bundle.menuFont, Brushes.White, 0, 0);
            } catch (InvalidOperationException e) { }


        }

        private void roll() {
            for (int i = size - 1; i > 0; i--) {
                for (int j = 0; j < size; j++) {
                    map[j, i] = map[j, i - 1];
                    map[j, i - 1] = 1;

                    oil[j, i] = oil[j, i - 1];
                    oil[j, i - 1] = 1;

                    oiledd[j, i] = oiledd[j, i - 1];
                    oiledd[j, i - 1] = 1;
                }
            }
            //If not near the left corner
            wall += rnd.Next(-2, 3);
            wall += rnd.Next(-3, 2);

            for (int j = 0; j < size; j++)
                if(!(j>wall+3 && j <size-wall-3)) {
                    map[j, 0] = (int)tiles.wall;

                    //if (rnd.Next(0, 100) < 3 && wall + 6 < size - wall - 6)
                    //    oil[rnd.Next(wall + 6, size - wall - 6), 0] = (int)tiles.oil;

                }

            

            if (wall < 5)
                wall += rnd.Next(3, 5);
            if (wall > size/2-5)
                wall += rnd.Next(-5, -3);
        }
    }
}
