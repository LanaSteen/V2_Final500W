namespace V2_Final500W.Models
{
    /// <summary>
    /// This is the model of Address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// This is unique/serial Id number of Address (Also PK for this table)
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// This is the adress, where teachers or students are living or studing or teaching
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// This is the second adress, where teachers or students are living or studing or teaching
        /// </summary>
        public string? Address2 { get; set; }

        ///// <summary>
        ///// This refers to type of address1 is it living or educational
        ///// </summary>
        //public AdddressType Adddress1Type { get; set; }
        ///// <summary>
        ///// This refers to type of address2  is it living or educational
        ///// </summary>
        //public AdddressType? Adddress2Type { get; set; }

        /// <summary>
        /// This refers to the particular student id number (from Student table) who has these addresses 
        /// </summary>
        public int? StudentId { get; set; }
        /// <summary>
        /// This refers to the particular student  who has these addresses 
        /// </summary>
        public Student? Student { get; set; }
        /// <summary>
        /// This refers to the particular teacher id number (from teacher table) who has these addresses 
        /// </summary>
        public int? TeacherId { get; set; }
        /// <summary>
        /// This refers to the particular teacher  who has these addresses 
        /// </summary>
        public Teacher? Teacher { get; set; }
    }


}


///// <summary>
///// This is enum for using particular options as the tyoe of the addresses. 
///// </summary>
//public enum AdddressType
//{
//    /// <summary>
//    /// First option living address
//    /// </summary>
//    Living,
//    /// <summary>
//    /// Second option educational address
//    /// </summary>
//    Educational
//}