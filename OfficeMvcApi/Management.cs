//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OfficeMvcApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
  //  using System.OfficeMvcApi.Web.dll;
        [Serializable()]
    public partial class Management
    {
        public int Id { get; set; }
         [Display(Name = "Sponsored Amount")]
        public int SponsoredAmount { get; set; }
        [Display(Name = "Total Sold Amount")]

        public int SellingAmount { get; set; }
        [Display(Name = "Employee Salary")]

        public int EmpId { get; set; }
         [Display(Name = "Clark Salary")]

        public int ClarkId { get; set; }
            [Display(Name = "Month For Bills Cost")]

        public int BillId { get; set; }
            [Display(Name = "Month For Additional Cost")]

        public int AdditionalId { get; set; }
        public Nullable<int> Profit { get; set; }
    
        public virtual Additional Additional { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual Clark Clark { get; set; }
        public virtual Employee Employee { get; set; }
    }
}