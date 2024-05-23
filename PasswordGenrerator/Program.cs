using System.Text;

public class PasswordGenerator
{
    static void Main(string[] args)
    {
        bool exitRequested = false;

        while (!exitRequested)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Length of your password:");
                int passwordLength = Convert.ToInt32(Console.ReadLine());

                string finalPassword = GeneratePassowrd(passwordLength);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Generated Password: {finalPassword}");
                Console.ResetColor();

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Press 'Enter' to restart or 'Escape' to end the Programm");

                var userKey = Console.ReadKey();

                if (userKey.Key == ConsoleKey.Escape)
                    exitRequested = true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occured during the progress! {ex}");
                Console.ResetColor();
                Thread.Sleep(10000);
            }
        }
    }
    static string GeneratePassowrd(int passwordLength)
    {
        StringBuilder passwordBuilder = new StringBuilder();
        Random random = new Random();

        for (int i = 0; i < passwordLength; i++)
        {
            string[] passwordChar = { "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "abcdefghijklmnopqrstuvwxyz", "0123456789", "!@#$%^&*()_+-={}[]|\\:;\"'<>,.?/" };

            string selectedCharset = passwordChar[random.Next(passwordChar.Length)];

            char randomChar = selectedCharset[random.Next(selectedCharset.Length)];

            passwordBuilder.Append(randomChar);
        }
        string password = passwordBuilder.ToString();
        return password;
    }
}