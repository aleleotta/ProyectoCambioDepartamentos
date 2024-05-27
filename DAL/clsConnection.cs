namespace DAL
{
    public class clsConnection
    {
        public static string getConnection()
        {
            return "server=alessandroleotta.database.windows.net;" +
                "database=alessandroDB;" +
                "Uid=prueba;" +
                "pwd=fernandoG321;" +
                "trustServerCertificate=true";
        }
    }
}
