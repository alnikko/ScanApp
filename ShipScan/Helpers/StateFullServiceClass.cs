using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ShipScan.Helpers
{
    public class StatefullServiceClass : SCANSHIP.Screen
    {

        #region Private fields
        /// <summary>
        /// This field contains the received session cookie
        /// </summary>
        private string cookie = null;
        #endregion



        #region Private constants
        /// <summary>
        /// Http-Header for the request SessionCookie
        /// </summary>
        private const string REQUESTHEADER_SESSIONCOOKIE = "Cookie";
        /// <summary>
        /// Http-header for the response SessionCookie
        /// </summary>
        private const string RESPONSEHEADER_SESSIONCOOKIE = "Set-cookie";
        #endregion



        #region Private methods
        private void ProcessResponse(System.Net.HttpWebResponse response)
        {
            // Is the cookie present in the response?
            if (response.Headers.Get(RESPONSEHEADER_SESSIONCOOKIE) != null)
            { // Yes
                // Store the cookie
                cookie = response.Headers.Get(RESPONSEHEADER_SESSIONCOOKIE);
            }
        }
        #endregion



        #region Protected overrides
        /// <summary>
        /// This override will tweak the request to allow Session-cookies
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>The tweaked request</returns>
        protected override System.Net.WebRequest GetWebRequest(Uri uri)
        {
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)
            base.GetWebRequest(uri);
            // Is the session cookie cached?
            if (cookie != null)
            { // Yes
                // Add the sessioncookie to the request
                request.Headers.Add(REQUESTHEADER_SESSIONCOOKIE, cookie);
            }
            return request;
        }



        /// <summary>
        /// This override will tweak the response to allow Session-cookies
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected override System.Net.WebResponse
        GetWebResponse(System.Net.WebRequest request)
        {
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)
            base.GetWebResponse(request);
            ProcessResponse(response);
            return response;
        }



        /// <summary>
        /// This override will tweak the response to allow Session-cookies
        /// </summary>
        /// <param name="request"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        protected override System.Net.WebResponse
        GetWebResponse(System.Net.WebRequest request, IAsyncResult result)
        {
            System.Net.HttpWebResponse response =
            (System.Net.HttpWebResponse)base.GetWebResponse(request, result);
            ProcessResponse(response);
            return response;
        }
        #endregion


    }
}
