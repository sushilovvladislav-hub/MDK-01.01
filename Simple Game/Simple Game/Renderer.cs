using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Game
{
    internal class Renderer
    {
        private readonly AssetsManager assets;
        private readonly World world;

        private const int SCREEN_WIDTH = 800;
        private const int SCREEN_HEIGHT = 600;

        public Renderer(AssetsManager assets, World world)
        {
            this.assets = assets;
            this.world = world;
        }

        public void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;


            DrawSky(g);
            DrawGrass(g);
            DrawRoad(g);
            DrawPlayerCar(g);
        }

        private void DrawSky(Graphics g) 
        {
            Bitmap sky = assets.GetTexture("Sky");

            double playerX = world.PlayerX;
            int skyOffSet = (int)(playerX * 15);

            int skyWidth = SCREEN_WIDTH + 200;
            int skyHeight = SCREEN_HEIGHT / 2;
            


            g.DrawImage(sky, skyOffSet, 0, skyWidth, skyHeight);

            if (skyOffSet < 0)
            {
                g.DrawImage(sky, skyOffSet + skyWidth, 0, skyWidth, skyHeight);
            }
            else if (skyOffSet > 0) 
            {
                g.DrawImage(sky, skyOffSet - skyWidth, 0, skyWidth, skyHeight);
            }
        }

        private void DrawGrass(Graphics g) 
        {
            Bitmap grass = assets.GetTexture("Grass");

            double playerX = world.PlayerX;
            int grassOffSet = (int)(playerX * 15);
            
            int grassWidth = SCREEN_WIDTH + 200;
            int grassHeight = SCREEN_HEIGHT / 2;

            g.DrawImage(grass, grassOffSet, 300, grassWidth, grassHeight);

            if (grassOffSet < 0)
            {
                g.DrawImage(grass, grassOffSet + grassWidth, 300, grassWidth, grassHeight);
            }
            else if (grassOffSet > 0) 
            {
                g.DrawImage(grass, grassOffSet - grassOffSet, 300, grassWidth, grassHeight);
            }
        }

        private void DrawRoad(Graphics g) 
        {
            Bitmap roadTex = assets.GetTexture("Road");
            int segmentCount = 50;

            double curvePower = 1.15;
            double heightFactor = 1.1;
            int horizonOffSet = 300;

            int minWidth = 25;
            int maxWidth = 2000;

            double playerX = world.PlayerX;
            double roadCurve = world.RoadCurve;
            double roadScroll = world.RoadScroll;

            int texHeight = roadTex.Height;
            int texWidth = roadTex.Width;
        
            
            for (int i = 0; i <= segmentCount; i++) 
            {
                double distance = i / (double)segmentCount;
                double t = Math.Pow(distance, curvePower);

                int width = (int)(minWidth + (maxWidth - minWidth) * t);

                double curveOffSet = (playerX * 100 + roadCurve * 50) * (1 - distance);
                int x = (SCREEN_WIDTH - width) / 2 + (int)curveOffSet;

                int y = horizonOffSet + (int)((SCREEN_HEIGHT - horizonOffSet - 45) * Math.Pow(distance, curvePower));
                int height = 5 + (int)(64 * Math.Pow(t, heightFactor));

                int srcY = (int)(roadScroll + i * 5) % texHeight;
                if (srcY < 0)
                    srcY += texHeight;

                Rectangle srcRect = new Rectangle (0, srcY, texWidth, Math.Min(height, texHeight - srcY));
                Rectangle desRect = new Rectangle (x, y, width, height);

                g.DrawImage(roadTex, desRect, srcRect, GraphicsUnit.Pixel);
            }

        }

        private void DrawPlayerCar(Graphics g) 
        {
            Bitmap car = assets.GetTexture("PlayerCar");
            double playerX = world.PlayerX;
            double carTilt = world.SteeringAngle;
            
            int carWidth = 240;
            int carHeight = 180;

            int carX = SCREEN_WIDTH / 2 + (int)(playerX * 100) - carWidth / 2;
            int carY = SCREEN_HEIGHT - carHeight - 10;

            int upShift = (int)(carTilt * 40);
            int bottomShift = (int)(carTilt * 10);
            
            var state = g.Save();

            g.TranslateTransform(carX + carWidth / 2, carY + carHeight / 2);
            g.RotateTransform((float)(carTilt * 2));
            g.TranslateTransform(-(carX + carWidth / 2), -(carY + carHeight / 2));


            Point[] destPoints = new Point[]
            {
                new Point(carX + upShift, carY),
                new Point(carX + carWidth + upShift, carY),
                new Point(carX + bottomShift, carY + carHeight),
            };


            g.DrawImage(car, destPoints);

            g.Restore(state);

        }
        
        
    }
}
