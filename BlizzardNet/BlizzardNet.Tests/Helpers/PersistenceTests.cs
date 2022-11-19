using System.Collections.Concurrent;
using System.Collections.Generic;
using BlizzardNet.Helpers;
using NUnit.Framework;

namespace BlizzardNet.Tests.Helpers
{
    [TestFixture]
    public class PersistenceTests
    {
        [Test]
        public void CreatePersistence_NotNull()
        {
            // Arrange
            Persistence persistence = Persistence.Instance;
            
            // Act

            // Assert
            Assert.IsNotNull(persistence);
        }
        
        [Test]
        public void CreatePersistence_SameInstance()
        {
            // Arrange
            Persistence persistence = Persistence.Instance;
            Persistence persistence2 = Persistence.Instance;
            
            // Act

            // Assert
            Assert.AreSame(persistence, persistence2);
        }
        
        [Test]
        public void CreatePersistence_CreateTable()
        {
            ConcurrentDictionary<string, List<string>> tables = new ConcurrentDictionary<string, List<string>>
            {
                ["ma_table"] = new List<string>
                {
                    "id INT PRIMARY KEY",
                    "name VARCHAR(255)",
                    "age INT"
                }
            };

            // Arrange
            Persistence persistence = Persistence.Instance;
            
            // Act
            persistence.CreateTable(tables);
            
            // Assert
            Assert.IsTrue(true);
        }
    }
}