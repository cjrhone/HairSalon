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
      cmd.CommandText = @"INSERT INTO clients (name) VALUES (@ClientName);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@ClientName";
      name.Value = _name;
      cmd.Parameters.Add(name);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      //Interacting with databases eithor: Modifying Data or Retrieving Information
      //ExecuteNonQuery modifies the database by saving

      //GATHERS data assigned IDs
      //Explicit Cast --> (int) converts cmd.LastInsertedId to accept long data type (64-bit data)
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      //empty list which we will place information from the database
      conn.Open();
      //passes conn to --> database connection
      //open database
      cmd.CommandText = @"SELECT * FROM Clients;";
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      //passes cmd --> MySqlCommand for...
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      //showing all clients from database
      while(rdr.Read())
      //passes rdr --> MySqlCommand to read SQL database
      {
        //rdr.Read() method sends the SQL Commands to the database and collects whatever the database returns in response to those commands
        //While looop will take each row of data returned from the database and perform actions with it
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        //will receive the first column of data, where our Client's id values are stored (index 0)
        Client newItem = new Client(itemDescription, clientId);
        //will receive the second column data, where our Client descriptions are stored (index 1)
        allClients.Add(newItem);
        //instantiate new name with receieved paramaters
      }
      //Add instantiated name into allClients list
      conn.Close();
      if (conn != null)
      //after closing connection we manually confirm whether the connection exists...
      {
        //...If the connection DOES still exist...
        conn.Dispose();
      }
      //...fully clear the connection from memory
      return allClients;
    }
    //otherwise show all clients from database

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      //Creates conn object representing our connection to the database

      //manually opens the connection ( conn ) with conn.Open()
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM Clients;";
      //Define cmd as --> creating command --> MySqlCommand... then...
      cmd.ExecuteNonQuery();
      //...Define CommandText property using SQL statement, which will clear the items table in our database

      //Executes SQL statements that modify data (like deletion)
      conn.Close();
      if (conn != null)
      //Finally, we make sure to close our connection with Close()...
      {
        conn.Dispose();
      }
    }
    //...including an if statement that disposes of the connection if it's not null.

    public override bool Equals(System.Object otherItem)
      {
        if (!(otherClient is Client))
        {
          return false;
        }
        else
        {
          Client newClient = (Client) otherClient;
          bool idEquality = (this.GetId() == newClient.GetId());
          //when we change an object from one type to another, its called "TYPE CASTING"
          bool nameEquality = (this.GetName() == newClient.GetName());
          return (idEquality && nameEquality);
        }
      }

      public static Client Find(int id)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open()

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM 'items' WHERE id = @thisId;";
          //@thisId is the placeholder for the ID property of the Item we're seeking in the database

          MySqlParameter thisId = new MySqlParameter();
          //Create a MySqlParamter called thisId
          thisId.ParameterName = "@thisId";
          //Define ParameterName property as @thisId to match the SQL command
          thisId.Value = id;
          //Define Value property of thisId as id
          cmd.Parameters.Add(thisId);
          //Adds thisId to Parameters property of cmd

          var rdr = cmd.ExecuteReader() as MySqlDataReader;

          int clientId = 0;
          string clientName = "";
          //defined outside of while loop to ensure we don't hit unanticipated errors ( like not being able to define values)

          while (rdr.Read())
          //To initiate reading the database, we run a while loop
          {
            clientId = rdr.GetInt32(0);
            //corresponds to the index positions
            clientName = rdr.GetString(1);

          }

          Client foundClient = new Client(clientName, clientId);

          conn.Close();
          if (conn != null)
          {
            conn.Dispose();
          }

          return foundClient
      }
   }
}
