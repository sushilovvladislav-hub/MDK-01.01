using System;

namespace MagicHoroscope
{
    internal class ZodiacSign
    {
        public string Name { get; }
        public string Element { get; }
        public string Description { get; }
        public int StartMonth { get; }
        public int StartDay { get; }
        public int EndMonth { get; }
        public int EndDay { get; }

        public ZodiacSign(string name, string element, string description, int startMonth, int startDay, int endMonth, int endDay)
        {
            Name = name;
            Element = element;
            Description = description;
            StartMonth = startMonth;
            StartDay = startDay;
            EndMonth = endMonth;
            EndDay = endDay;
        }
    }
}
