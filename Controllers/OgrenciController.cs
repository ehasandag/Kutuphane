using Microsoft.AspNetCore.Mvc;
using Kutuphane.Data; // Adjust namespace based on your project structure
using Kutuphane.Models; // Adjust namespace based on your models
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Kutuphane.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly KutuphaneDbContext _context;

        public OgrenciController(KutuphaneDbContext context)
        {
            _context = context;
        }

        // GET: Ogrenci
        public async Task<IActionResult> Index()
        {
            var ogrenciler = await _context.Ogrenciler.ToListAsync();
             
            return View(ogrenciler);
        }


        public async Task<IActionResult> Ekle()
        {
            var siniflar = await _context.Siniflar.ToListAsync();
            ViewBag.SinifListesi = new SelectList(siniflar, "Id", "SinifAdi");
            // Debug için 
            Console.WriteLine($"Siniflar: {string.Join(", ", siniflar.Select(s => s.SinifAdi))}");  
            return View();
        }
        // POST: Ogrenci/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle(Ogrenci ogrenci)
        {
            if (!ModelState.IsValid)
    {
        // ModelState hatalarını yazdır
        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        {
            Console.WriteLine($"Hata: {error.ErrorMessage}");
        }
    }

            if (ModelState.IsValid)
            {
                _context.Ogrenciler.Add(ogrenci);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
              var siniflar = await _context.Siniflar.ToListAsync();
            ViewBag.SinifListesi = new SelectList(siniflar, "Id", "SinifAdi");
            return View();
        }

        // GET: Ogrenci/Edit/5
        public IActionResult Guncelle(int id)
        {
            var ogrenci = _context.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        // POST: Ogrenci/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Ogrenci ogrenci)
        {
            if (id != ogrenci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Ogrenciler.Update(ogrenci);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ogrenci);
        }

        // GET: Ogrenci/Delete/5
        public IActionResult Delete(int id)
        {
            var ogrenci = _context.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        // POST: Ogrenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ogrenci = _context.Ogrenciler.Find(id);
            if (ogrenci != null)
            {
                _context.Ogrenciler.Remove(ogrenci);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }

   
    
}