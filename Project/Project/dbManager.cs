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
    public class dbManager
    {
        static String dbFileName;
        static SQLiteConnection m_dbConn;
        static SQLiteCommand m_sqlCmd;

        public static string start ()
        { // необходимо (?) поддерживать в актуальном состоянии структуру созданных таблиц
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

                m_sqlCmd.CommandText = @"CREATE TABLE IF NOT EXISTS Users 
                    (id INTEGER PRIMARY KEY AUTOINCREMENT, LOGIN TEXT, PASSWORD TEXT, NAME TEXT,
                     CLASS INTEGER)";
                m_sqlCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                return "Error: " + ex.Message;
            }
            return "";
        }
        public static DataTable execute(string sqlQuery)
        {
            DataTable dTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
            adapter.Fill(dTable);
            return dTable;
        }
    }
}
