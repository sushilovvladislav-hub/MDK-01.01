using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Game
{
    internal class World
    {
        private double playerX;
        private double speed;
        private double steeringAngle;
        private double roadCurve;
        private double roadCurveTarget;
        private double roadScroll;
        
        private TrackSegment[] track;
        private double trackPosition;
        private double currentTrackAngle;

        private const double MAX_SPEED = 10.0;
        private const double ACCELERATION = 0.025;
        private const double BRAKE_FORCE = 0.12;
        private const double STEERING_SENSIVITY = 0.025;
        private const double FRICTION = 0.015;

        public double PlayerX => playerX;
        public double Speed => speed;
        public double SteeringAngle => steeringAngle;
        public double RoadCurve => roadCurve;
        public double RoadScroll => roadScroll;

        public World()
        {
            InitializeTrack();
            trackPosition = 0;
        }
        
        private void InitializeTrack()
        {
            track = new TrackSegment[]
            {
                new TrackSegment(1000, 0.0),
                new TrackSegment (500 , 0.5),
                new TrackSegment (500, 0.0),
                new TrackSegment (400, -0.7),
                new TrackSegment (800, 0.5),
            };
        }
        
        public void Update(InputHandler input, double deltaTime) 
        {
            double timeFactor = deltaTime * 60;
            if (timeFactor > 3.0)
                timeFactor = 3.0;

            HandleThrottle(input.ThrottleDirection, timeFactor);

            if (speed > 0.01) 
            {
                HandleSteering(input.SteeringDirection, timeFactor);
            }
            else
            {
                steeringAngle *= 0.9;
            }

            UpdatePosition(timeFactor);
            UpdateTrackPosition(timeFactor);
            UpdateRoadCurve(timeFactor);
            UpdateRoadScroll(timeFactor);
            ClampValues();
        }

        private void HandleThrottle(float throttleDir, double timeFactor) 
        {
            if (throttleDir > 0)
            {
                speed += ACCELERATION * timeFactor;

                if (speed > MAX_SPEED)
                {
                    speed = MAX_SPEED;
                }
            }
            else if (throttleDir < 0)
            {
                speed -= BRAKE_FORCE * timeFactor;
                if (speed < 0)
                {
                    speed = 0;
                }
            }
            else 
            {
                speed *= (1 - FRICTION * timeFactor);
                if (speed < 0.001) 
                {
                    speed = 0;
                }
            }
        }

        private void HandleSteering(float steerDir, double timeFactor) 
        {
            double targetAngle = steerDir * 0.2;
            steeringAngle += (targetAngle - steeringAngle) * 0.1 * timeFactor;

            double maxMove = 0.1 * timeFactor;
            double move = speed * steeringAngle * STEERING_SENSIVITY * timeFactor;
            move = Math.Max(-maxMove, Math.Min(maxMove, move));

            playerX += move;
        }

        private void UpdatePosition(double timeFactor) 
        {
            playerX += roadCurve * speed * 0.01 * timeFactor;
        }

        private void ClampValues() 
        {
            if (playerX < -3) 
                playerX = -3;

            if (playerX > 3) 
               playerX = 3;
            
           if (steeringAngle < -0.5) 
               steeringAngle = -0.5;

           if(steeringAngle > 0.5) 
               steeringAngle = 0.5;
        }

        private void UpdateRoadScroll(double timeFactor)
        {
            roadScroll += speed * 0.5 * timeFactor;            
        }

        private void UpdateRoadCurve(double timeFactor) 
        {
            roadCurveTarget = currentTrackAngle;
            roadCurve += (roadCurveTarget - roadCurve) * 0.05 * timeFactor;
        }

        private void UpdateTrackPosition(double timeFactor)
        {
            trackPosition += speed * 0.5 * timeFactor;

            if (track == null || track.Length == 0)
            {
                currentTrackAngle = 0;
                return;
            }

            double totalLength = 0;
            foreach (var seg in track)
            {
                totalLength += seg.Distance;
            }

            trackPosition %= totalLength;
            if (trackPosition < 0)
            {
                trackPosition += totalLength;
            }

            double accumulated = 0;
            for (int i = 0; i < track.Length; i++)
            {
                var seg = track[i];
                double nextAccumulated = accumulated + seg.Distance;

                if (trackPosition < nextAccumulated)
                {
                    double localPos = (trackPosition - accumulated) / seg.Distance;

                    var next = track[(i + 1) % track.Length];
                    currentTrackAngle = seg.Angle + (next.Angle - seg.Angle) * localPos;
                    break;
                }

                accumulated = nextAccumulated;
            }
        }

    }
}
