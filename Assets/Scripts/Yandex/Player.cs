using KiYandexSDK;

public static class Player
{
    public static bool IsAvailbleHint;

    public static void Initialize()
    {
        IsAvailbleHint = (bool)YandexData.Load(nameof(IsAvailbleHint),false);
    }
}
