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

              [Serializable()]

    public partial class Bill
    {
        public Bill()
        {
            this.Managements = new HashSet<Management>();
        }
    
        public int Id { get; set; }
        public int Electricity { get; set; }
        public int Water { get; set; }
        public int Lunch { get; set; }
        public string Month { get; set; }
        public Nullable<int> TotalBills { get; set; }
    
        public virtual ICollection<Management> Managements { get; set; }
    }
}
