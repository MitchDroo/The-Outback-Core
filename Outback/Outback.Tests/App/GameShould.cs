using NUnit.Framework;
using Outback.App;

namespace Outback.Tests.App
{
    [TestFixture]
    public class GameShould
    {
        [Test]
        public void Run()
        {
            var game = new Game();

            game.Run();
        }
    }
}