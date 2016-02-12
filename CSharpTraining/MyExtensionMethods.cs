namespace CSharpTraining
{
    public static class MyExtensionMethods
    {
        public static int StringToNumber(this string str)
        {
            int number;
            if (int.TryParse(str, out number))
                return number;
            return 0;
        }

        public static string StringReverse(this string str)
        {
            var cArray = str.ToCharArray();
            var reverse = string.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }

        public static bool IsCaptalized(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return char.IsUpper(s[0]);
        }
    }
}
