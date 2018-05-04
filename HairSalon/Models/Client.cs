using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private string _name;
    private int _id;

    public Client (string name, int id=0)
    {
      _name = name;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public void Save()
    {

      MySqlConnection conn = DB.Connection();
             conn.Open();

             var cmd = conn.CreateCommand() as MySqlCommand;
             cmd.CommandText = @"INSERT INTO clients (name, stylist_id) VALUES (@ClientName, @StylistId);";

             MySqlParameter name = new MySqlParameter();
             name.ParameterName = "@ClientName";
             name.Value = _name;
             cmd.Parameters.Add(name);

             cmd.ExecuteNonQuery();
             //Interacting with databases eithor: Modifying Data or Retrieving Information
             //ExecuteNonQuery modifies the database by saving
             _id = (int) cmd.LastInsertedId;
             //GATHERS data assigned IDs
             //Explicit Cast --> (int) converts cmd.LastInsertedId to accept long data type (64-bit data)

              conn.Close();
              if (conn != null)
              {
                  conn.Dispose();
              }

    }
  }
