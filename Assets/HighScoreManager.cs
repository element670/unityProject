using UnityEngine;
using System;
using System.Data;
using System.Data.Common;
using Mono.Data.Sqlite;

public class HighScoreManager : MonoBehaviour
{
    private string _connectionString;

    private void Start()
    {
        _connectionString = "URI=file:" + Application.dataPath + "/peopleDB.sqlite";

        // using (SqliteConnection connection = new SqliteConnection(_connectionString))
        // {
        //     connection.Open();
        //     SqliteCommand command = connection.CreateCommand();
        //     command.CommandText = "create table if not exists teacher(id integer primary key autoincrement, name text);";
        //     command.ExecuteNonQuery();
        //
        //
        //     command.CommandText = "insert into teacher(name) values ('Mike');";
        //     command.ExecuteNonQuery();
        //     var reader = command.ExecuteReader();
        //     Debug.Log(reader.GetName(0) + " " + reader.GetName(1));
        // }
        IDbConnection dbConnection = new SqliteConnection(_connectionString);
        dbConnection.Open();
        
        IDbCommand dbCommand = new SqliteCommand();
        dbCommand.CommandText = "create table if not exists students(id integer primary key autoincrement, studentName text, gender text);";
        dbCommand.ExecuteScalar();
        dbConnection.Close();
    }
}