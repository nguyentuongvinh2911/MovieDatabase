using Comp235MVCDemo.Models;
using Comp235MVCDemo.Models.DataAccessObjects;
using System.Web.Mvc;

/* Sitting
https://www.tutorialsteacher.com/mvc/mvc-view
I learned about the view function, and gain some knowledge of razor codes.

https://jakeydocs.readthedocs.io/en/latest/mvc/views/overview.html
I learned more about view, and how controllers return formatted results using views.
 */

namespace Comp235MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult Movie(Movies m, string Save)
        //{
        //    ViewBag.Message = "My Movie Page.";
        //    MovieDAO dAO = new MovieDAO();
        //    if (Save == "Save")
        //    {
        //        dAO.updateMovie(m);
        //        m.IsEditable = false;
        //        ViewBag.Message = "Movie Updated successfully";
        //    }
        //    return View(m);
        //}

        public ActionResult Movie()
        {
            ViewBag.Message = "My Movie Page.";
            MovieDAO dAO = new MovieDAO();
            Movie movie = dAO.getMovieById(1);
            return View(movie);
        }

        public ActionResult AddMovie(Movie m, string Save) // each view need an Action Result Method to be viewed
        {
            ViewBag.Message = "Add A Movie Page";
            //Save is the name of the Value on the Button
            if (Save == "Save")
            {
                MovieDAO dAO = new MovieDAO();
                dAO.InsertMovie(m);
                ViewBag.Message = "Movie Added successfully";

            }
            return View("AddMovie");
        }

        public ActionResult AllMovies(Movies m, string Save)
        {
            ViewBag.Message = "All movies.";
            MovieDAO dAO = new MovieDAO();
            if (Save == "Save")
            {
                Movie movie = m.Items[m.EditIndex];
                dAO.updateMovie(movie);
                movie.IsEditable = false;
                m.EditIndex = -1;
            }
            m = dAO.getAllMovies();
            return View(m);
        }


        public ActionResult Details(Movie movie, string Save)
        {
            MovieDAO dAO = new MovieDAO();
            if (Save == "Save")
            {
                dAO.updateMovie(movie);
                movie.IsEditable = false;
            }
            movie = dAO.getMovieById(movie.Id);
            return View("Movie", movie);
        }

        public ActionResult MoviesEdit(int? id, Movies movies)
        {
            int id2 = id ?? default(int);
            MovieDAO dAO = new MovieDAO();
            movies = dAO.getAllMovies();
            movies.EditIndex = dAO.setMovieToEditMode(movies.Items, id2);
            ViewBag.Message = "All movies.";
            return View("AllMovies", movies);
        }

        public ActionResult MoviesDelete(Movie movie)
        {
            MovieDAO dAO = new MovieDAO();
            dAO.deleteMovie(movie);
            Movies movies = dAO.getAllMovies();
            ViewBag.Message = "All movies.";
            return View("AllMovies", movies);
        }

        public ActionResult MovieEdit(int? id)
        {
            int id2 = id ?? default(int);
            MovieDAO dAO = new MovieDAO();
            Movie movie = dAO.getMovieById(id2);
            movie.IsEditable = true;
            return View(movie);
        }
    }
}