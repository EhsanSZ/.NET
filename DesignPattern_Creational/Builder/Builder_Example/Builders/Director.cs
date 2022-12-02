
namespace Builder_Example.Builders
{
    public class Director
    {
        private Builder builder;
        public void SetBuilder(Builder builder)
        {
            this.builder = builder;
        }

        public void Construct()
        {
            builder.BuildPart1();
            builder.BuildPart2();
        }
    }
}

