namespace EasyConsole
{
    public static class Input
    {
        public static int ReadInt(string prompt, int min, int max)
        {
            Output.DisplayPrompt(prompt);
            return ReadInt(min, max);
        }

        public static int ReadInt(int min, int max)
        {
            int value = ReadInt();

            while (value < min || value > max)
            {
                Output.DisplayPrompt("Please enter an integer between {0} and {1} (inclusive)", min, max);
                value = ReadInt();
            }

            return value;
        }

        public static int ReadInt()
        {
            string? input = Console.ReadLine();
            int value;

            while (!int.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an integer");
                input = Console.ReadLine();
            }

            return value;
        }

        public static string ReadString(string prompt)
        {
            Output.DisplayPrompt(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        public static ConsoleKeyInfo ReadKey(string prompt)
        {
            Output.DisplayPrompt(prompt);
            return Console.ReadKey();
        }

        public static bool ReadKeyYesOrNo(string prompt)
        {
            var key = ReadKey($"{prompt} (y/n)").KeyChar;
            return key == 'y';
        }

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, Enum
        {
            Output.WriteLine(prompt);
            Menu menu = new Menu();

            TEnum choice = default;
            foreach (var value in Enum.GetValues<TEnum>())
                menu.Add(value.ToString() ?? string.Empty, () => { choice = value; });
            menu.Display();

            return choice;
        }
    }
}
