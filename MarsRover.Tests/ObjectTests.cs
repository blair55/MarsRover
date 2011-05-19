using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using MarsRover.Interfaces;
using MarsRover.Core;
using MarsRover.Core.Factories;
using MarsRover.Objects;
using MarsRover.Objects.Instructions;
using MarsRover.Objects.PositionChecks;

namespace MarsRover.Tests
{
    #region Instruction Tests

    public abstract class given_a_rover_facing_north_at_x_2_and_y_3 : SpecificationBase
    {
        protected IRover Rover;

        public override void Given()
        {
            this.Rover = stub_a<IRover>();
            this.Rover.Cardinal = CardinalType.N;
            this.Rover.X = 2;
            this.Rover.Y = 3;
        }

        public override void When()
        { }
    }

    [TestFixture]
    public class when_move_instruction_is_executed : given_a_rover_facing_north_at_x_2_and_y_3
    {
        MoveInstruction _moveInstruction;
        int _roverEndYPosition = 4;

        public override void Given()
        {
            base.Given();
            this._moveInstruction = new MoveInstruction();
        }

        public override void When()
        {
            this._moveInstruction.Execute(base.Rover);
        }

        [Then]
        public void rover_y_position_will_be_4()
        {
            Assert.That(base.Rover.Y, Is.EqualTo(this._roverEndYPosition));
        }
    }

    [TestFixture]
    public class when_turn_left_instruction_is_executed : given_a_rover_facing_north_at_x_2_and_y_3
    {
        TurnLeftInstruction _turnLeftInstruction;
        CardinalType _roverEndCardinal = CardinalType.W;

        public override void Given()
        {
            base.Given();
            this._turnLeftInstruction = new TurnLeftInstruction();
        }

        public override void When()
        {
            this._turnLeftInstruction.Execute(base.Rover);
        }

        [Then]
        public void rover_cardinal_will_be_West()
        {
            Assert.That(base.Rover.Cardinal, Is.EqualTo(this._roverEndCardinal));
        }
    }

    [TestFixture]
    public class when_turn_right_instruction_is_executed : given_a_rover_facing_north_at_x_2_and_y_3
    {
        TurnRightInstruction _turnRightInstruction;
        CardinalType _roverEndCardinal = CardinalType.E;

        public override void Given()
        {
            base.Given();
            this._turnRightInstruction = new TurnRightInstruction();
        }

        public override void When()
        {
            this._turnRightInstruction.Execute(base.Rover);
        }

        [Then]
        public void rover_cardinal_will_be_East()
        {
            Assert.That(base.Rover.Cardinal, Is.EqualTo(this._roverEndCardinal));
        }
    }

    #endregion

    #region Position Check Tests

    public abstract class given_a_plateau_of_width_5_and_height_5 : SpecificationBase
    {
        protected IPlateau Plateau;
        protected PlateauController PlateauController;

        public override void Given()
        {
            this.Plateau = stub_a<IPlateau>();
            this.Plateau.Width = 5;
            this.Plateau.Height = 5;
        }

        public override void When()
        { }
    }

    [TestFixture]
    public class when_executing_rover_position_check_given_a_rover_outside_platea_X_dimension : given_a_plateau_of_width_5_and_height_5
    {
        RoverPositionCheck _roverPositionCheck;
        IRover _rover;
        int _roverXDimensionOutsidePlateau;
        int _roverYDimension;

        public override void Given()
        {
            base.Given();
            this._roverPositionCheck = new RoverPositionCheck();
            this._roverXDimensionOutsidePlateau = 7;
            this._roverYDimension = 4;
            this._rover = stub_a<IRover>();
            this._rover.X = this._roverXDimensionOutsidePlateau;
            this._rover.Y = this._roverYDimension;

            this._roverPositionCheck.MovedRover = this._rover;
            this._roverPositionCheck.Plateau = base.Plateau;
        }

        public override void When()
        {}

        [Then]
        [ExpectedException(typeof(RoverPositionException))]
        public void an_exception_is_thrown()
        {
            this._roverPositionCheck.Check();
        }
    }

    [TestFixture]
    public class when_executing_rover_position_check_given_a_rover_outside_platea_Y_dimension : given_a_plateau_of_width_5_and_height_5
    {
        RoverPositionCheck _roverPositionCheck;
        IRover _rover;
        int _roverXDimension;
        int _roverYDimensionOutsidePlateau;

