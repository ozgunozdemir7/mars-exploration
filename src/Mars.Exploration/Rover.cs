using System;
using System.Collections.Generic;
using System.Linq;

namespace Mars.Exploration
{
    public class Rover
    {
        private Dictionary<string, int> _compass;
        private Position _position;
        private Plateau _plateau;

        public Rover()
        {
            InitializeCompass();
        }

        public string Explore(string plateauInput, string positionInput, string commandInput)
        {
            InitializePosition(positionInput);

            InitializePlateau(plateauInput);

            var commandArray = commandInput.ToCharArray();

            foreach (var command in commandArray)
            {
                ApplyPosition(command);
            }

            var output = CreateOutput();

            return output;
        }

        private string CreateOutput()
        {
            var x = _position.X.ToString();
            var y = _position.Y.ToString();
            var dir = _compass.FirstOrDefault(x => x.Value == _position.Direction).Key;
            var output = $"{x} {y} {dir}";
            return output;
        }

        private void InitializePosition(string positionString)
        {
            var splitedPosition = positionString.Split(' ');

            if (splitedPosition.Length != 3)
            {
                throw new ArgumentException("position input must declare position-x, position-y and direction.",
                    nameof(positionString));
            }

            _position = new Position()
            {
                X = splitedPosition[0].ToInt(),
                Y = splitedPosition[1].ToInt(),
                Direction = _compass.FirstOrDefault(x => x.Key == splitedPosition[2]).Value
            };
        }

        private void InitializePlateau(string plateauInput)
        {
            var splitedPlateau = plateauInput.Split(' ');

            if (splitedPlateau.Length != 2)
            {
                throw new ArgumentException("plateau input must declare length-x and length-y", nameof(plateauInput));
            }

            _plateau = new Plateau()
            {
                X = splitedPlateau[0].ToInt(),
                Y = splitedPlateau[1].ToInt()
            };
        }

        private void InitializeCompass()
        {
            _compass = new Dictionary<string, int>();
            _compass.Add("N", 0);
            _compass.Add("E", 1);
            _compass.Add("S", 2);
            _compass.Add("W", 3);
        }

        private void ApplyPosition(char command)
        {
            switch (command)
            {
                case 'L':
                    _position.Direction += 3;
                    _position.Direction = _position.Direction % 4;
                    break;
                case 'R':
                    _position.Direction += 1;
                    _position.Direction = _position.Direction % 4;
                    break;
                case 'M':
                    ApplyMovement();
                    break;
                default:
                    throw new ArgumentException("wrong command", nameof(command));
            }
        }

        private void ApplyMovement()
        {
            int x, y;

            switch (_position.Direction)
            {
                case 0:
                    y = _position.Y + 1;

                    if (y > _plateau.Y)
                    {
                        throw new ArgumentException("invalid command. out of plateau position.");
                    }

                    _position.Y = y;
                    break;
                case 1:
                    x = _position.X + 1;

                    if (x > _plateau.X)
                    {
                        throw new ArgumentException("invalid command. out of plateau position.");
                    }

                    _position.X = x;
                    break;
                case 2:
                    y = _position.Y - 1;

                    if (y < 0)
                    {
                        throw new ArgumentException("invalid command. out of plateau position.");
                    }

                    _position.Y = y;
                    break;
                case 3:
                    x = _position.X - 1;

                    if (x < 0)
                    {
                        throw new ArgumentException("invalid command. out of plateau position.");
                    }

                    _position.X = x;
                    break;
            }
        }
    }


}
