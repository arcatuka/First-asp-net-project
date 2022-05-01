using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.UI;
using System.Text;
namespace OnlyFanSite
{
    public class WebMsgBox
    {
        protected static Hashtable handlerPages = new Hashtable();
        public static void Show(String Msg)
        {
            if(!(handlerPages.Contains(HttpContext.Current.Handler)))
            {
                Page currentPage = (Page)HttpContext.Current.Handler;
                if(!((currentPage == null)))
                {
                    Queue messageQueue = new Queue();
                    messageQueue.Enqueue(Msg);
                    handlerPages.Add(HttpContext.Current.Handler, messageQueue);
                    currentPage.Unload += new EventHandler(CurrentPageUnload);
                }    
            }    
        }

        private static void CurrentPageUnload(object sender, EventArgs e)
        {
            Queue queue = ((Queue)(handlerPages[HttpContext.Current.Handler]));
            if(queue != null)
            {
                StringBuilder builder = new StringBuilder();
                int iMsgCount = queue.Count;
                builder.Append("<script language='javascript'>");
                String msg;
                while(iMsgCount > 0)
                {
                    iMsgCount= iMsgCount-1;
                    msg = queue.Dequeue().ToString();
                    msg = msg.Replace("\"", "'");
                    builder.Append("alert(\"" + msg + "\" );");
                }
                builder.Append("</script>");
                handlerPages.Remove(HttpContext.Current.Handler);
                HttpContext.Current.Response.Write(builder.ToString());
            }    

        }
    }
}