//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinMonitorApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class DBIncident
    {
        public string DBIncidentId { get; set; }
        public string DBIncidentName { get; set; }
        public string DBCSId { get; set; }
        public string DBDescription { get; set; }
    
        public virtual DBComponent_With_Status DBComponent_With_Status { get; set; }
    }
}
