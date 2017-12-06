using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniRace.Resources;
using System.Windows.Forms;
using System.Threading;

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
        
        private bool jump = false;
        private bool preJump = false;
        private int jumpTime = 0;
        private int jumpRad = 55;

        ushort pause = (int) pauseState.playing;
        double pauseTime = 5;

        private ushort lives = 5;
        private int destroyRad = 5;

        private int counter = 0, counter2 = -1200;

        Pen p;

        enum pauseState {
            playing,
            pause,
            ready
        }

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

            p = new Pen(Brushes.LightBlue);
            p.DashPattern = new float[] { 1, 1, 1, 5 };
        }

        public override void paint(Graphics g) {

            if (main.screen.enterOnce) {
                if (pause != (int)pauseState.pause && pause != (int)pauseState.ready)
                    pause = (int)pauseState.pause;
                else
                    pause = (int)pauseState.ready;

            }

            if (pause == (int)pauseState.playing) {
                //List<Point> pacmanCords = new List<Point>();
                int offsetX = main.screen.Width / 2 - (size * tileSize) / 2;
                int offsetY = main.screen.Height / 2 - (size * tileSize) / 2;

                offsetY -= tileSize;

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
                        else if (map[i, j] == (int)tiles.floor)
                            g.DrawImage(Bundle.floor, offsetX + i * tileSize, offsetY + j * tileSize, tileSize, tileSize);

                        if (oil[i, j] == (int)tiles.oil)
                            g.DrawImage(Bundle.oil[rnd.Next(0, 6)], offsetX + i * tileSize, offsetY + j * tileSize, tileSize, tileSize);

                        if (oiled && oiledd[i, j] == (int)tiles.oilpath)
                            g.DrawImage(Bundle.oilpath, offsetX + i * tileSize, offsetY + j * tileSize, tileSize, tileSize);

                        if(preJump)
                            g.DrawEllipse(p, (offsetX + x * tileSize) + tileSize / 2 - jumpRad / 2 - 1, (offsetY + y * tileSize) + tileSize / 2 - jumpRad / 2 - 1, jumpRad, jumpRad);

                        //Layer 2
                        if (carr[i, j] == (int)car.car)
                            if (!preJump)
                                g.DrawImage(Bundle.car, offsetX + i * tileSize, offsetY + j * tileSize, tileSize, tileSize);
                            else
                                g.DrawImage(Bundle.carFlying, offsetX + i * tileSize, offsetY + j * tileSize, tileSize, tileSize);


                    }
                }

                roll();


                if (preJump) {
                    if (jumpRad > 10) {
                        jumpRad-=3;
                    } else {
                        jumpRad = 55;
                        jump = true;
                        preJump = false;
                        carr[x, y] = (int)car.air;
                        y += 3;
                        carr[x, y] = (int)car.car;
                        jump = false;
                    }
                }

                carr[x, y] = 1;

                if (main.screen.left && x-1 >= 0 && x < size) {
                    carr[x, y] = (int)car.air;
                    x--;
                    carr[x, y] = (int)car.car;
                } else if (main.screen.right && x >= 0 && x+1 < size) {
                    carr[x, y] = (int)car.air;
                    x++;
                    carr[x, y] = (int)car.car;
                } else if (main.screen.up) {
                    if (!preJump) {
                        carr[x, y] = (int)car.air;
                        y -= 3;
                        carr[x, y] = (int)car.car;
                        preJump = true;
                        jumpTime = 0;
                        jumpRad = 55;
                    }

                }

                for (int i = 0; i < lives; i++)
                    g.DrawImageUnscaled(Bundle.carFlying, i* Bundle.carFlying.Width+50, main.screen.Height-120, Bundle.carFlying.Width, Bundle.carFlying.Height);

                if (oiled) {
                    int direction = rnd.Next(0, 100);
                    if (direction < 20) {

                        if (!main.screen.right && x-1 >= 0 && x < size) {
                            carr[x, y] = (int)car.air;
                            x--;
                            carr[x, y] = (int)car.car;
                        }

                    } else if (direction > 20 && direction <= 80) {
                        if (!main.screen.left && x >= 0 && x+1 < size) {
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
                    if (lives != 0) {
                        lives--;

                        for (int i = -destroyRad; i <= destroyRad; i++)
                            for (int j = -destroyRad; j <= destroyRad; j++)
                                if (x + i >= 0 && x + i < size && y + j >= 0 && y + j < size)
                                    if ((x - x + i) * (x - x + i) + (y - y + j) * (y - y + j) < destroyRad * destroyRad)
                                        //if ( Math.Abs(Math.Sqrt( (x + i - x) * (x + i - x) - (y + j - y) * (y + j - y))) < destroyRad)
                                        map[x + i, y + j] = (int)tiles.floor;

                    } else {
                        Records recordScene = new Records(main);
                        recordScene.score = score;
                        main.recordsScene = recordScene;
                        currentScene = main.recordsScene;
                    }
                }

                if (score < int.MaxValue - (1 + score / 60))
                    score += 1 + score / 600;

                if (!oiled && oil[x, y] == (int)tiles.oil) {
                    oiled = true;
                    time += 50;
                }


                TextRenderer.DrawText(g, $"Score = {score.ToString()}\nOiled = {time}",
                                      Bundle.menuFont,
                                      new Point(16, 30),
                                      Color.White);
            } else if (pause == (int)pauseState.pause) {

                if (counter > -1200)
                    counter -= 5;
                else
                    counter = 0;

                if (counter2 < 0)
                    counter2 += 5;
                else
                    counter2 = -1200;

                g.DrawImageUnscaled(Bundle.backgroundEnd, counter, 0, main.screen.Width, main.screen.Height);
                g.DrawImageUnscaled(Bundle.cloudsEnd, counter2, 0, main.screen.Width, main.screen.Height);

                Utils.Utils.drawString(g, "Pause",
                                       Bundle.menuFont,
                                       Color.FromArgb(84, 153, 84),
                                       main.screen.Width / 2 - 45, main.screen.Height / 2 - 20);
                
            } else {

                if (counter2 > -1200)
                    counter2 -= 12;
                else
                    counter2 = 0;

                if (counter < 0)
                    counter += 12;
                else
                    counter = -1200;

                g.DrawImageUnscaled(Bundle.backgroundEnd, counter, 0, main.screen.Width, main.screen.Height);
                g.DrawImageUnscaled(Bundle.cloudsEnd, counter2, 0, main.screen.Width, main.screen.Height);

                Utils.Utils.drawString(g, $"Get ready at {Math.Round(pauseTime)}",
                                       Bundle.menuFont,
                                       Color.FromArgb(84, 153, 84),
                                       main.screen.Width / 2 - 110, main.screen.Height / 2 - 20);

                if (pauseTime > 1) {
                    pauseTime -= 0.1;
                } else {
                    pause = (int)pauseState.playing;
                    pauseTime = 5;
                }
            }
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

                    if (rnd.Next(0, 100) < 3 && wall + 6 < size - wall - 6)
                        oil[rnd.Next(wall + 6, size - wall - 6), 0] = (int)tiles.oil;

                }

            

            if (wall < 5)
                wall += rnd.Next(3, 5);
            if (wall > size/2-5)
                wall += rnd.Next(-5, -3);
        }
    }
}
