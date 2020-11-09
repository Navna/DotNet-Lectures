namespace Lecture2.Operations
{
    /// <summary>
    /// Операция вычитания.
    /// </summary>
    public class Difference : IOperation
    {
        /// <summary>
        /// Точка доступа к единственному экземпляру операции.
        /// Подробнее: <a href="https://refactoring.guru/ru/design-patterns/singleton">Singleton</a>.
        /// </summary>
        public static IOperation Instance { get; } = new Difference();

        private Difference() { }

        /// <inheritdoc/>
        public int Compute(int lhs, int rhs)
        {
            return lhs - rhs;
        }
    }
}
