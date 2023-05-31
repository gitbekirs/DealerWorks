using DealerWorks.Data;
using DealerWorks.Model;
using Microsoft.AspNetCore.Mvc;

namespace DealerWorks.WebUI.Management.Controllers
{
    public class KategoriController : Controller
    {
        KategoriData kategoriData;

        public KategoriController(KategoriData _kategoriData)
        {
            kategoriData = _kategoriData;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var kategoriler = kategoriData.GetBy(i => i.IsDeleted == false);
            return View(kategoriler);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var initialData = new Kategori();
            return View(initialData);
        }


        [HttpPost]
        public IActionResult Add(Kategori yeniKategori)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(yeniKategori.KategoriAdi)) errors.Add("Kategori adı boş olamaz.");

            if (errors.Count > 0)
            {
                ViewBag.Result = string.Join(" *", errors);
                return View(yeniKategori);
            }
            var operationResult = kategoriData.Insert(yeniKategori);
            if (operationResult.IsSucceed)
            {
                ViewBag.Result = "İşlem Başarılı";
                return View(new Kategori()); ;
            }
            ViewBag.Result = "";
            return View(yeniKategori);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var initialData = kategoriData.GetByKey(id);
            if (initialData == null)
                return RedirectToAction("Index", "Home", new { q = "kategori-bulunamadi" });


            return View(initialData);
        }


        [HttpPost]
        public IActionResult Edit(Kategori kategori)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(kategori.KategoriAdi)) errors.Add("Kategori adı boş olamaz.");
            if (errors.Count > 0)
            {
                ViewBag.Result = string.Join(" *", errors);
                return View(kategori);
            }


            var dbKategori = kategoriData.GetByKey(kategori.Id);
            var mevcutKategori = kategoriData.GetBy(i => i.KategoriAdi == kategori.KategoriAdi && i.Id != kategori.Id).Any();
            if (mevcutKategori)
            {
                ViewBag.Result = "Bu isimde kayıtlı kategori zaten var.";
                return View(kategori);
            }

            dbKategori.KategoriAdi = kategori.KategoriAdi;
            dbKategori.GuncellenmeZamani = DateTime.Now;
            dbKategori.IsDeleted = kategori.IsDeleted;

            var operationResult = kategoriData.Insert(kategori);
            if (operationResult.IsSucceed)
            {
                ViewBag.Result = "İşlem Başarılı";
                return View(kategori); ;
            }
            ViewBag.Result = "";
            return View(kategori);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var initialData = kategoriData.GetByKey(id);
            if (initialData == null)
                return RedirectToAction("Index", "Kategori", new { q = "kategori-bulunamadi" });

            initialData.IsDeleted = true;
            initialData.GuncellenmeZamani = DateTime.Now;
            var operationResult = kategoriData.Update(initialData);
            if (operationResult.IsSucceed)
                return RedirectToAction("Index", "Kategori", new { q = "kategori-silindi" });
            else
                return RedirectToAction("Index", "Kategori", new { q = "kategori-silinemedi" });
        }


    }
}
