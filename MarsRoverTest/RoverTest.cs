using MarsRover;
using NUnit.Framework;

namespace MarsRoverTest
{
    public class Tests
    {
        [TestCase("N", "E")]
        [TestCase("E", "S")]
        [TestCase("S", "W")]
        [TestCase("W", "N")]
        public void TurnRight(string currentFacing, string nextFacing)
        {
            Rover rover = new Rover(currentFacing);
            rover.TurnRight();
            Assert.AreEqual(nextFacing, rover.Facing);
        }

        [TestCase("N", "W")]
        [TestCase("W", "S")]
        [TestCase("S", "E")]
        [TestCase("E", "N")]
        public void TurnLeft(string currentFacing, string nextFacing)
        {
            Rover rover = new Rover(currentFacing);
            rover.TurnLeft();
            Assert.AreEqual(nextFacing, rover.Facing);
        }

        [TestCase("5 5", "0 0 N", 0, 1)]
        [TestCase("5 5", "5 5 S", 5, 4)]
        [TestCase("5 5", "5 5 W", 4, 5)]
        [TestCase("5 5", "0 0 E", 1, 0)]
        public void MakeForward(string maxCorner, string position, int expectedX, int expectedY)
        {
            Rover rover = new Rover(maxCorner, position);
            rover.MakeForward();
            Assert.AreEqual(expected: expectedX, actual: rover.X);
            Assert.AreEqual(expected: expectedY, actual: rover.Y);
        }

        [TestCase("5 5", "1 2 N", "LMLMLMLMM", 1, 3, "N")]
        [TestCase("5 5", "3 3 E", "MMRMMRMRRM", 5, 1, "E")]
        public void ExecuteInstructions(string maxCorner, string position, string instruction, int expectedX, int expectedY, string expectedFacing)
        {
            Rover rover = new Rover(maxCorner, position, instruction);
            rover.Go();
            Assert.AreEqual(expected: expectedX, actual: rover.X);
            Assert.AreEqual(expected: expectedY, actual: rover.Y);
            Assert.AreEqual(expected: expectedFacing, actual: rover.Facing);
        }
    }
}