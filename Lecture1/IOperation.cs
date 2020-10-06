namespace Lecture1
{
    /// <summary>
    /// Базовый интерфейс бинарной операции над целыми числами.
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// Проверяет, может ли данный экземпляр выполнить бинарную операцию, заданную строкой <paramref name="operation"/>.
        /// </summary>
        /// <param name="operation">Строка, задающая бинарную операцию.</param>
        /// <returns>true, если строка соответствует операции, выполняемой данным объектом; false - иначе.</returns>
        bool IsOperationSupported(string operation);

        /// <summary>
        /// Выполняет бинарную операцию над двумя аргументами.
        /// </summary>
        /// <param name="lhs">Первый операнд.</param>
        /// <param name="rhs">Второй операнд.</param>
        /// <returns>Результат выполнения операции.</returns>
        int Compute(int lhs, int rhs);
    }
}
