using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day6
{
    public class LanternFishSimulator
    {
        //private List<Fish> _fish = new List<Fish>();
        const int maxage = 8;
        private long[] _fastfish;
        private long[] _age = new long[maxage + 1];
        public LanternFishSimulator(string line)
        {
            var initialFish = line.Split(",");
            //_fish = initialFish.Select(f => new Fish(int.Parse(f))).ToList();
            _fastfish = initialFish.Select(f => long.Parse(f)).ToArray();

            foreach (var f in _fastfish)
            {
                _age[f]++;
            }
        }

        public long GetNumberOfFishAfterNDays(int days)
        {
            for (int i =0; i < days; i++)
            {
                long age0 = _age[0];
                for (int j=1;j<=maxage;j++)
                {
                    _age[j - 1] = _age[j];
                    _age[j] = 0;
                }
                _age[8] += age0;
                _age[6] += age0;
            }


            //GrowFishForXDays(days);
            long result = 0;

            for (int j = 0; j <= maxage; j++) result += _age[j];
    
            return result;
        }

        private long GrowFastFishRecursive(long[] fish, int daysAsked, int currentDays)
        {
            if (daysAsked == currentDays)
            {
                return fish.LongLength;
            }
            else
            {
                long bornFish = 0;
                for (int i = 0; i < fish.Length;i++)
                {
                    if (fish[i] == 0)
                    {
                        bornFish++;
                        fish[i] = 6;
                    }
                    else
                    {
                        fish[i] = (fish[i] - 1);
                    }
                }
                for (int i = 0; i < bornFish; i++)
                {
                    fish = fish.Append(8).ToArray();
                }

                var increasedDays = currentDays + 1;

                long result = 0;
                foreach (var f in fish)
                {
                    var oneFishArr = new long[] { f };
                    result = result + GrowFastFishRecursive(oneFishArr, daysAsked, increasedDays);
                }

                return result;
            }
        }

        public long CalculateNumberOfBornFishIncludeParent(long timerOfFish, int daysasked)
        {
            var daysUntilFirst = daysasked - timerOfFish;
            var daysUntilFirstFromChild = daysUntilFirst - 9;

            if (daysUntilFirstFromChild > 0)
            {

            }
 
            var exponent = daysUntilFirst / 7;
            return (long)Math.Pow(2, exponent);
        }
            //private void GrowFishForOneDay()
            //{
            //    var spawningFish = new List<Fish>();
            //    var notYetSpawningFish = new List<Fish>();

            //    foreach (var fish in _fish)
            //    {
            //        if (fish.Timer == 0)
            //        {
            //            spawningFish.Add(fish);
            //        }
            //        else
            //        {
            //            notYetSpawningFish.Add(fish);
            //        }
            //    }

            //    foreach(var notSpawnFish in notYetSpawningFish)
            //    {
            //        notSpawnFish.DecreaseTimer();
            //    }

            //    foreach (var spawnFish in spawningFish)
            //    {
            //        _fish.Add(new Fish(8));
            //        spawnFish.ResetTimer();
            //    }
        // }
    }
}
