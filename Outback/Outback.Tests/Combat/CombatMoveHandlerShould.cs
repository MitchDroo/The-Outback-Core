using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Outback.Combat;

namespace Outback.Tests.Combat
{
    [TestFixture]
    public class CombatMoveHandlerShould
    {
        [SetUp]
        public void Setup()
        {
            _combatMoveHandler = new CombatMoveHandler();
            _combatMove1 = Substitute.For<ICombatMove>();
            _combatMove2 = Substitute.For<ICombatMove>();
        }

        private CombatMoveHandler _combatMoveHandler;
        private ICombatMove _combatMove1;
        private ICombatMove _combatMove2;

        [Test]
        public void Start_With_No_Moves_Recorded()
        {
            _combatMoveHandler.IsEmpty().Should().BeTrue();
        }

        [Test]
        public void No_Longer_Be_Empty_After_Recording_One_Combat_Move()
        {
            _combatMoveHandler.Record(_combatMove1);

            _combatMoveHandler.IsEmpty().Should().BeFalse();
        }

        [Test]
        public void Execute_Combat_Move_When_Recording()
        {
            _combatMoveHandler.Record(_combatMove1);

            _combatMove1.Received().Execute();
        }

        [Test]
        public void Undo_Combat_Move_When_Rewinding()
        {
            _combatMoveHandler.Record(_combatMove1);

            _combatMoveHandler.Rewind();

            _combatMove1.Received().Undo();
        }

        [Test]
        public void Be_Empty_When_Rewinding_Last_Recorded_Combat_Move()
        {
            _combatMoveHandler.Record(_combatMove1);

            _combatMoveHandler.Rewind();

            _combatMoveHandler.IsEmpty().Should().BeTrue();
        }

        [Test]
        public void Not_Undo_If_No_Combat_Moves_Recorded()
        {
            _combatMoveHandler.Rewind();

            _combatMove1.DidNotReceive().Undo();
        }

        [Test]
        public void Not_Be_Empty_After_Recording_Two_Moves_And_Undoing_One()
        {
            _combatMoveHandler.Record(_combatMove1);
            _combatMoveHandler.Record(_combatMove2);

            _combatMoveHandler.Rewind();

            _combatMoveHandler.IsEmpty().Should().BeFalse();
        }

        [Test]
        public void Execute_Multiple_Recorded_Moves_In_Order()
        {
            _combatMoveHandler.Record(_combatMove1);
            _combatMoveHandler.Record(_combatMove2);

            _combatMove1.Received().Execute();
            _combatMove2.Received().Execute();
        }

        [Test]
        public void Undo_Last_Recorded_Combat_Move_When_Rewinding()
        {
            _combatMoveHandler.Record(_combatMove1);
            _combatMoveHandler.Record(_combatMove2);

            _combatMoveHandler.Rewind();
            _combatMove2.Received().Undo();
            _combatMove1.DidNotReceive().Undo();

            _combatMoveHandler.Rewind();
            _combatMove1.Received().Undo();
        }
    }
}