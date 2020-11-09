namespace Lecture2
{
    /// <summary>
    /// Базовый интерфейс бинарной операции над целыми числами.
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// Выполняет бинарную операцию над двумя аргументами.
        /// </summary>
        /// <param name="lhs">Первый операнд.</param>
        /// <param name="rhs">Второй операнд.</param>
        /// <returns>Результат выполнения операции.</returns>
        int Compute(int lhs, int rhs);
    }
}
