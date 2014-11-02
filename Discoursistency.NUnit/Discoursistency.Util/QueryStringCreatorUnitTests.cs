using System;
using System.Collections.Generic;
using NUnit.Framework;
using Discoursistency.Util.QueryStringCreator;

namespace Discoursistency.Util.Tests
{
    [TestFixture]
    public class QueryStringCreatorUnitTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowWhenPassedAPrimitiveType()
        {
            QueryStringCreator.QueryStringCreator.ToQueryParameters(42);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void ShouldThrowWhenPassedAString()
        {
            QueryStringCreator.QueryStringCreator.ToQueryParameters("test");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowWhenPassedANullObject()
        {
            QueryStringCreator.QueryStringCreator.ToQueryParameters(null);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void ShouldThrowWhenPassedAList()
        {
            var list = new List<int> {1, 2, 3};
            QueryStringCreator.QueryStringCreator.ToQueryParameters(list);
        }

        [Test]
        public void ShouldProperlyEncodeDictionary()
        {
            var dictionary = new Dictionary<string, object>
            {
                {"t1", 42},
                {"t2", "test"}
            };
            Assert.AreEqual("t1=42&t2=test".ToLower(),
                QueryStringCreator.QueryStringCreator.ToQueryParameters(dictionary));
        }

        [Test]
        public void ShouldProperlyEncodePlainOldCLRObject()
        {
            var pocobject = new
            {
                t1 = 42,
                t2 = "test"
            };
            Assert.AreEqual("t1=42&t2=test".ToLower(),
                QueryStringCreator.QueryStringCreator.ToQueryParameters(pocobject));
        }

        [Test]
        public void ShouldProperlyEncodeArray()
        {
            var wrapperobject = new
            {
                t1 = new[] {"arg1", "arg2", "arg3"}
            };
            Assert.AreEqual("t1%5B%5D=arg1&t1%5B%5D=arg2&t1%5B%5D=arg3".ToLower(),
                QueryStringCreator.QueryStringCreator.ToQueryParameters(wrapperobject));
        }

        [Test]
        public void ShouldProperlyEncodeComplexObjectWithDictionaries()
        {
            //equivalent to following JS object:
            /*
             * { 
             *     val1 : 10, 
             *     val2 : "test", 
             *     val3 : { 
             *             timings : { 
             *                        100 : 214, 
             *                        101 : { 
             *                               testa : 30, 
             *                               testb : "xxx" 
             *                              } 
             *                        } 
             *             } 
             * }
             */
            var testDictionary = new 
            {
                val1 = 10,
                val2 = "test",
                val3 = new Dictionary<string, object>
                {
                    { "timings", new Dictionary<int, object>
                    {
                        {100, 214},
                        {101, new {testa = 30, testb = "xxx"}}
                    }}
                }
            };
            Assert.AreEqual("val1=10&val2=test&val3%5Btimings%5D%5B100%5D=214&val3%5Btimings%5D%5B101%5D%5Btesta%5D=30&val3%5Btimings%5D%5B101%5D%5Btestb%5D=xxx".ToLower(),
                QueryStringCreator.QueryStringCreator.ToQueryParameters(testDictionary).ToLower()
                );
        }

        [Test]
        public void ShouldPercentEncodeDangerousCharacters()
        {
            var wrapperobject = new
            {
                t1 = " <>#%\"{}|\\^[]`;/?:@&=+$,"
            };
            Assert.AreEqual("t1=+%3C%3E%23%25%22%7B%7D%7C%5C%5E%5B%5D%60%3B%2F%3F%3A%40%26%3D%2B%24%2C".ToLower(),
                QueryStringCreator.QueryStringCreator.ToQueryParameters(wrapperobject));
        }

        [Test]
        public void ShouldIgnoreNulls()
        {
            var wrapperobject = new
            {
                t1 = (int?) null,
                t2 = (string) null,
                t3 = (int?) 42
            };
            Assert.AreEqual("t3=42",
                QueryStringCreator.QueryStringCreator.ToQueryParameters(wrapperobject));
        }

        [Test]
        public void ShouldProperlyEncodeTimings()
        {
            var wrapperobject = new
            {
                timings = new Dictionary<int, int>
                {
                    {4, 9052},
                    {5, 9052}
                },
                topic_time = 9052,
                topic_id = 4384
            };
            Assert.AreEqual("timings%5B4%5D=9052&timings%5B5%5D=9052&topic_time=9052&topic_id=4384".ToLower(),
                QueryStringCreator.QueryStringCreator.ToQueryParameters(wrapperobject).ToLower());
        }
    }
}
