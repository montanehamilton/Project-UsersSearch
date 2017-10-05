using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using UsersSearch.Users;
using UsersSearch.Users.Services;

namespace UsersSearch.Tests
{
    [TestClass]
    public class UserExtensionsTests
    {
        [TestMethod]
        public void ToUserModelWillCopyAddresses()
        {
            var user = new User
            {
                Addresses = new List<Address>{
                    new Address{ LineOne = "1 LineOne"},
                    new Address{ LineOne = "2 LineOne"}
                }
            };

            var userModel = user.ToUserModel();

            Assert.AreEqual(2, userModel.Addresses.Count);
            Assert.AreEqual("1 LineOne", userModel.Addresses.First().LineOne);
            Assert.AreEqual("2 LineOne", userModel.Addresses.Last().LineOne);
        }

        [TestMethod]
        public void ToUserModelWillGenerateAvatarUrl()
        {
            var user = new User
            {
                Id = Guid.NewGuid()
            };

            var userModel = user.ToUserModel();

            Assert.AreEqual($"/api/Users/{user.Id}/Avatar", userModel.AvatarUrl);
        }

        [TestMethod]
        public void ToUserModelWillCopyFirstName()
        {
            var user = new User
            {
                FirstName = "Bob"
            };

            var userModel = user.ToUserModel();

            Assert.AreEqual(user.FirstName, userModel.FirstName);
        }

        [TestMethod]
        public void ToUserModelWillCopyLastName()
        {
            var user = new User
            {
                LastName = "Smith"
            };

            var userModel = user.ToUserModel();

            Assert.AreEqual(user.LastName, userModel.LastName);
        }

        [TestMethod]
        public void ToUserModelWillCalculateAge()
        {
            var user = new User
            {
                BirthDate = DateTime.Parse("04/06/1975")
            };

            var userModel = user.ToUserModel();

            Assert.AreEqual(DateTime.Now.Year - user.BirthDate.Year, userModel.Age);
        }

        [TestMethod]
        public void ToUserModelWillCopyInterests()
        {
            var user = new User
            {
                Interests = new List<Interest>{
                    new Interest{ Description = "Interest 1"},
                    new Interest{ Description = "Interest 2"}
                }
            };

            var userModel = user.ToUserModel();

            Assert.AreEqual(2, userModel.Interests.Count);
            Assert.AreEqual("Interest 1", userModel.Interests.First().Description);
            Assert.AreEqual("Interest 2", userModel.Interests.Last().Description);
        }
    }
}
