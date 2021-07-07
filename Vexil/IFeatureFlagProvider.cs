namespace Vexil
{
    public interface IFeatureFlagProvider
    {
        bool IsEnabled(string featureFlag);
    }
}
