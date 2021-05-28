namespace IdorpDemo.BL
{
    public class Id<T>
    {
        public T Value { get; }

        public Id(T value)
        {
            Value = value;
        }
    }
}