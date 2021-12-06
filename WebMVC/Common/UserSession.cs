using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Common
{
    [Serializable]
    public class UserSession
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}