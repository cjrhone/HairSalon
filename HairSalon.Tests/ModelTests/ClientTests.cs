using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{

    [TestClass]
    public class ClientTests : IDisposable
    {
      public void Dispose()
      {
        Client.DeleteAll();
      }

      [TestMethod]
      public void GetAll_DbStartsEmpty_0()
      {
        int result = Client.GetAll().Count;

        Assert.AreEqual(0, result);
      }

      [TestMethod]
      public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
      {
        Client firstClient = new Client("James");
        Client secondClient = new Client("James");

        Assert.AreEqual(firstClient, secondClient);
      }

    public ClientTests()
      {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=HairSalon_Test;";
        //connects to our "HairSalon_Test" database
      }
  }
}
