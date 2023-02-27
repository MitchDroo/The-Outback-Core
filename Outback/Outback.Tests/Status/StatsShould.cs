using FluentAssertions;
using NUnit.Framework;
using Outback.Status;

namespace Outback.Tests.Status
{
    [TestFixture]
    public class StatsShould
    {
        [Test]
        public void Add_Stat()
        {
            var stats = new Stats();

            var stat = new Stat("Stat", 1, 2);
            stats.Add(stat);

            var enumerator = stats.GetEnumerator();
            enumerator.MoveNext();
            enumerator.Current.Should().Be(stat);

            enumerator.Dispose();
        }

        [Test]
        public void Add_Stat_Given_Name_And_Value()
        {
            var stats = new Stats();

            stats.Add("Stat", 1);

            var enumerator = stats.GetEnumerator();
            enumerator.MoveNext();
            var stat = enumerator.Current;
            stat.Name.Should().Be("Stat");
            stat.Value.Should().Be(1);
            stat.Max.Should().Be(1);

            enumerator.Dispose();
        }

        [Test]
        public void Add_Stat_Given_Name_And_Value_And_Max()
        {
            var stats = new Stats();
            
            stats.Add("Stat", 1, 2);
            
            var enumerator = stats.GetEnumerator();
            enumerator.MoveNext();
            var stat = enumerator.Current;
            stat.Name.Should().Be("Stat");
            stat.Value.Should().Be(1);
            stat.Max.Should().Be(2);
            
            enumerator.Dispose();
        }

        [Test]
        public void Get_Stat_Using_Indexer_Given_Name()
        {
            var stats = new Stats();
            var stat = new Stat("Stat", 1, 2);
            stats.Add(stat);

            var foundStat = stats["Stat"];
            foundStat.Should().Be(stat);
        }

        [Test]
        public void Set_Stat_Using_Indexer_If_It_Exists()
        {
            var stats = new Stats();
            var stat = new Stat("Stat", 1, 2);
            stats.Add(stat);

            var updatedStat = new Stat("Stat", 2, 4);
            stats["Stat"] = updatedStat;

            stats["Stat"].Should().BeEquivalentTo(updatedStat);
        }

        [Test]
        public void Do_Nothing_When_Setting_Non_Existent_Stat_Using_Indexer()
        {
            var stats = new Stats();

            stats["Stat"] = new Stat("Stat", 1, 0);

            stats["Stat"].Should().BeNull();
        }

        [Test]
        public void Fill_All_Stats()
        {
            var stats = new Stats();
            stats.Add(new Stat("Stat 1", 1, 2));
            stats.Add(new Stat("Stat 2", 3, 5));
            stats.Add(new Stat("Stat 3", 2, 4));

            stats.Fill();

            var enumerator = stats.GetEnumerator();
            enumerator.MoveNext();
            enumerator.Current.Value.Should().Be(2);

            enumerator.MoveNext();
            enumerator.Current.Value.Should().Be(5);

            enumerator.MoveNext();
            enumerator.Current.Value.Should().Be(4);

            enumerator.Dispose();
        }
    }
}