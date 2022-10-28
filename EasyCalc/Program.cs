namespace EasyCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            char userInput = '½';   // assigns random char to make the compiler happy
            History history = History.Instance();   // Gets the History instances
            ProcessInput getCalc = new ProcessInput();

            // keeps the user in a loop so that have to make a choice.
            while (true)
            {

                Titel();   // Gets the titel

                Console.Write("\n1 - Enter a number\n2 - History\n3 - Exit\n"); // Writes the choices the user can make
                
                // Checks user input
                try
                {
                    userInput = Console.ReadKey(true).KeyChar;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                // The user can chose to use the calulator by pressing one, look att the history by pressing two
                // or exit the program by pressing three  
                switch (userInput)
                {
                    case '1':
                        getCalc.Calc();
                        break;

                    case '2':
                        history.List();
                        break;

                    case '3':
                        return;

                }

            }

            //Writes "Welcome To The Calculator" in a Ascii art style to welcome the user.
            void Titel()
            {

                /* _    _      _                            _____       _____ _            _____       _            _       _             
                  | |  | |    | |                          |_   _|     |_   _| |          /  __ \     | |          | |     | |            
                  | |  | | ___| | ___ ___  _ __ ___   ___    | | ___     | | | |__   ___  | /  \/ __ _| | ___ _   _| | __ _| |_ ___  _ __ 
                  | |/\| |/ _ \ |/ __/ _ \| '_ ` _ \ / _ \   | |/ _ \    | | | '_ \ / _ \ | |    / _` | |/ __| | | | |/ _` | __/ _ \| '__|
                  \  /\  /  __/ | (_| (_) | | | | | |  __/   | | (_) |   | | | | | |  __/ | \__/\ (_| | | (__| |_| | | (_| | || (_) | |   
                   \/  \/ \___|_|\___\___/|_| |_| |_|\___|   \_/\___/    \_/ |_| |_|\___|  \____/\__,_|_|\___|\__,_|_|\__,_|\__\___/|_|
                */

                // Uses SetCursorPosition to decide where on the screen it should write the message.
                Console.SetCursorPosition(Console.WindowWidth / 2 - 60, 1);
                Console.WriteLine(@" _    _      _                            _____       _____ _            _____       _            _       _             ");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 60, 2);
                Console.WriteLine(@"| |  | |    | |                          |_   _|     |_   _| |          /  __ \     | |          | |     | |            ");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 60, 3);
                Console.WriteLine(@"| |  | | ___| | ___ ___  _ __ ___   ___    | | ___     | | | |__   ___  | /  \/ __ _| | ___ _   _| | __ _| |_ ___  _ __ ");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 60, 4);
                Console.WriteLine(@"| |/\| |/ _ \ |/ __/ _ \| '_ ` _ \ / _ \   | |/ _ \    | | | '_ \ / _ \ | |    / _` | |/ __| | | | |/ _` | __/ _ \| '__|");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 60, 5);
                Console.WriteLine(@"\  /\  /  __/ | (_| (_) | | | | | |  __/   | | (_) |   | | | | | |  __/ | \__/\ (_| | | (__| |_| | | (_| | || (_) | |   ");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 60, 6);
                Console.WriteLine(@" \/  \/ \___|_|\___\___/|_| |_| |_|\___|   \_/\___/    \_/ |_| |_|\___|  \____/\__,_|_|\___|\__,_|_|\__,_|\__\___/|_|   ");
            }

        }
    }
}
