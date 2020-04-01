using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticeBoard_Web_API.Model;
using NoticeBoard_Web_API.Models;

namespace NoticeBoard_Web_API.Controllers
{
    //Web API controller for notice management
    [Route("api/[controller]")]
    [ApiController]
    public class NoticesController : ControllerBase
    {
        private readonly NoticeBoard_Web_APIDataContext _context;

        public NoticesController(NoticeBoard_Web_APIDataContext context)
        {
            _context = context;
        }

        // GET: api/Notices
        //Gets all notices using a linq query
        [HttpGet]
        public ActionResult<IEnumerable<Notice>> GetNotice()
        {
            return (from notices in _context.Notice select notices).ToList();
        }

        // GET: api/Notices/5
        //Gets a single notice 
        [HttpGet("{id}")]
        public ActionResult<Notice> GetNotice(int id)
        {
            var notice = _context.Notice.Find(id);

            if (notice == null)
            {
                return NotFound();
            }

            return notice;
        }

        // PUT: api/Notices/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Updates a Notice.
        [HttpPut("{id}")]
        public IActionResult PutNotice(int id, Notice notice)
        {
            if (id != notice.Id)
            {
                return BadRequest();
            }

            _context.Entry(notice).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Notices
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Adds  a Notice 
        [HttpPost]
        public ActionResult<Notice> PostNotice(Notice notice)
        {
            _context.Notice.Add(notice);
             _context.SaveChanges();

            return CreatedAtAction("GetNotice", new { id = notice.Id }, notice);
        }

        // DELETE: api/Notices/5
        //Deletes a Notice from database
        [HttpDelete("{id}")]
        public ActionResult<Notice> DeleteNotice(int id)
        {
            var notice = (from notices in _context.Notice where notices.Id == id select notices).FirstOrDefault();
            if (notice == null)
            {
                return NotFound();
            }

            _context.Notice.Remove(notice);
            _context.SaveChanges();

            return notice;
        }

        //Checks the notice  is available using a lamda 
        private bool NoticeExists(int id)
        {
            return _context.Notice.Any(e => e.Id == id);
        }
    }
}
