using System;
using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;
using UnityEngine.UI;

public class ConnectingToDB : MonoBehaviour
{
    [SerializeField] private Button _addProductButton;
    [SerializeField] private Button _printProductsButton;
    [SerializeField] private TMP_InputField _prod_name;
    [SerializeField] private TMP_InputField _price;
    private string _connectedString;
    private SqliteConnection _cnn;

    private void Awake()
    {
        _connectedString = "URI=file:" + Application.dataPath + "/db.db";

        _cnn = new SqliteConnection(_connectedString);

        _cnn.Open();

        var cmd = _cnn.CreateCommand();

        string createTable =
            "CREATE TABLE IF NOT EXISTS  prods_table(id INTEGER PRIMARY KEY AUTOINCREMENT, price double, prod_name text);";
        cmd.CommandText = createTable;
        cmd.ExecuteNonQuery();


        _addProductButton.onClick.AddListener(() =>
        {
            string insertProduct =
                $"INSERT INTO prods_table(price, prod_name) values ({Convert.ToDouble(_price.text)}, '{_prod_name.text}')";
            ExecuteCommand(cmd, insertProduct);
        });

        _printProductsButton.onClick.AddListener(() =>
        {
            string printProds = "SELECT * FROM prods_table;";
            cmd.CommandText = printProds;
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt16(0);
                double price = reader.GetDouble(1);
                string name = reader.GetString(2);
                Debug.Log($"\nid : {id}, price: {price}, product name: {name}");
            }
        });
    }

    private void ExecuteCommand(SqliteCommand cmd, string query)
    {
        cmd.CommandText = query;
        cmd.ExecuteNonQuery();
    }

    private void OnDestroy()
    {
        _cnn.Close();
    }
}