        public override void Given()
        {
            base.Given();
            this._roverPositionCheck = new RoverPositionCheck();
            this._roverXDimension = 4;
            this._roverYDimensionOutsidePlateau = 7;
            this._rover = stub_a<IRover>();
            this._rover.X = this._roverXDimension;
            this._rover.Y = this._roverYDimensionOutsidePlateau;

            this._roverPositionCheck.MovedRover = this._rover;
            this._roverPositionCheck.Plateau = base.Plateau;
        }

        public override void When()
        { }

        [Then]
        [ExpectedException(typeof(RoverPositionException))]
        public void an_exception_is_thrown()
        {
            this._roverPositionCheck.Check();
        }
    }

    [TestFixture]
    public class when_executing_rover_collision_check_given_two_rovers_with_same_coordinates : given_a_plateau_of_width_5_and_height_5
    {
        RoverCollisionCheck _roverCollisionCheck;
        IRover _roverA;
        IRover _roverB;
        int _roverXDimension;
        int _roverYDimension;

        public override void Given()
        {
            base.Given();
            this._roverCollisionCheck = new RoverCollisionCheck();
            this._roverXDimension = 2;
            this._roverYDimension = 4;

            this._roverA = stub_a<IRover>();
            this._roverA.Stub(r => r.Id).Return("RoverA");
            this._roverA.X = this._roverXDimension;
            this._roverA.Y = this._roverYDimension;

            this._roverB = stub_a<IRover>();
            this._roverB.Stub(r => r.Id).Return("RoverB");
            this._roverB.X = this._roverXDimension;
            this._roverB.Y = this._roverYDimension;

            this._roverCollisionCheck.MovedRover = this._roverA;
            this._roverCollisionCheck.ExistingRovers = new List<IRover> { this._roverB };
        }

        public override void When()
        {}

        [Then]
        [ExpectedException(typeof(RoverCollisionException))]
        public void an_exception_is_thrown()
        {
            this._roverCollisionCheck.Check();
        }
    }

    [TestFixture]
    public class when_executing_rover_collision_check_given_two_rovers_with_same_coordinates_and_same_id : given_a_plateau_of_width_5_and_height_5
    {
        RoverCollisionCheck _roverCollisionCheck;
        IRover _roverA;
        IRover _roverB;
        int _roverXDimension;
        int _roverYDimension;
        string _roverSharedId = "SharedRoverId";

        public override void Given()
        {
            base.Given();

            this._roverCollisionCheck = new RoverCollisionCheck();
            this._roverXDimension = 2;
            this._roverYDimension = 4;

            this._roverA = stub_a<IRover>();
            this._roverA.Stub(r => r.Id).Return(this._roverSharedId);
            this._roverA.X = this._roverXDimension;
            this._roverA.Y = this._roverYDimension;
            
            this._roverB = stub_a<IRover>();
            this._roverB.Stub(r => r.Id).Return(this._roverSharedId);
            this._roverB.X = this._roverXDimension;
            this._roverB.Y = this._roverYDimension;

            this._roverB.Stub(r => r.Equals(this._roverA)).IgnoreArguments().Return(true);

            this._roverCollisionCheck.MovedRover = this._roverA;
            this._roverCollisionCheck.ExistingRovers = new List<IRover> { this._roverB };
        }

        public override void When()
        {
            this._roverCollisionCheck.Check();
        }

        [Then]
        public void no_exception_is_thrown()
        {
            Assert.That(this._roverA.Id, Is.EqualTo(this._roverB.Id));
        }
    }

    #endregion

    #region Rover Tests

    [TestFixture]
    public class given_a_rover_facing_west_at_x_2_and_y_3 : SpecificationBase
    {
        protected IRover Rover;
        protected int X;
        protected int Y;
        protected CardinalType Cardinal;

        public override void Given()
        {
            this.X = 2;
            this.Y = 3;
            this.Cardinal = CardinalType.W;
            this.Rover = new Rover { X = this.X, Y = this.Y, Cardinal = this.Cardinal };
        }

        public override void When()
        {}

        [Test]
        public void rover_has_an_id()
        {
            Assert.That(this.Rover.Id, Is.Not.Null);
        }
    }

    [TestFixture]
    public class when_rover_moves_in_X_dimension : given_a_rover_facing_west_at_x_2_and_y_3
    {
        private int _newRoverXDimension;
        private bool _eventRaised;

