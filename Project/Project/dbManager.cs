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
        static String dbFileName; // имя файла БД
        static SQLiteConnection m_dbConn; // вспомогательные переменные для хранения состояния соединения
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
				// в этой части можно сделать первичное наполнение таблиц. Сейчас этого функционала нет
                /*m_sqlCmd.CommandText = @"CREATE TABLE IF NOT EXISTS User_sdim 
                    (UK INTEGER PRIMARY KEY AUTOINCREMENT, LOGIN TEXT UNIQUE, PASSWORD TEXT, NAME TEXT,
                     CLASS INTEGER, GRANT_UK INTEGER)";
                m_sqlCmd.ExecuteNonQuery();*/
            }
            catch (SQLiteException ex)
            { // Если не вышло установить соединение, ловим исключение
                return "Error: " + ex.Message;
            }
            return "";
        }
        public static DataTable Execute(string sqlQuery)
        { // метод, возвращающий таблицу, как результат sql-запроса
            DataTable dTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
            adapter.Fill(dTable);
            return dTable;
        }
        public static void ExecuteNonQ(string sqlQuery)
        { // метод, выполняющий sql-запрос, который ничего не возвращает
            m_sqlCmd.CommandText = sqlQuery;
            m_sqlCmd.ExecuteNonQuery();
        }
    }
}
