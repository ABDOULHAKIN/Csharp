using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPChats.Models;

namespace TPChats.Controllers {
    public class ChatController : Controller {

        private static List<Chat> meute = Chat.GetMeuteDeChats().OrderByDescending(x => x.Age).ToList();

        // GET: ChatController
        public ActionResult Index() {
            return View(meute);
        }

        // GET: ChatController/Details/5
        public ActionResult Details(int id) {
            Chat? chat = meute.FirstOrDefault(c => c.Id == id);
            var c = meute.Find(c => c.Id == id);
            if(chat == null) return NotFound();
            return View(chat);
        }

        // GET: ChatController/Delete/5
        public ActionResult Delete(int id) {
            Chat? chat = meute.FirstOrDefault(c => c.Id == id);
            if (chat == null) return NotFound();
            return View(chat);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {

                //methode 1
                Chat? chat = meute.FirstOrDefault(c => c.Id == id);
                if (chat == null) return NotFound();
               
                meute.Remove(chat);


                //methode 2
                meute = meute.Where(c =>c.Id != id).ToList();



                //methode 3

                var index = meute.FindIndex(c => c.Id == id);
                meute.RemoveAt(index);

                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }



        // GET: ChatController/Edit/5
        public ActionResult Edit(int id)
        {
            Chat? chat = meute.FirstOrDefault(c => c.Id == id);
            if (chat == null) return NotFound();
            return View(chat);
        }

        // POST: Chat/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Chat chatForm)
        {
            try
            {

                //methode 1
                int chatBddIndex = meute.FindIndex(x => x.Id == id);
                if (chatBddIndex == -1) return NotFound();


                meute[chatBddIndex].Nom = chatForm.Nom;
 
                meute[chatBddIndex].Couleur = chatForm.Couleur;


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
