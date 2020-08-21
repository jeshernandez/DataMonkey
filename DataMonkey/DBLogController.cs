
using System;
using System.Collections.Generic;
using System.Data;

namespace DataMonkey
{
    class DBLogController : DataWorker 
    {
        string selectSQL; 

        public List<DBLogModel> GetDBLog(object logid)
        {
            selectSQL = "SELECT DISTINCT LOGID, EVENT_TYPE, APP_NAME, APP_VERSION, LOG_MESSAGE FROM FUTCOMKER.LOGS";

            Console.WriteLine("DEBUG: " + selectSQL); 

            List<DBLogModel> lstDbLogModel = new List<DBLogModel>(); 
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateCommand(selectSQL + " WHERE LOGID = " 
                    + logid, connection))
                {
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if(!reader.IsClosed)
                        {
                            while (reader.Read())
                            {
                                DBLogModel dBLogModel = new DBLogModel();
                                dBLogModel.LogID = (string)reader["LOGID"].ToString();
                                dBLogModel.EventType = (string)reader["EVENT_TYPE"];
                                dBLogModel.AppName = (string)reader["APP_NAME"];
                                dBLogModel.AppVersion = (string)reader["APP_VERSION"];
                                dBLogModel.LogMessage = (string)reader["LOG_MESSAGE"];
                                lstDbLogModel.Add(dBLogModel); 
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Rows Found."); 
                        }

                        reader.Close(); 
                    }
                }

                connection.Close();
                Console.WriteLine("Connection Close."); 
            }

            return lstDbLogModel; 
        }
    }
}
