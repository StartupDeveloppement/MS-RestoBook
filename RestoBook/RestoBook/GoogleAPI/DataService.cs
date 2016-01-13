using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace RestoBook.GoogleAPI
{
    public class DataService
    {
        public void GetDataFromService(string queryString)
        {
            //try
            //{
            //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(queryString);
            //    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //    {
            //        Stream receiveStream = response.GetResponseStream();
            //        StreamReader readStream = new StreamReader(receiveStream);
            //        string responseText = readStream.ReadToEnd();
                    
            //    }
            //}
            //catch(Exception e)
            //{
            //    return;
            //}
        }
    }
}