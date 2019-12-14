namespace FinalEngine.Platform
{
    public interface IScreenManager
    {
        bool TryGetScreenByIndex(uint index, out Screen screen);
    }
}