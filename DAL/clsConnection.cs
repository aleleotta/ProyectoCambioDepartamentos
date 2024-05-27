namespace DAL
{
    public class clsConnection
    {
        protected string getConnection()
        {
            return "server=alessandroleotta.database.windows.net;" +
                "database=alessandroDB;" +
                "Uid=prueba;" +
                "pwd=fernandoG321;" +
                "trustServerCertificate=true";
        }
    }
}
