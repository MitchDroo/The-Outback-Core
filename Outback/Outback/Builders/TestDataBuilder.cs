namespace Outback
{
    public abstract class TestDataBuilder<T>
    {
        public static implicit operator T(TestDataBuilder<T> builder) => builder.Build();
        public abstract T Build();
    }
}