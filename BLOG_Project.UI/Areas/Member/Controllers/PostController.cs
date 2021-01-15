using BLOG_Project.DataAccessLayer.Repositories.Concrete.EfRepositories;
using BLOG_Project.EntityLayer.Enums;
using BLOG_Project.UI.Areas.Member.Data.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG_Project.UI.Areas.Member.Controllers
{
    public class PostController : Controller
    {
        EfPostRepository _postRepo;
        EfAppUserRepository _appUserRepo;
        EfLikeRepository _likeRepo;
        EfCommentRepository _commentRepo;

        public PostController()
        {
            _postRepo = new EfPostRepository();
            _appUserRepo = new EfAppUserRepository();
            _likeRepo = new EfLikeRepository();
            _commentRepo = new EfCommentRepository();
        }

        // GET: Member/Post
        public ActionResult Show(int id)
        {
            PostDetailsVM data = new PostDetailsVM();
            data.Post = _postRepo.GetById(id);
            data.AppUser = _appUserRepo.GetById(data.Post.AppUserId);

            data.Comments = _commentRepo.GetDefault(x => x.PostId == id && x.Status != Status.Passive);

            return View();
        }
    }
}