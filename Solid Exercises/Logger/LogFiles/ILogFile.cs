

namespace Logger.LogFiles
{
    public interface ILogFile
    {
        void Write(string messaage);
        int Size { get; }
    }
}
