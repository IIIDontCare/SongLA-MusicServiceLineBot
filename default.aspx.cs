using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoutubeSearch;

//---------------------------------------- Azure WebHook 控制頁 -----------------------------------------

namespace songla
{
    public partial class _default : System.Web.UI.Page
    {
        const string channelAccessToken = "GmU406k2JC7Y/5OYczPyDiP9xYw0VOO7QDNGVIsYZR3vhipIIfrKYFAZXwSz4DE7KwSx1rk53i6L4LrE9EYj2VFtgq0kp+B29bS9SAcpkNVrK5aBc3L/wwLpa09Dv7Vhl+WYadIFNmIBShddvHSuxAdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "U3ef75842a210b2e15c9851c3b5e9de52";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //向指定使用者推播最新熱門歌曲
        //目前指定為AdminUser
        protected void Button1_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);

            VideoSearch items = new VideoSearch();
            List<video> list = new List<video>();
            foreach (var item in items.SearchQuery("vevo hot", 1))
            {
                video video = new video();
                video.keyword = item.Title;
                video.urllink = item.Url;
                bot.PushMessage(AdminUserId, $"推薦現在超火的給你喔\n ε٩(๑> ₃ <)۶з \n" + video.urllink);
                bot.PushMessage(AdminUserId, 1,28);
                break;
            }
            
        }

        //向指定使用者傳送問候語
        //目前指定為AdminUser
        protected void Button2_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, $"嗨囉 想來點音樂嗎\n (ﾉ>ω<)ﾉ ～♪\n輸入喜歡的歌手或風格\n讓 SongLA 推薦你吧!\n\n你可以說:\n>>我想要聽吳青峰\n>>來首怪美的\n>>推薦抒情歌給我\n>>幫我找修煉愛情歌詞\n想不起來歌名或歌手也可以跟SongLA說歌詞\n>>怎麼會輕易說要結束\n\n趕快說說你想聽什麼吧~");
            bot.PushMessage(AdminUserId, 1,5);
        }
    }
}