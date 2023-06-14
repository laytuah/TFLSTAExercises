using NUnit.Framework;

namespace TFLSTAExercises
{
    public static class EnvironmentData
    {
        public static string baseUrl { get; } = TestContext.Parameters["baseUrl"];
    }
}
