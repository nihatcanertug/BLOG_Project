using BLOG_Project.DataAccessLayer.Repositories.Concrete.EfRepositories;
using BLOG_Project.EntityLayer.Entities.Concrete;
using BLOG_Project.EntityLayer.Enums;
using BLOG_Project.UI.Areas.Admin.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG_Project.UI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private EfCategoryRepository _repo;

        public CategoryController() => _repo = new EfCategoryRepository();

        // GET: Admin/Category
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category data)
        {
            _repo.Add(data);
            return Redirect("/Admin/Category/List");
        }

        public ActionResult List() => View(_repo.GetActive());

        public ActionResult Update(int id)
        {
            Category category = _repo.GetById(id);
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.Id = category.Id;
            categoryDTO.Name = category.Name;
            return View(categoryDTO);
        }

        [HttpPost]
        public ActionResult Update(CategoryDTO model)
        {
            Category category = _repo.GetById(model.Id);
            category.Name = model.Name;
            category.UpdateDate = DateTime.Now;
            category.Status = Status.Modified;
            _repo.Update(category);
            return Redirect("/Admin/Category/List");
        }

        public ActionResult Delete(int id)
        {
            _repo.Remove(id);
            return Redirect("/Admin/Category/List");
        }


    }
}