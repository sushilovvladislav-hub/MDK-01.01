using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Game
{
    internal class InputHandler : IDisposable
    {
        private bool isLeftPressed;
        private bool isRightPressed;
        private bool isAcceleratorPressed;
        private bool isBrakePressed;

        private readonly Form form;

        public bool IsLeftPressed => isLeftPressed;
        public bool IsRightPressed => isRightPressed;
        public bool IsAcceleratedPressed => isAcceleratorPressed;
        public bool IsBrakePressed => isBrakePressed;

        public float SteeringDirection
        {
            get
            {
                if (isLeftPressed && !isRightPressed) return -1f;
                if (isRightPressed && !isLeftPressed) return 1f;
                return 0f;
            }
        }

        public float ThrottleDirection
        {
            get
            {
                if (isAcceleratorPressed && !isBrakePressed) return 1f;
                if (isBrakePressed && !isAcceleratorPressed) return -1f;
                return 0f;
            }
        }


        public InputHandler(Form form) 
        {
            this.form = form;

            form.KeyDown += OnKeyDown;
            form.KeyUp += OnKeyUp;
            form.KeyPreview = true;


            Debug.WriteLine("InputHandler: инициализирован");
        }

        private void OnKeyDown(object sender, KeyEventArgs e) 
        {
            switch (e.KeyCode) 
            {
                case Keys.Left:
                case Keys.A:
                    isLeftPressed = true;
                    break;

                case Keys.Right:
                case Keys.D:
                    isRightPressed = true;
                    break;

                case Keys.Up:
                case Keys.W:
                    isAcceleratorPressed = true;
                    break;

                case Keys.Down:
                case Keys.S:
                    isBrakePressed = true;
                    break;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                    isLeftPressed = false;
                    break;

                case Keys.Right:
                case Keys.D:
                    isRightPressed = false;
                    break;

                case Keys.Up:
                case Keys.W:
                    isAcceleratorPressed = false;
                    break;

                case Keys.Down:
                case Keys.S:
                    isBrakePressed = false;
                    break;
            }
        }

        public void Dispose() 
        {
            if (form != null) 
            {
                form.KeyDown -= OnKeyDown;
                form.KeyUp -= OnKeyUp;
            }

            Debug.WriteLine("InputHandler: ресурсы освобождены");
        }
    }
}
