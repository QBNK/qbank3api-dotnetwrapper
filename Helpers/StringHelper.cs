namespace QBankApi.Helpers
{
    internal static class StringHelper
    {
        public static string SubString(string text, int length)
        {
            if (!string.IsNullOrWhiteSpace(text) && length > 0)
            {
                return text.Length > length ? text.Substring(0, length) : text;
            }

            return string.Empty;
        }
    }
}