namespace EasyCalc
{
    internal class History
    {

        static History instance; // Creates a History object and set it to static so it can be accessed by the Instance method

        private List<string> historyList = new List<string>();


        protected History() // The History constructor is set to protected so it can't be called upon outside of the class
                            // unless the class is inherited.
        {

        }

        public void List() // Writes out the content inside the "historyList" variable to the console. 
        {
            Console.Clear();

            Console.WriteLine("The history of your previous calculations\n");

            for (int i = 0; i < historyList.Count; i++)
            {
                Console.WriteLine(historyList[i]);
            }

            Console.Write("\nPress any key to go back to the meny.");

            Console.ReadKey(true);

            Console.Clear();
        }


        // Makes the priveted variable "historyList" accessible outside of the class
        // Through the "HistoryList" property.
        public List<string> HistoryList 
        {
            get { return historyList; }
        }
        public static History Instance() // Checks if the History object variable "instance" is null. If it is it creates a new instance of the History class
                                         // then returns the instance 
        {

            if (instance == null)
            {
                instance = new History();
            }

            return instance;

        }

    }
}
