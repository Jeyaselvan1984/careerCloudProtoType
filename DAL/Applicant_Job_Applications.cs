//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Applicant_Job_Applications
    {
        public System.Guid Id { get; set; }
        public System.Guid Applicant { get; set; }
        public System.Guid Job { get; set; }
        public System.DateTime Application_Date { get; set; }
        public byte[] Time_Stamp { get; set; }
    
        public virtual Applicant_Profiles Applicant_Profiles { get; set; }
        public virtual Company_Jobs Company_Jobs { get; set; }
    }
}
