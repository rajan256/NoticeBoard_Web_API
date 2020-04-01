using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoticeBoard_Web_API.Model;

namespace NoticeBoard_Web_API.Models
{
    public class NoticeBoard_Web_APIDataContext : DbContext
    {
        public NoticeBoard_Web_APIDataContext (DbContextOptions<NoticeBoard_Web_APIDataContext> options)
            : base(options)
        {
        }

        public DbSet<NoticeBoard_Web_API.Model.Notice> Notice { get; set; }
    }
}
