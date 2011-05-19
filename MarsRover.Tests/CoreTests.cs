using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using MarsRover.Interfaces;
using MarsRover.Core.Factories;
using MarsRover.Objects.Instructions;
using MarsRover.Objects.PositionChecks;

namespace MarsRover.Tests
{
    #region Plateau Factory Tests

    [TestFixture]
    public class when_getting_a_plateau_given_valid_user_input : SpecificationBase
    {
        int _expectedWidth = 6;
        int _expectedHeight = 5;
        string _validUserInput;
        IPlateau _plateau;

        public override void Given()
        {
            this._validUserInput = "6 5";
        }

        public override void When()
        {
            this._plateau = PlateauFactory.GetPlateau(this._validUserInput);
        }

        [Then]
        public void a_plateau_of_correct_width_and_height_is_returned()
        {
            Assert.That(this._plateau.Width, Is.EqualTo(_expectedWidth));
            Assert.That(this._plateau.Height, Is.EqualTo(_expectedHeight));
        }
    }

    [TestFixture]
    public class when_getting_a_plateau_given_user_input_with_wrong_number_of_enough_arguments : SpecificationBase
    {
        string _invalidUserInput;

        public override void Given()
        {
            this._invalidUserInput = "2 4 7";
        }

        public override void When()
        {}

        [Then]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void an_exception_is_thrown()
        {
            PlateauFactory.GetPlateau(this._invalidUserInput);
        }
    }

    [TestFixture]
    public class when_getting_a_plateau_given_user_input_with_correct_number_but_invalid_arguments : SpecificationBase
    {
        string _invalidUserInput;

        public override void Given()
        {
            this._invalidUserInput = "dsf poi";
        }

        public override void When()
        { }

        [Then]
        [ExpectedException(typeof(InvalidCastException))]
        public void an_exception_is_thrown()
        {
            PlateauFactory.GetPlateau(this._invalidUserInput);
        }
    }

    #endregion

    #region Rover Factory Tests

    [TestFixture]
    public class when_getting_a_rover_given_valid_user_input : SpecificationBase
    {
        string _validUserInput;
        IRover _rover;

        public override void Given()
        {
            this._validUserInput = "3 4 N";
        }

        public override void When()
        {
            this._rover = RoverFactory.GetRover(this._validUserInput);
        }

        [Then]
        public void a_rover_with_correct_coordinates_and_cardinal_is_returned()
        {
            Assert.That(_rover.X, Is.EqualTo(3));
            Assert.That(_rover.Y, Is.EqualTo(4));
            Assert.That(_rover.Cardinal, Is.EqualTo(CardinalType.N));
        }
    }

    [TestFixture]
    public class when_getting_a_rover_given_user_input_with_wrong_number_of_arguments : SpecificationBase
    {
        string _inValidUserInput;

        public override void Given()
        {
            this._inValidUserInput = "3";
        }

        public override void When()
        {}

        [Then]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void an_exception_is_thrown()
        {
            RoverFactory.GetRover(this._inValidUserInput);
        }
    }

    [TestFixture]
    public class when_getting_a_rover_given_user_input_with_correct_number_but_invalid_arguments : SpecificationBase
    {
        string _inValidUserInput;

        public override void Given()
        {
            this._inValidUserInput = "3 e 7";
        }

        public override void When()
        { }

        [Then]
        [ExpectedException(typeof(InvalidCastException))]
        public void an_execption_is_thrown()
        {
            RoverFactory.GetRover(this._inValidUserInput);
        }
    }

    #endregion

    #region Instruction Factory Tests

    [TestFixture]
    public class when_getting_an_instruction_given_valid_user_input : SpecificationBase
    {
        string _validUserInput;
        IInstruction _instruction;

        public override void Given()
        {
            this._validUserInput = "mmmlmrrm";
        }

        public override void When()
        {
            this._instruction = InstructionFactory.GetCompositeInstruction(_validUserInput);
        }

        [Then]
        public void a_correct_composite_instruction_is_returned()
        {
            CompositeInstruction ci = ((CompositeInstruction)this._instruction);
            Assert.IsInstanceOf(typeof(CompositeInstruction), this._instruction);
            Assert.IsInstanceOf(typeof(MoveInstruction), ci[0]);
            Assert.IsInstanceOf(typeof(MoveInstruction), ci[1]);
            Assert.IsInstanceOf(typeof(MoveInstruction), ci[2]);
            Assert.IsInstanceOf(typeof(TurnLeftInstruction), ci[3]);
            Assert.IsInstanceOf(typeof(MoveInstruction), ci[4]);
            Assert.IsInstanceOf(typeof(TurnRightInstruction), ci[5]);
            Assert.IsInstanceOf(typeof(TurnRightInstruction), ci[6]);
            Assert.IsInstanceOf(typeof(MoveInstruction), ci[7]);
        }
    }

    [TestFixture]
    public class when_getting_an_instruction_given_invalid_user_input : SpecificationBase
    {
        string _invalidUserInput;

        public override void Given()
        {
            this._invalidUserInput = "mrmmlmp";
        }

        public override void When()
        {}

        [Then]
        [ExpectedException(typeof(InvalidCastException))]
        public void an_exception_is_thrown()
        {
            InstructionFactory.GetCompositeInstruction(this._invalidUserInput);
        }
    }

    #endregion

    #region PositionCheck Factory Tests

    [TestFixture]
    public class when_getting_positionchecks : SpecificationBase
    {
        List<IPositionCheck> _positionChecks;

        public override void Given()
        {}

        public override void When()
        {
            this._positionChecks = PositionCheckFactory.GetPositionChecks();
        }

        [Then]
        public void a_correct_position_check_list_is_returned()
        {
            Assert.IsInstanceOf(typeof(RoverPositionCheck), _positionChecks[0]);
            Assert.IsInstanceOf(typeof(RoverCollisionCheck), _positionChecks[1]);
            Assert.That(_positionChecks.Count, Is.EqualTo(2));
        }
    }

    #endregion
}