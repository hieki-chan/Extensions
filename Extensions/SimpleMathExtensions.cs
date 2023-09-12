namespace UnityE.Extensions
{
    public static class SimpleMathExtensions
    {
        public static float Math(this float source, float value, OperationOptions option)
        {
            return (option) switch
            {
                OperationOptions.Change => value,
                OperationOptions.Add => source + value,
                OperationOptions.Subtract => source - value,
                OperationOptions.Multiply => source * value,
                OperationOptions.Divide => source / value,
                _ => -1,
            };
        }
    }
    public enum OperationOptions
    {
        Change,
        Add,
        Subtract,
        Multiply,
        Divide,
    }
}
