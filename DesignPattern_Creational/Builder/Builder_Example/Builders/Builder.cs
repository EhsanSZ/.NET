using Builder_Example.Classes;

namespace Builder_Example.Builders
{
    public abstract class Builder
    {
        protected Product product;
        public Builder()
        {
            product = new Product();
        }

        public abstract void BuildPart1();
        public abstract void BuildPart2();
        public virtual Product GetResult()
        {
            return product;
        }

    }
}
