using FluentAssertions;
using NUnit.Framework;
using Outback.Status;

namespace Outback.Tests.Status
{
    [TestFixture]
    public class StatShould
    {
        private Stat _stat;

        [SetUp]
        public void Setup()
        {
            _stat = new Stat("Stat", 1, 2);
        }

        [Test]
        public void Get_Name()
        {
            _stat.Name.Should().Be("Stat");
        }

        [Test]
        public void Set_Name()
        {
            _stat.Name = "Test";

            _stat.Name.Should().Be("Test");
        }

        [Test]
        public void Get_Value()
        {
            _stat.Value.Should().Be(1);
        }

        [Test]
        public void Set_Value()
        {
            _stat.Value = 2;

            _stat.Value.Should().Be(2);
        }

        [Test]
        public void Set_Value_Does_Not_Go_Below_Zero()
        {
            _stat.Value = -1;

            _stat.Value.Should().Be(0);
        }

        [Test]
        public void Set_Value_Does_Not_Exceed_Max()
        {
            _stat.Value = 3;

            _stat.Value.Should().Be(2);
        }
        
        [Test]
        public void Get_Max()
        {
            _stat.Max.Should().Be(2);
        }

        [Test]
        public void Set_Max()
        {
            _stat.Max = 10;

            _stat.Max.Should().Be(10);
        }

        [Test]
        public void Set_Value_To_Max_When_Fill()
        {
            _stat.Fill();

            _stat.Value.Should().Be(_stat.Max);
        }

        [Test]
        public void Set_Value_To_Zero_When_Empty()
        {
            _stat.Empty();

            _stat.Value.Should().Be(0);
        }

        [Test]
        public void Increase_Max_By_Percentage()
        {
            _stat.IncreaseBy(1.5f);

            _stat.Max.Should().Be(3);
        }

        [Test]
        public void Decrease_Max_By_Percentage()
        {
            _stat.DecreaseBy(0.5f);

            _stat.Max.Should().Be(1);
        }
    }
}