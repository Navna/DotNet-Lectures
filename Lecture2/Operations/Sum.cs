namespace Lecture2.Operations
{
    /// <summary>
    /// Операция сложения.
    /// </summary>
    public class Sum : IOperation
    {
        /// <summary>
        /// Точка доступа к единственному экземпляру операции.
        /// Подробнее: <a href="https://refactoring.guru/ru/design-patterns/singleton">Singleton</a>.
        /// </summary>
        public static IOperation Instance { get; } = new Sum();

        private Sum() { }

        /// <inheritdoc/>
        public int Compute(int lhs, int rhs)
        {
            return lhs + rhs;
        }
    }
}
