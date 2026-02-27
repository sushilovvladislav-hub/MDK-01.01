using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Game
{
    internal struct TrackSegment
    {
        public double Distance;
        public double Angle;

        public TrackSegment(double distance, double angle) 
        {
            Distance = distance;
            Angle = angle;  
        }
    }
}
