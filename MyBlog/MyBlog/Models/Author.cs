//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBlog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string UserName { get; set; }
    
        public virtual Post Post { get; set; }
    }
}
