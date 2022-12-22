using Microsoft.AspNetCore.Http;

namespace V2_Final500W.Common
{
    /// <summary>
    /// this is the model of responce
    /// </summary>
    public class Responce
    {

        /// <summary>
        /// this is statuscodes  (Also PK for this table)
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// this is messages depending on statuscodes (-3=System Error,-1=Operation wass completed successfully,-2=Wrong parameters)
        /// </summary>
        public string Message { get; set; }
    }
}


