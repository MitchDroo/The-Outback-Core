using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Outback.Tests
{
    [TestFixture]
    public class JsonConverterShould
    {
        [Test]
        public void Serialize_Json()
        {
            var values = new HashSet<ExampleItem>();
            values.Add(new DerivedItemOne());
            values.Add(new DerivedItemTwo());

            var converter = new JsonConverter();

            converter.ToJson(values).Should().Be("[{\"$type\":\"Outback.DerivedItemOne, Outback\",\"AStringValue\":null,\"AnIntValue\":0},{\"$type\":\"Outback.DerivedItemTwo, Outback\",\"AStringValueOne\":null,\"AStringValueTwo\":null,\"AnIntValue\":0,\"ABoolValue\":false}]");
        }

        [Test]
        public void Deserialize_Json()
        {
            var converter = new JsonConverter();

            var json =
                "[{\"$type\":\"Outback.DerivedItemOne, Outback\",\"AStringValue\":null,\"AnIntValue\":0},{\"$type\":\"Outback.DerivedItemTwo, Outback\",\"AStringValueOne\":null,\"AStringValueTwo\":null,\"AnIntValue\":0,\"ABoolValue\":false}]";

            var result = converter.FromJson(json);

            result.Count.Should().Be(2);
            int i = 0;
            foreach (var item in result)
            {
                if (i == 0)
                    item.GetType().Should().Be(typeof(DerivedItemOne));

                if (i == 1)
                    item.GetType().Should().Be(typeof(DerivedItemTwo));

                i++;
            }
        }
    }
}