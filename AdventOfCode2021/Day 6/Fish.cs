using System;
namespace AdventOfCode2021.Day6
{
    public class Fish
    {
        private int _timer;
        public Fish(int timer)
        {
            _timer = timer;
        }

        public int Timer { get { return _timer; } }
       
        public void DecreaseTimer()
        {
            if (_timer == 0) throw new Exception("can not decrease when 0");
            _timer--;
        }

        public void ResetTimer()
        {
            if (_timer != 0) throw new InvalidOperationException("only reset when 0");
            _timer = 6;
        }
    }
}
