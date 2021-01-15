using BLOG_Project.DataAccessLayer.Repositories.Concrete.EfRepositories;
using BLOG_Project.EntityLayer.Entities.Concrete;
using BLOG_Project.UI.Areas.Admin.Data.DTOs;
using BLOG_Project.Utility.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG_Project.UI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {
        private EfAppUserRepository _repo;

        public AppUserController() => _repo = new EfAppUserRepository();

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(AppUser data, HttpPostedFileBase Image)
        {
            List<string> UploadImagePaths = new List<string>();
            UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.UserImage = UploadImagePaths[0];

            if (data.UserImage == "1" || data.UserImage == "2" || data.UserImage == "3")
            {
                data.UserImage = ImageUploader.DefaultProfileImagePath;
                data.XSmallUserImage = ImageUploader.DefaultXSmallProfileImagePath;
                data.CruptedUserImage = ImageUploader.DefaultCruptedProfileImagePath;
            }
            else
            {
                data.XSmallUserImage = UploadImagePaths[1];
                data.CruptedUserImage = UploadImagePaths[2];
            }

            _repo.Add(data);
            return Redirect("/Admin/AppUser/List");
        }

        public ActionResult List() => View(_repo.GetActive());

        public ActionResult Update(int id)
        {
            AppUser appUser = _repo.GetById(id);
            AppUserDTO model = new AppUserDTO();
            model.Id = appUser.Id;
            model.FirstName = appUser.FirstName;
            model.LastName = appUser.LastName;
            model.UserName = appUser.UserName;
            model.Password = appUser.Password;
            model.Role = appUser.Role;
            model.UserImage = appUser.UserImage;
            model.XSmallUserImage = appUser.XSmallUserImage;
            model.CruptedUserImage = appUser.CruptedUserImage;
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(AppUserDTO model, HttpPostedFileBase Image)
        {
            AppUser appUser = _repo.GetById(model.Id);
            List<string> UploadImagePaths = new List<string>();
            UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            model.UserImage = UploadImagePaths[0];

            if (model.UserImage == "1" || model.UserImage == "2" || model.UserImage == "3")
            {
                if (appUser.UserImage == null || appUser.UserImage == ImageUploader.DefaultProfileImagePath)
                {
                    appUser.UserImage = ImageUploader.DefaultProfileImagePath;
                    appUser.XSmallUserImage = ImageUploader.DefaultXSmallProfileImagePath;
                    appUser.CruptedUserImage = ImageUploader.DefaultCruptedProfileImagePath;
                }
            }
            else
            {
                appUser.UserImage = UploadImagePaths[0];
                appUser.XSmallUserImage = UploadImagePaths[1];
                appUser.CruptedUserImage = UploadImagePaths[2];
            }

            appUser.FirstName = model.FirstName;
            appUser.LastName = model.LastName;
            appUser.UserName = model.UserName;
            appUser.Password = model.Password;
            appUser.Role = model.Role;
            _repo.Update(appUser);
            return Redirect("/Admin/AppUser/List");
        }

        public ActionResult Delete(int id)
        {
            _repo.Remove(id);
            return Redirect("/Admin/AppUser/List");
        }













    }
}