
using System;
using System.Collections.Generic;

namespace DataMonkey
{
    class Program
    {
        static void Main(string[] args)
        {
            DBLogController dBLog = new DBLogController();

            List<DBLogModel> lstDbLogs = dBLog.GetDBLog("1");

            if(lstDbLogs.Count == 0)
            {
                //Console.WriteLine("No rows found.");
            }
            lstDbLogs.ForEach(el =>
            Console.WriteLine("LOGID: " + el.LogID + " EventType: " + el.EventType)
            );

            SSHConn sshConn = new SSHConn();
            sshConn.listFiles(); 


            Console.WriteLine("App Complete!");
            Console.ReadLine(); 

        }
    }
}
