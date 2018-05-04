using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=HairSalon_Test;";
        }

       [TestMethod]
       public void GetAll_StylistsEmptyAtFirst_0()
       {
         //Arrange, Act
         int result = Stylist.GetAll().Count;

         //Assert
         Assert.AreEqual(0, result);
       }

       [TestMethod]
        public void GetClients_RetrievesAllClientsWithStylist_ClientList()
        {
          Stylist testStylist = new Stylist("Barbra");
          testStylist.Save();

          Client firstClient = new Client("Joleene", testStylist.GetId());
          firstClient.Save();
          Client secondClient = new Client("Whitney", testStylist.GetId());
          secondClient.Save();


          List<Client> testClientList = new List<Client> {firstClient, secondClient};
          List<Client> resultClientList = testStylist.GetClients();

          CollectionAssert.AreEqual(testClientList, resultClientList);
        }

    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
    }
  }
}
