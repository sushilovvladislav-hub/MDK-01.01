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

        private void DrawRoad(Graphics g) 
        {
            Bitmap roadTex = assets.GetTexture("Road");
            int segmentCount = 50;

            double curvePower = 1.2;
            double heightFactor = 1.6;
            int horizonOffSet = 295;

            int minWidth = 25;
            int maxWidth = 2000;

            double playerX = world.PlayerX;
            double roadCurve = world.RoadCurve;
            double roadScroll = world.RoadScroll;

            int texHeight = roadTex.Height;
            int texWidth = roadTex.Width;
        
            
            for (int i = segmentCount - 1; i >= 0; i--) 
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
            
            int carWidth = 240;
            int carHeight = 180;

            int carX = SCREEN_WIDTH / 2 + (int)(playerX * 100) - carWidth / 2;
            int carY = SCREEN_HEIGHT - carHeight - 10;

            if (Math.Abs(playerX) > 0.1)
            {
                var state = g.Save();
                g.TranslateTransform(carX + carWidth / 2, carY + carHeight / 2);
                g.RotateTransform((float)(playerX * 0.15));
                g.TranslateTransform(-(carX + carWidth / 2), -(carY + carHeight / 2));
                g.DrawImage(car, carX, carY, carWidth, carHeight);
                g.Restore(state);
            }
            else 
            {
                g.DrawImage(car, carX, carY, carWidth, carHeight);
            }

        }
    }
}
