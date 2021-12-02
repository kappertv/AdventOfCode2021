namespace AdventOfCode2021.Day2Dive
{
    public class DiveInput
    {
        public enum DirectionEnum
        {
            Forward,
            Down,
            Up
        }

        public DirectionEnum Direction { get; }
        public long Distance { get; }
        public DiveInput(string s)
        {
            var parts = s.Split(" ");
            Distance = long.Parse(parts[1].Trim());
            if (parts[0].StartsWith("for"))
            {
                Direction = DirectionEnum.Forward;
            }
            else if (parts[0].StartsWith("dow"))
            {
                Direction = DirectionEnum.Down;
            }
            else if (parts[0].StartsWith("up"))
            {
                Direction = DirectionEnum.Up;
            }
            else
            {
                throw new System.Exception("input not expected");
            }
        }
    }
}