using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mini_projet_net.Models;
using Mini_projet_net.Repositories;
using Mini_projet_net.ViewModels;

namespace Mini_projet_net.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class ArticleController : Controller
    {

        private readonly IArticleRepository _articlerepository;
        private readonly ICategorieRepository _categoryrepository;
        private readonly IWebHostEnvironment hostingEnvironment;


        // Injectez à la fois IArticleRepository et ICategorieRepository dans le constructeur
        public ArticleController(IArticleRepository articlerepository, ICategorieRepository categoryrepository, IWebHostEnvironment hostingEnvironment)
        {
            _articlerepository = articlerepository;
            _categoryrepository = categoryrepository;
            this.hostingEnvironment = hostingEnvironment;

        }
        [AllowAnonymous]
        // GET: ArticleController
        public ActionResult Index()
        {
            ViewBag.categorieId = new SelectList(_categoryrepository.GetAll(), "categorieId", "Namecategorie");


            var article = _articlerepository.GetAll();
            return View(article);
        }

        // GET: ArticleController/Details/5
        public ActionResult Details(int id)
        {
            var article = _articlerepository.GetById(id);
            return View(article);
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
           ViewBag.categorieId = new SelectList(_categoryrepository.GetAll(), "categorieId", "Namecategorie");

            var viewModel = new CreateViewModel();
            return View(viewModel);
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.ImagePath != null)
                {
                    // Votre logique pour télécharger et enregistrer l'image
                    // Par exemple :
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.ImagePath.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                // Créer un nouvel objet Article avec les données du modèle
                Article newArticle = new Article
                {
                    Designation = model.Designation,
                    Prix = model.Prix,
                    Quantite = model.Quantite,
                    Image = uniqueFileName, // Enregistrer le nom du fichier de l'image
                    categorieId = model.categorieId
                };

                // Ajouter le nouvel article à votre repository ou à votre contexte de base de données
                _articlerepository.Add(newArticle);

                // Rediriger vers l'action "Index" ou toute autre action souhaitée
                return RedirectToAction("Index");
            }

            // Si le modèle n'est pas valide, retourner la vue avec le modèle pour afficher les erreurs de validation
            return View(model);
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.categorieId = new SelectList(_categoryrepository.GetAll(), "categorieId", "Namecategorie");
            Article article = _articlerepository.GetById(id);
            EditViewModel articleEditViewModel = new EditViewModel
            {
                articleId = article.articleId,
                Designation = article.Designation,
                Prix = article.Prix,
                Quantite = article.Quantite,
                categorieId=article.categorieId,
                ExistingImagePath = article.Image,

            };
            return View(articleEditViewModel);

        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel model)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                Article article = _articlerepository.GetById(model.articleId);
                article.Designation = model.Designation;
                article.Prix = model.Prix;
                article.Quantite = model.Quantite;
                article.categorieId = model.categorieId;
                if (model.ImagePath != null)
                {
                    if (model.ExistingImagePath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingImagePath);
                        System.IO.File.Delete(filePath);
                    }
                    article.Image = ProcessUploadedFile(model);
                }
                Article updatedArticle = _articlerepository.Update(article);
                ViewBag.categorieId = new SelectList(_categoryrepository.GetAll(), "categorieId", "Namecategorie");
                if (updatedArticle != null)
                    return RedirectToAction("Index");
                else
                    return NotFound();

            }
            return View(model);
        }
        [NonAction]
        private string ProcessUploadedFile(EditViewModel model)
        {
            string uniqueFileName = null;
            if (model.ImagePath != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagePath.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: ArticleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_articlerepository.GetById(id));
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Article a )
        {

            try
            {

                _articlerepository.Delete(a);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Search(string designation, int? categorieId)
        {
            var result = _articlerepository.GetAll();
            if (!string.IsNullOrEmpty(designation))
                result = _articlerepository.FindByDesingnation(designation);
            else
            if (categorieId != null)
                result = _articlerepository.GetArticlesByCategoryID(categorieId);
            ViewBag.categorieId = new SelectList(_categoryrepository.GetAll(), "categorieId", "Namecategorie");
            return View("Index", result);
        }
    }
}
