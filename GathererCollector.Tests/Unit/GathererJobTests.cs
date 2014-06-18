using System.Collections.Generic;
using System.Linq;
using Infrastructure.Dto.Card;
using NUnit.Framework;

namespace GathererCollector.Tests.Unit
{
    internal class GathererJobStub : GathererJob
    {
        public new IEnumerable<CardDto> Deserialize(string json)
        {
            return base.Deserialize(json);
        }
    }

    [TestFixture]
    class GathererJobTests
    {
        private GathererJobStub _gathererJob;

        [SetUp]
        public void SetUp()
        {
            _gathererJob = new GathererJobStub();
        }

        [Test]
        public void Deserialize_CardAsJson_ReturnsCardDto()
        {
            // Arrange
            const string json = @"[{""id"":1,""relatedCardId"":0,""setNumber"":6,""name"":""Ankh of Mishra"",""searchName"":""ankhofmishra"",""description"":""Whenever a land enters the battlefield, Ankh of Mishra deals 2 damage to that land's controller."",""flavor"":"""",""colors"":[""None""],""manaCost"":""2"",""convertedManaCost"":2,""cardSetName"":""Limited Edition Alpha"",""type"":""Artifact"",""subType"":null,""power"":0,""toughness"":0,""loyalty"":0,""rarity"":""Rare"",""artist"":""Amy Weber"",""cardSetId"":""LEA"",""token"":false,""promo"":false,""rulings"":[{""releasedAt"":""2004-10-04"",""rule"":""This triggers on any land entering the battlefield. This includes playing a land or putting a land onto the battlefield using a spell or ability.""},{""releasedAt"":""2004-10-04"",""rule"":""It determines the land's controller at the time the ability resolves. If the land leaves the battlefield before the ability resolves, the land's last controller before it left is used.""}],""formats"":[{""name"":""Legacy"",""legality"":""Legal""},{""name"":""Vintage"",""legality"":""Legal""},{""name"":""Freeform"",""legality"":""Legal""},{""name"":""Prismatic"",""legality"":""Legal""},{""name"":""Tribal Wars Legacy"",""legality"":""Legal""},{""name"":""Classic"",""legality"":""Legal""},{""name"":""Singleton 100"",""legality"":""Legal""},{""name"":""Commander"",""legality"":""Legal""}],""releasedAt"":""1993-08-05""}]";

            // Act
            var cards = _gathererJob.Deserialize(json);

            // Assert
            Assert.IsNotEmpty(cards);
            Assert.IsNotEmpty(cards.First().Rulings);
        }
    }
}
