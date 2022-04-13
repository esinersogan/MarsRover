using System;

namespace MarsRover
{
    public class Constant
    {
        public class Direction
        {
            public const string North = "N";

            public const string South = "S";

            public const string West = "W";

            public const string East = "E";
        }

        public class Facing
        {
            public readonly static string[] LeftList = { "N", "W", "S", "E" };

            public readonly static string[] RightList = { "N", "E", "S", "W" };
        }
        public class Command
        {
            public const char Right = 'R';

            public const char Left = 'L';

            public const char Forward = 'M';
        }

    }
}