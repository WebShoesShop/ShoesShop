//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int transactionId { get; set; }
        public Nullable<System.DateTime> transactionTime { get; set; }
        public Nullable<int> methodId { get; set; }
        public Nullable<decimal> money { get; set; }
        public Nullable<int> userId { get; set; }
    
        public virtual User User { get; set; }
    }
}
