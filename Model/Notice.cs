using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoard_Web_API.Model
{
    //Notice record
    public class Notice
    {
        //Notice id
        public int Id { get; set; }

        //Notice title
        public string Title { get; set; }

        //Content of notice
        public string Description { get; set; }

        //Publisher of the notice.
        public string Publisher { get; set; }

    }
}