        public override void Given()
        {
            base.Given();

            this._newRoverXDimension = 4;
            this.Rover.OnRoverMoved += new MarsRover.Interfaces.EventArguments.RoverMoveEventHandler(Rover_OnRoverMoved);
        }

        void Rover_OnRoverMoved(object sender, MarsRover.Interfaces.EventArguments.RoverEventArgs e)
        {
            this._eventRaised = true;
        }

        public override void When()
        {
            this.Rover.X = this._newRoverXDimension;
        }

        [Then]
        public void rover_move_event_is_raised()
        {
            Assert.True(this._eventRaised);
        }
    }

    [TestFixture]
    public class when_rover_moves_in_Y_dimension : given_a_rover_facing_west_at_x_2_and_y_3
    {
        private int _newRoverYDimension;
        private bool _eventRaised;

        public override void Given()
        {
            base.Given();

            this._newRoverYDimension = 4;
            this.Rover.OnRoverMoved += new MarsRover.Interfaces.EventArguments.RoverMoveEventHandler(Rover_OnRoverMoved);
        }

        void Rover_OnRoverMoved(object sender, MarsRover.Interfaces.EventArguments.RoverEventArgs e)
        {
            this._eventRaised = true;
        }

        public override void When()
        {
            this.Rover.Y = this._newRoverYDimension;
        }

        [Then]
        public void rover_move_event_is_raised()
        {
            Assert.True(this._eventRaised);
        }
    }

    [TestFixture]
    public class when_asked_for_output_position_text : given_a_rover_facing_west_at_x_2_and_y_3
    {        
        private string _expectedOutputText;
        private string _expectedOutputTextFormat;

        public override void Given()
        {
            base.Given();

            this._expectedOutputTextFormat = "{0} {1} {2}";
            this._expectedOutputText = String.Format(this._expectedOutputTextFormat, this.X, this.Y, this.Cardinal.ToString());
        }

        public override void When()
        {}

        [Test]
        public void rover_output_text_is_correct()
        {
            Assert.That(this.Rover.GetPositionOutput(), Is.EqualTo(this._expectedOutputText));
        }
    }

    [TestFixture]
    public class when_comparing_to_rover_of_same_id : given_a_rover_facing_west_at_x_2_and_y_3
    {
        private IRover _rover;

        public override void Given()
        {
            base.Given();

            this._rover = stub_a<IRover>();
            this._rover.Stub(r => r.Id).Return(base.Rover.Id);
        }

        public override void When()
        {}

        [Then]
        public void rovers_are_equal()
        {
            Assert.True(base.Rover.Equals(this._rover));
        }
    }

    #endregion

    #region Plateau Controller Tests

    public abstract class given_a_plateau_controller_a_stubbed_plateau_a_stubbed_rover_and_stubbed_position_check : SpecificationBase
    {
        protected PlateauController PlateauController;
        protected List<IPositionCheck> StubbedPositionChecks;
        protected IRover StubbedRover;
        protected IPlateau StubbedPlateau;
        protected IInstruction StubbedInstruction;

        public override void Given()
        {
            this.StubbedRover = stub_a<IRover>();
            this.StubbedPlateau = stub_a<IPlateau>();
            this.StubbedInstruction = stub_a<IInstruction>();
            this.StubbedPositionChecks = stub_a<List<IPositionCheck>>();

            this.PlateauController = new PlateauController(this.StubbedPlateau);
            this.PlateauController.PositionChecks = this.StubbedPositionChecks;
            this.StubbedRover.Instruction = this.StubbedInstruction;
        }

        public override void When()
        {}
    }

    public class when_adding_rover_to_plateau_controller : given_a_plateau_controller_a_stubbed_plateau_a_stubbed_rover_and_stubbed_position_check
    {
        public override void Given()
        {
            base.Given();
        }

        public override void When()
        {
            base.PlateauController.ProcessRover(this.StubbedRover);
        }

        [Then]
        public void rover_is_added_to_collection()
        {
            Assert.That(base.PlateauController.Rovers.Count, Is.EqualTo(1));
        }

        [Then]
        public void rover_instruction_is_executed()
        {
            this.StubbedInstruction.AssertWasCalled(i => i.Execute(this.StubbedRover));
        }

        [Then]
        public void check_position_is_called()
        {
            foreach (IPositionCheck positionCheck in this.StubbedPositionChecks)
            {
                positionCheck.AssertWasCalled(c => c.Check());
            }
        }
    }
    
    #endregion
}