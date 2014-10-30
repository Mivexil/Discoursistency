﻿using System;
using System.Linq;
using Discoursistency.Base.Models.Retrieving;
using Discoursistency.HTTP.Client.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Discoursistency.Base.Tests
{
    [TestClass]
    public class ModelTranslationTests
    {
        [TestMethod]
        public void PostModelWithRaw()
        {
            var response =
                HTTPClientContent.FromJSONString(
                    @"{""id"":136804,""name"":""' OR 1=1; DROP TABLE TDWTF; --"",""username"":""Maciejasjmj"",""avatar_template"":""/user_avatar/what.thedailywtf.com/maciejasjmj/{size}/1887.png"",""uploaded_avatar_id"":1887,""created_at"":""2014-10-29T10:33:28.507Z"",""cooked"":""<aside class=\""onebox whitelistedgeneric\"">\n  <header class=\""source\"">\n    <a href=\""https://github.com/Mivexil/Discoursistency\"">\n      github.com\n    </a>\n  </header>\n  <article class=\""onebox-body\"">\n    <img src=\""https://avatars0.githubusercontent.com/u/5994816?v=2&amp;s=400\"" class=\""thumbnail\"" width=\""141\"" height=\""141\"">\n\n<h3><a href=\""https://github.com/Mivexil/Discoursistency\"">Mivexil/Discoursistency</a></h3>\n\n<p>Discoursistency - A Discourse API. Now with added sanity.</p>\n\n  </article>\n  <div style=\""clear: both\""></div>\n</aside>\n\n\n<p>Now implemented (somewhat):</p>\n\n<ul>\n<li>logging in</li>\n<li>posting (obviously)</li>\n<li>post actions (like/bookmark/etc)</li>\n<li>removing post actions (apparently that's, like, totally separate)</li>\n<li>editing posts</li>\n<li>deleting posts</li>\n<li>\""reading\"" posts (sending timings)</li>\n<li>also, burst rate-limiting (which would probably be easily extended to proper limiting, but-oh-well)</li>\n</ul>\n\n<p>Todo:<br>- exposing the message bus (a separate thread running longpoll?)<br>- retrieving posts (which ones? how? you can't get more than one raw per request, but cooked is useless for processing, unless you're into stripping HTML and exposing yourself to shitton of abuse)</p>"",""post_number"":1,""post_type"":1,""updated_at"":""2014-10-29T15:17:33.903Z"",""reply_count"":1,""reply_to_post_number"":null,""quote_count"":0,""avg_time"":51,""incoming_link_count"":0,""reads"":59,""score"":79.34999999999999,""yours"":true,""topic_id"":4469,""topic_slug"":""im-doing-a-discourse-api-now-on-github-throw-me-the-features-you-want-also-random-ramblings-thread"",""topic_auto_close_at"":null,""display_username"":""' OR 1=1; DROP TABLE TDWTF; --"",""primary_group_name"":null,""version"":2,""can_edit"":true,""can_delete"":false,""can_recover"":false,""user_title"":""<kbd>XSS Award</kbd>"",""raw"":""https://github.com/Mivexil/Discoursistency\n\nNow implemented (somewhat):\n\n- logging in\n- posting (obviously)\n- post actions (like/bookmark/etc)\n- removing post actions (apparently that's, like, totally separate)\n- editing posts\n- deleting posts\n- \""reading\"" posts (sending timings)\n- also, burst rate-limiting (which would probably be easily extended to proper limiting, but-oh-well)\n\nTodo:\n- exposing the message bus (a separate thread running longpoll?)\n- retrieving posts (which ones? how? you can't get more than one raw per request, but cooked is useless for processing, unless you're into stripping HTML and exposing yourself to shitton of abuse)"",""actions_summary"":[{""id"":2,""count"":2,""hidden"":false,""can_act"":false},{""id"":3,""count"":0,""hidden"":false,""can_act"":true,""can_defer_flags"":false},{""id"":4,""count"":0,""hidden"":false,""can_act"":true,""can_defer_flags"":false},{""id"":5,""count"":0,""hidden"":true,""can_act"":true,""can_defer_flags"":false},{""id"":6,""count"":0,""hidden"":false,""can_act"":false},{""id"":7,""count"":0,""hidden"":false,""can_act"":true,""can_defer_flags"":false},{""id"":8,""count"":0,""hidden"":false,""can_act"":true,""can_defer_flags"":false}],""moderator"":false,""admin"":false,""staff"":false,""user_id"":261,""hidden"":false,""hidden_reason_id"":null,""trust_level"":3,""deleted_at"":null,""user_deleted"":false,""edit_reason"":"""",""can_view_edit_history"":true,""wiki"":false}");
            var model = response.GetObject<PostModelWithRaw>();
            Assert.AreEqual(4, model.actions_summary.ElementAt(2).id);
        }
    }
}
