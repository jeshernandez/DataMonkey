using System;
using System.Configuration;
using System.Reflection;

namespace DataMonkey
{
    public sealed class DatabaseFactory
    {
        readonly static DatabaseFactorySectionHandler sectionHandler =
            (DatabaseFactorySectionHandler)ConfigurationManager.GetSection("DatabaseFactoryConfiguration");


    private DatabaseFactory() { }

    public static Database CreateDatabase()
    {
        if(sectionHandler.Name.Length == 0)
        {
            Console.WriteLine("Database name not defined in DatabaseFactoryConfiguration section of app.config.");
        }

        try
        {
            Type database = Type.GetType(sectionHandler.Name);

                ConstructorInfo constructor = database.GetConstructor(new Type[] { });

                Database createObject = (Database)constructor.Invoke(null);

                createObject.connectionString = sectionHandler.ConnectionString;

                return createObject;
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            throw;
        }

     }

    }
}
