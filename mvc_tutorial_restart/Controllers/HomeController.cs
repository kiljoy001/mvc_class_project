using mvc_tutorial_restart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_tutorial_restart.Controllers
{
    public class HomeController : Controller
    {
        DBModel storeDB = new DBModel();
        // GET: Store
        [AllowAnonymous]
        public ActionResult Index()
        {
           return View();
        }
       // get: /Store/Browse
       public ActionResult Browse()
        {
            var genreModel = storeDB.Genres.ToList();
            return View(genreModel);
        }
        // get: /Store/Details
        public ActionResult GenreDetails(string genre)
        {
            //Returns an entity object
            var listGenreDetails = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);
            //Need to specify what property of the enity object you want
            return View(listGenreDetails.Albums);
        }
        public ActionResult AlbumDetails(string album)
        {
            //returns an entity object
            var listAlbumDetails = storeDB.Albums.ToList();
            var match = listAlbumDetails.Where(a => a.Title == album);
            //pass object to view
            return View(match);
        }
    }
}