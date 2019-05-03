using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoutubeSearch;

namespace songla.Controllers
{
    public class LineBotWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        //連接linebot
        const string channelAccessToken = "GmU406k2JC7Y/5OYczPyDiP9xYw0VOO7QDNGVIsYZR3vhipIIfrKYFAZXwSz4DE7KwSx1rk53i6L4LrE9EYj2VFtgq0kp+B29bS9SAcpkNVrK5aBc3L/wwLpa09Dv7Vhl+WYadIFNmIBShddvHSuxAdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "U3ef75842a210b2e15c9851c3b5e9de52";

        [Route("api/LineWebHookSample")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //設定ChannelAccessToken
                this.ChannelAccessToken = channelAccessToken;
                //取得Line Event
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                //回覆訊息
                if (LineEvent.type == "message")
                {
                    if (LineEvent.message.type == "sticker") //收到貼圖
                        this.ReplyMessage(LineEvent.replyToken, 1, 22);
                    
                    if (LineEvent.message.type == "text")   //收到文字
                    {
                        //顯示linebot之對話說明
                        if (LineEvent.message.text == "說明")
                        {
                            this.ReplyMessage(LineEvent.replyToken, "嗨囉 想來點音樂嗎\n (ﾉ>ω<)ﾉ ～♪\n輸入喜歡的歌手或風格\n讓 SongLA 推薦你吧!\n\n你可以說:\n>>我想要聽吳青峰\n>>來首怪美的\n>>推薦抒情歌給我\n>>幫我找修煉愛情歌詞\n想不起來歌名或歌手也可以跟SongLA說歌詞\n>>怎麼會輕易說要結束\n\n趕快說說你想聽什麼吧~");
                        }
                            
                        //搜尋歌曲
                        else
                        {
                            String input = LineEvent.message.text;
                            VideoSearch items = new VideoSearch();
                            List<video> list = new List<video>();

                            //SearchQuery列出搜尋結果
                            foreach (var item in items.SearchQuery(input, 1))
                            {
                                video video = new video();
                                video.keyword = item.Title;
                                video.urllink = item.Url;
                                this.ReplyMessage(LineEvent.replyToken, "推薦這個給你喔 \n" + video.urllink);
                                break;
                            }
                        }
                                                
                    }
                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //如果發生錯誤，傳訊息給Admin
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}
