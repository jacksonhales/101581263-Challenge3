//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Challenge3.API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserModule
    {
        public string Id { get; set; }
        public string MacAddress { get; set; }
        public Nullable<System.DateTime> DateIssued { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Module Module { get; set; }
    }
}
