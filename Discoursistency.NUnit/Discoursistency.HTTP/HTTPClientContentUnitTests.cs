using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discoursistency.HTTP.Client;
using Discoursistency.HTTP.Client.Models;
using NUnit.Framework;

namespace Discoursistency.Tests
{

    [TestFixture]
    public class HTTPClientContentUnitTests
    {
        private static HTTPClientContent _content;

        [SetUp]
        public void Initialize()
        {
            _content = new HTTPClientContent();
        }

        [TearDown]
        public void Cleanup()
        {
            _content = null;
        }

        [Test]
        public void ShouldInitiallyBeEmpty()
        {
            Assert.AreEqual(HTTPClientContentType.EmptyType, _content.ContentType);
        }

        [Test]
        public void ShouldBeEmptyAfterSettingNullObject()
        {
            _content = HTTPClientContent.FromObject(null);
            Assert.AreEqual(HTTPClientContentType.EmptyType, _content.ContentType);
        }

        [Test]
        public void ShouldBeAStringAfterSettingString()
        {
            _content = "test";
            Assert.AreEqual(HTTPClientContentType.StringType, _content.ContentType);
        }

        [Test]
        public void ShouldBeAByteArrayAfterSettingByteArray()
        {
            _content = new Byte[] {255};
            Assert.AreEqual(HTTPClientContentType.ByteType, _content.ContentType);
        }

        [Test]
        public void ShouldBeAnObjectAfterSettingObject()
        {
            var o = new {id = 42};
            _content = HTTPClientContent.FromObject(o);
            Assert.AreEqual(HTTPClientContentType.ObjectType, _content.ContentType);
        }

        [Test]
        public void ShouldProperlyRetrieveString()
        {
            _content = "test";
            Assert.IsTrue("test" == _content); //AreEqual requires exact type match
        }

        [Test]
        public void ShouldProperlyRetrieveByteArray()
        {
            var byteArray = new byte[] {1, 2, 3};
            _content = byteArray;
            for (int i = 0; i < byteArray.Length; i++)
            {
                Assert.AreEqual(byteArray[i], ((byte[])_content)[i]);
            }
        }

        private class HasID
        {
            public int Id { get; set; }
        }

        [Test]
        public void ShouldProperlyRetrieveObject()
        {
            var o = new HasID { Id = 42 };
            _content = HTTPClientContent.FromObject(o);
            Assert.IsTrue(o.Id == _content.GetObject<HasID>().Id);
        }

        [Test]
        [ExpectedException(typeof (InvalidCastException))]
        public void ShouldThrowWhenWrongTypeCastedToString()
        {
            var o = new { id = 42 };
            _content = HTTPClientContent.FromObject(o);
            var throwHere = (string) _content;
        }

        [Test]
        [ExpectedException(typeof (InvalidCastException))]
        public void ShouldThrowWhenGettingObjectAndNotAnObject()
        {
            _content = "test";
            var throwHere = _content.GetObject<HasID>();
        }

        [Test]
        public void ShouldReturnEmptyStringWhenEmptyAndToStringCalled()
        {
            Assert.AreEqual(String.Empty, _content.ToString());
        }

        [Test]
        public void ShouldReturnExactContentWhenStringAndToStringCalled()
        {
            _content = "test";
            Assert.AreEqual("test", _content.ToString());
        }

        [Test]
        public void ShouldReturnBase64StringWhenByteArrayAndToStringCalled()
        {
            _content = new Byte[]
            {
                Convert.ToByte('A'),
                Convert.ToByte('B'),
                Convert.ToByte('C')
            };
            Assert.AreEqual("QUJD", _content.ToString());
        }

        [Test]
        public void ShouldDelegateToStringWhenObjectAndToStringCalled()
        {
            _content = HTTPClientContent.FromObject(42);
            Assert.AreEqual("42", _content.ToString());
        }
    }
}
