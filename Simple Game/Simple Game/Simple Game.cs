using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Game
{
    public partial class SimpleGame : Form
    {
        private AssetsManager assets;
        private World world;
        private Renderer renderer;
        private InputHandler input;
        private Timer gameTimer;
        private DateTime lastUpdate = DateTime.Now;

        public SimpleGame()
        {
            InitializeComponent();


            assets = new AssetsManager();
            world = new World();
            renderer = new Renderer(assets, world);
            input = new InputHandler(this);

            gameTimer = new Timer();
            gameTimer.Interval = 16;
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            this.DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e) 
        {
            base.OnPaint(e);
            renderer.Draw(e.Graphics);
        }
        
        private void GameLoop(object sender, EventArgs e) 
        {
            var now = DateTime.Now;
            double deltaTime = (now - lastUpdate).TotalSeconds;
            lastUpdate = now;

            world.Update(input, deltaTime);
            
            this.Invalidate();
        }

        
    }
}
