using Microsoft.Data.SqlClient;
namespace App.WindowsService
{

    public class Configuration
    {
        public struct Configu { public string Name; public string Value; };
        private List<Configu> configurations = new List<Configu>()
        {
            //initialize configuration with Default-Values
           new Configu{Name="DailyStart", Value = "10:00"},
           new Configu{Name="sftpServer", Value=""},
           new Configu{Name="sftpUser", Value=""},
           new Configu{Name="sftpPass", Value=""},
           new Configu{Name="sftpdestination", Value=@"/html/test"},
           new Configu{Name="sftpsource", Value=@"C:\Evolution\Transfer"}
        };

        public string this[string Name]
        {
            get
            {
                foreach (Configu co in configurations)
                {
                    if (Name == co.Name)
                    {
                        return co.Value;
                    }
                }
                return "";
            }
            set
            {
                for (int c1 = 0; c1 < configurations.Count; c1++)
                {
                    if (configurations[c1].Name == Name)
                    {
                        configurations[c1] = new Configu { Name = Name, Value = value };
                        break;
                    }
                }

            }
        }
    }

    public sealed class FileService
    {
        string pathtoev = @"C:\Evolution\Transfer";
        private static Configuration? config = null;

        //Find Path to config-Folder if exist or create him
        private string getsetConfigPath(string pathtoev)
        {
            string retpathtoev = pathtoev;
            if (!Directory.Exists(pathtoev))
            {
                DirectoryInfo evdir = Directory.CreateDirectory(pathtoev);
                retpathtoev = evdir.FullName;
            }
            if (string.IsNullOrEmpty(pathtoev))
            {
                return retpathtoev;
            }
            return retpathtoev;
        }

        //Get Configuration
        public Configuration getConfig()
        {
            if (config == null)
                config = new Configuration();
            pathtoev = config["sftpsource"];
            pathtoev = getsetConfigPath(pathtoev);
            if (pathtoev == "") return config;
            string pathtoconfigfile = pathtoev + @"\config.txt";
            if (File.Exists(pathtoconfigfile))
            {
                using (StreamReader sr = new StreamReader(pathtoconfigfile))
                {
                    while (!sr.EndOfStream)
                    {
                        string? entry = sr.ReadLine();
                        if (entry != null)
                        {
                            string[] ele = entry.Split('=');
                            if (ele.Length > 1)
                            {
                                config[ele[0]] = ele[1];
                            }

                        }
                    }
                }
            }
            return config;
        }
        //Get a new transfer
        public string GetFile(string evovhs_id = "evovhs_000")
        {
            string fileName = "";
            try
            {
                //connect to Kufer-Datebase
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-LSDFSMU\\SQLEXPRESS02";
                builder.TrustServerCertificate = true;
                builder.IntegratedSecurity = true;
                builder.InitialCatalog = "Kufer4_demo";

                //connect to output-file
                pathtoev = getsetConfigPath(pathtoev);
                fileName = pathtoev + @"\" + evovhs_id;
                fileName += DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".json";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = "SELECT KURZBEZ FROM dbo.KURSE";
                    using (StreamWriter wr = new StreamWriter(fileName))
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    wr.WriteLine("{0} ", reader.GetString(0));
                                }

                            }
                        }
                        //wr.WriteLine("Neuer Eintrag von " + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss"));
                        wr.Flush();
                        wr.Close();
                    }
                    connection.Close();
                    connection.Dispose();
                }
                
                return (fileName);
            }
            catch
            {
                return "";
            }

        }
    }
}
