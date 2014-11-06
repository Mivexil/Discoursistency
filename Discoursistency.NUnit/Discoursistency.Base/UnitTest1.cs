using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discoursistency.Base;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.Posting;
using Discoursistency.Base.Models.Retrieving;
using NUnit.Framework;

namespace Discoursistency.NUnit.Discoursistency.Base
{
    //todo either don't do the testing at a level this low, or use a mock
    //still useful for checking the code out, though.
    [TestFixture]
    public class UnitTest1
    {
        private DiscourseBaseServiceManager _serviceManager;
        private IDiscourseBaseService _service;

        [SetUp]
        public void Initialize()
        {
            _serviceManager = new DiscourseBaseServiceManager();
            _service = _serviceManager.ServiceFor("http://what.thedailywtf.com");
        }

        [TearDown]
        public void Cleanup()
        {
            _service.Dispose();
            _serviceManager.Dispose();
        }

        /*[Test]
        public async Task ShouldProperlyObtainCSRFToken()
        {
            var authData = new AuthenticationData();
            authData = await _service.GetCSRFToken(authData);
            Assert.IsFalse(string.IsNullOrWhiteSpace(authData.CSRFToken));
        }

        [Test]
        public async Task ShouldProperlyLogIn()
        {
            var authData = new AuthenticationData();
            var loginData = new LoginRequestData
            {
                login = "TesterAccount",
                password = "1@3$5^7*"
            };
            authData = await _service.GetCSRFToken(authData);
            authData = await _service.Login(authData, loginData);
            Assert.IsFalse(string.IsNullOrWhiteSpace(authData.Cookie));
        }

        [Test]
        public async Task ShouldCreateTopicInNotRestrictedCategory()
        {
            var authData = new AuthenticationData();
            var loginData = new LoginRequestData
            {
                login = "TesterAccount",
                password = "1@3$5^7*"
            };
            var postData = new PostRequest
            {
                raw = "This is the content of the post.",
                archetype = "regular",
                is_warning = false,
                category = 1,
                title = "Posting procedure test."
            };
            authData = await _service.GetCSRFToken(authData);
            authData = await _service.Login(authData, loginData);
            authData = await _service.GetCSRFToken(authData);
            await _service.CreatePost(authData, postData);
        }

        [Test]
        public async Task ShouldReplyToTopic()
        {
            var authData = new AuthenticationData();
            var loginData = new LoginRequestData
            {
                login = "TesterAccount",
                password = "1@3$5^7*"
            };
            var postData = new PostRequest
            {
                raw = "This is a reply to said post.",
                archetype = "regular",
                is_warning = false,
                category = 1,
                topic_id = 350
            };
            authData = await _service.GetCSRFToken(authData);
            authData = await _service.Login(authData, loginData);
            authData = await _service.GetCSRFToken(authData);
            await _service.CreatePost(authData, postData);
        }

        [Test]
        public async Task ShouldReplyToPost()
        {
            var authData = new AuthenticationData();
            var loginData = new LoginRequestData
            {
                login = "TesterAccount",
                password = "1@3$5^7*"
            };
            var postData = new PostRequest
            {
                raw = "This is another reply to post.",
                archetype = "regular",
                is_warning = false,
                category = 1,
                topic_id = 350,
                reply_to_post_number = 2
            };
            authData = await _service.GetCSRFToken(authData);
            authData = await _service.Login(authData, loginData);
            authData = await _service.GetCSRFToken(authData);
            await _service.CreatePost(authData, postData);
        }*/

        /*[Test]
        public async Task ShouldRetrieveMultiplePostsFromTopic()
        {
            var authData = new AuthenticationData();
            var loginData = new LoginRequestData
            {
                login = "Tester",
                password = "1@3$5^7*"
            };
            var postData = new GetMultiplePostsRequest
            {
                topicId = 3518,
                post_ids = new List<int> { 97880, 97883 }
            };
            authData = await _service.GetCSRFToken(authData);
            authData = await _service.Login(authData, loginData);
            authData = await _service.GetCSRFToken(authData);
            var posts = await _service.GetMultiplePosts(authData, postData);
            Assert.AreEqual(17, posts.post_stream.posts.ElementAt(0).user_id);
        }*/

        //[Test]
        /*public async Task ShouldRetrieveUserData()
        {
            var authData = new AuthenticationData();
            var loginData = new LoginRequestData
            {
                login = "Tester",
                password = "1@3$5^7*"
            };
            var userData = new UserRequest
            {
                username = "accalia"
            };
            authData = await _service.GetCSRFToken(authData);
            authData = await _service.Login(authData, loginData);
            authData = await _service.GetCSRFToken(authData);
            var posts = await _service.GetUserData(authData, userData);
            Assert.AreEqual(10, 10);
        }*/
    }
}
