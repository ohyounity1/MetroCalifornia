namespace Framework.Data.Serialize
{
    /// <summary>
    /// Helper interface which provides interface <see cref="IInSerializer"/> 
    /// and <see cref="IOutSerializer"/> for both reading/writing
    /// </summary>
    public interface IInOutSerializer : IInSerializer, IOutSerializer
    {
    }
}
