using System;
using System.Collections.Generic;
using System.Linq;
using static MarsRover.Constant;

namespace MarsRover
{
    public class Rover
    {
        private int maxX;

        private int maxY;

        private int x;
        public int X
        {
            get { return x; }
            private set { x = value; }
        }

        private int y;
        public int Y
        {
            get { return y; }
            private set { y = value; }
        }

        private string facing;
        public string Facing
        {
            get { return facing; }
            private set { facing = value; }
        }

        private List<char> instructionList = new List<char>();

        public Rover(string facing)
        {
            Facing = facing;
        }

        public Rover(string maxCorner, string position, string instruction = null)
        {
            Int32.TryParse(maxCorner.Split(" ".ToCharArray())[0], out maxX);
            Int32.TryParse(maxCorner.Split(" ".ToCharArray())[1], out maxY);

            Int32.TryParse(position.Split(" ".ToCharArray())[0], out x);
            Int32.TryParse(position.Split(" ".ToCharArray())[1], out y);
            facing = position.Split(" ")[2];

            if (instruction != null)
            {
                instructionList = instruction.ToCharArray().ToList();
            }
        }

        public void TurnLeft()
        {
            int currentFacing = Array.IndexOf(Constant.Facing.LeftList, Facing);
            Facing = Constant.Facing.LeftList[(currentFacing + 1) % 4];
        }

        public void TurnRight()
        {
            int currentFacing = Array.IndexOf(Constant.Facing.RightList, Facing);
            Facing = Constant.Facing.RightList[(currentFacing + 1) % 4];
        }

        public void MakeForward()
        {
            if (Facing == Direction.North)
            {
                Y += 1;
            }
            else if (Facing == Direction.South)
            {
                Y -= 1;
            }
            else if (Facing == Direction.West)
            {
                X -= 1;
            }
            else
            {
                X += 1;
            }
        }

        public void Go()
        {
            instructionList.ForEach(action => FindAction(action).Invoke());
        }

        public Action FindAction(char instruction)
        {
            return new Dictionary<char, Action>()
            {
                {Command.Right, TurnRight },
                {Command.Left, TurnLeft },
                {Command.Forward, MakeForward }
            }[instruction];
        }


    }
}