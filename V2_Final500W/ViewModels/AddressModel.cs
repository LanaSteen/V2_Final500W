using V2_Final500W.Models;

namespace V2_Final500W.ViewModels
{
    /// <summary>
    /// This is the model view of Address
    /// </summary>
    public class AddressModel
    {
  
        /// <summary>
        /// This is the adress, where teachers or students are living or studing or teaching. It is nor nullable
        /// </summary>
        public string Address1 { get; set; }

        ///// <summary>
        ///// This refers to type of address1 is it living or educational
        ///// </summary>
        //public AdddressType Adddress1Type { get; set; }
        /// <summary>
        /// This is the second adress, where teachers or students are living or studing or teaching
        /// </summary>
        public string? Address2 { get; set; }

        ///// <summary>
        ///// This refers to type of address2  is it living or educational
        ///// </summary>
        //public AdddressType? Adddress2Type { get; set; }
        public int? StudentId { get; set; }  
        /// <summary>
        /// This refers to the particular student  who has these addresses 
        /// </summary>
     //   public Student? Student { get; set; }
        public int? TeacherId { get; set; }
        /// <summary>
        /// This refers to the particular teacher  who has these addresses 
        /// </summary>
       //  public Teacher? Teacher { get; set; }
    }



}
