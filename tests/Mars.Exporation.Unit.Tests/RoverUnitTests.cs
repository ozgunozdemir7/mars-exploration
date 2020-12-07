using System;
using System.Runtime.InteropServices.ComTypes;
using Mars.Exploration;
using Xunit;

namespace Mars.Exporation.Unit.Tests
{
    public class RoverUnitTests
    {
        [InlineData("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
        [InlineData("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
        [Theory]
        public void Explore_Should_Return_Right_Output_For_Given_Inputs(string plateauInput, string positionInput, string commandInput, string output)
        {
            var rover = new Rover();
            var roverExploreOutput = rover.Explore(plateauInput, positionInput, commandInput);
            Assert.Equal(output, roverExploreOutput);
        }

        [Fact]
        public void Explore_Should_Throw_Argument_Exception_When_Position_Is_Out_Of_North_Of_Plateau()
        {
            var rover = new Rover();
            Assert.Throws<ArgumentException>(() => rover.Explore("5 5", "1 2 N", "MMMM"));
        }

        [Fact]
        public void Explore_Should_Throw_Argument_Exception_When_Position_Is_Out_Of_South_Of_Plateau()
        {
            var rover = new Rover();
            Assert.Throws<ArgumentException>(() => rover.Explore("5 5", "1 2 N", "LLMMMM"));
        }

        [Fact]
        public void Explore_Should_Throw_Argument_Exception_When_Position_Is_Out_Of_West_Of_Plateau()
        {
            var rover = new Rover();
            Assert.Throws<ArgumentException>(() => rover.Explore("5 5", "1 2 N", "LMM"));
        }

        [Fact]
        public void Explore_Should_Throw_Argument_Exception_When_Position_Is_Out_Of_East_Of_Plateau()
        {
            var rover = new Rover();
            Assert.Throws<ArgumentException>(() => rover.Explore("5 5", "1 2 N", "RMMMMM"));
        }

        [Fact]
        public void Explore_Should_Throw_Argument_Exception_When_Plateau_Input_Invalid()
        {
            var rover = new Rover();
            Assert.Throws<ArgumentException>(() => rover.Explore("5", "1 2 N", "LMLMLMLMM"));
        }

        [Fact]
        public void Explore_Should_Throw_Argument_Exception_When_Position_Input_Invalid()
        {
            var rover = new Rover();
            Assert.Throws<ArgumentException>(() => rover.Explore("5 5", "1 2", "LMLMLMLMM"));
        }

        [Fact]
        public void Explore_Should_Throw_Argument_Exception_When_Command_Input_Invalid()
        {
            var rover = new Rover();
            Assert.Throws<ArgumentException>(() => rover.Explore("5 5", "1 2 N", "XMLMLMLMM"));
        }
    }
}
