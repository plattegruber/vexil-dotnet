using Vexil.Aggregate;

namespace Vexil
{
    /// <summary>
    ///     Holds context information for the application calling into vexil, e.g.
    ///     the current user
    /// </summary>
    public interface IVexilContext
    {
        /// <summary>
        ///     The Id of the user
        /// </summary>
        UserId UserId { get; set; }
    }
}
