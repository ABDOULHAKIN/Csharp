#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TpBlog.Data;
using TpBlog.Models.BO;

namespace TpBlog.Controllers {
    [Authorize]
    public class MessagesController : Controller {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MessagesController(ApplicationDbContext context, UserManager<IdentityUser> userManager) {
            _context = context;
            _userManager = userManager;
        }

        // GET: Messages
        public IActionResult Index() {
            var messages = _context.Messages.Select(m => m);
            if (User.IsInRole("blogger"))
                messages = messages.Where(m => m.Status == MessageStatus.Approved || m.OwnerId == _userManager.GetUserId(User));
            if (User.IsInRole("moderator"))
                messages = messages.Where(m => m.Status == MessageStatus.Submitted || m.OwnerId == _userManager.GetUserId(User));
            return View(messages);
        }

        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.MessageId == id);
            if (message == null) {
                return NotFound();
            }
            if (User.IsInRole("blogger") && message.Status != MessageStatus.Approved && message.OwnerId != _userManager.GetUserId(User) ||
                User.IsInRole("mederator") && message.Status != MessageStatus.Submitted)
                return Forbid();
            return View(message);
        }

        // GET: Messages/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MessageId,Content,CreatedDate,Status,OwnerId")] Message message) {
            if (ModelState.IsValid) {
                message.Status = MessageStatus.Submitted;
                message.OwnerId = _userManager.GetUserId(User);
                message.CreatedDate = DateTime.Now;
                _context.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }

        // GET: Messages/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var message = await _context.Messages.FindAsync(id);
            if (message == null) {
                return NotFound();
            }
            if (message.Status != MessageStatus.Submitted || message.OwnerId != _userManager.GetUserId(User))
                return Forbid();
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MessageId,Content,CreatedDate,Status,OwnerId")] Message message) {
            if (id != message.MessageId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    Message messageBD = _context.Messages.Find(id);
                    if (messageBD.Status != MessageStatus.Submitted || messageBD.OwnerId != _userManager.GetUserId(User))
                        return Forbid();
                    messageBD.Content = message.Content;
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!MessageExists(message.MessageId)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.MessageId == id);
            if (message == null) {
                return NotFound();
            }
            if (message.OwnerId != _userManager.GetUserId(User) && !User.IsInRole("administrator"))
                return Forbid();
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var message = await _context.Messages.FindAsync(id);
            if (message.OwnerId != _userManager.GetUserId(User) && !User.IsInRole("administrator"))
                return Forbid();
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="moderator")]
        public async Task<IActionResult> ApproveOrReject(int id, MessageStatus status) {
            var message = await _context.Messages.FirstOrDefaultAsync(
                                          m => m.MessageId == id);

            if (message == null) {
                return NotFound();
            }

            message.Status = status;
            _context.Messages.Update(message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessageExists(int id) {
            return _context.Messages.Any(e => e.MessageId == id);
        }
    }
}
