namespace iDareUI.Common
{
    public interface ILog
    {
        void Info(string s);
        void Debug(string s);
        void Trace(string s);
        void Error(string s);
        void Fatal(string s);
    }
}
