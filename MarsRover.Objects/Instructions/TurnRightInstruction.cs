﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;

namespace MarsRover.Objects.Instructions
{
    public class TurnRightInstruction : IInstruction
    {
        public void Execute(IRover rover)
        {
            switch (rover.Cardinal)
            {
                case CardinalType.N:
                    rover.Cardinal = CardinalType.E;
                    break;
                case CardinalType.E:
                    rover.Cardinal = CardinalType.S;
                    break;
                case CardinalType.S:
                    rover.Cardinal = CardinalType.W;
                    break;
                case CardinalType.W:
                    rover.Cardinal = CardinalType.N;
                    break;
            }
        }
    }
}