using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace Project
{
    public class DbManager
    {
        static String dbFileName;
        static SQLiteConnection m_dbConn;
        static SQLiteCommand m_sqlCmd;

        public static string Start ()
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            dbFileName = "dbSQLite";
            
            if (!File.Exists(dbFileName))
                SQLiteConnection.CreateFile(dbFileName);
            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;

                m_sqlCmd.CommandText = @"CREATE TABLE IF NOT EXISTS User 
                    (UK INTEGER PRIMARY KEY AUTOINCREMENT, LOGIN TEXT UNIQUE, PASSWORD TEXT, NAME TEXT,
                     CLASS INTEGER, GRANT_UK INTEGER)";
                m_sqlCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                return "Error: " + ex.Message;
            }
            return "";
        }
        public static DataTable Execute(string sqlQuery)
        {
            DataTable dTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
            adapter.Fill(dTable);
            return dTable;
        }
        public static void ExecuteNonQ(string sqlQuery)
        {
            m_sqlCmd.CommandText = sqlQuery;
            m_sqlCmd.ExecuteNonQuery();
        }
    }
}
