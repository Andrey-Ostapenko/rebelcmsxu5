﻿using NUnit.Framework;
using Rebel.Framework;
using Rebel.Framework.Persistence.Model;
using Rebel.Framework.Persistence.Model.Attribution.MetaData;
using Rebel.Framework.Testing.PartialTrust;

namespace Rebel.Tests.CoreAndFramework.PersistenceModel
{
    [TestFixture]
    public class EntityCollectionTests : AbstractPartialTrustFixture<EntityCollectionTests>
    {
        [Test]
        public void Adding_MultipleEntities_WithEmptyIds_HasCorrectCount()
        {
            // Arrange
            var collection = new EntityCollection<AttributeType>();
            var entity1 = new AttributeType() { Id = HiveId.Empty };
            var entity2 = new AttributeType() { Id = HiveId.Empty };

            // Act
            collection.Add(entity1);
            collection.Add(entity2);

            // Assert
            Assert.AreEqual(2, collection.Count);
            CollectionAssert.Contains(collection, entity1);
            CollectionAssert.Contains(collection, entity2);
        }

        [Test]
        public void Adding_MultipleEntities_WithEmptyIds_ViaAddRange_HasCorrectCount()
        {
            // Arrange
            var collection = new EntityCollection<AttributeType>();
            var entity1 = new AttributeType() { Id = HiveId.Empty };
            var entity2 = new AttributeType() { Id = HiveId.Empty };

            // Act
            collection.AddRange(new[] {entity1, entity2});

            // Assert
            Assert.AreEqual(2, collection.Count);
            CollectionAssert.Contains(collection, entity1);
            CollectionAssert.Contains(collection, entity2);
        }

        public override void TestSetup()
        {
            return;
        }

        public override void TestTearDown()
        {
            return;
        }
    }
}