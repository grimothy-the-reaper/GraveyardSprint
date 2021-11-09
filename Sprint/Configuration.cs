using System.IO;

namespace Sprint
{
    public class Configuration
    {
        private static Configuration configuration = null;

        private Configuration()
        {
            string line;
            string[] options;

            string path = @"./QMods/Sprint/config.txt";

            StreamReader file = new StreamReader(path);
            line = file.ReadLine();
            options = line.Split('=');

            IsToggleMode = options[1].Equals("true");
        }

        public static Configuration Instance
        {
            get
            {
                if (configuration == null)
                {
                    configuration = new Configuration();
                }
                return configuration;
            }
        }

        public bool IsToggleMode { get; private set; }
    }
}