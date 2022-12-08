namespace QuoteRepo.Core.Utils
{
    public static class Message
    {
        public static string NotFound<T>(int id)
        {
            return $"{typeof(T).Name}({id}) not found.";
        }
    }
}
