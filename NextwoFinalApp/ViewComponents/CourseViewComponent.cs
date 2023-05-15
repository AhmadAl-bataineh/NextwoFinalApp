using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NextwoFinalApp.Data;

namespace NextwoFinalApp.ViewComponents
{
    public class CourseViewComponent : ViewComponent
    {
        private FinalDbContext db;
        public CourseViewComponent(FinalDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            var data = db.courses.OrderByDescending(x => x.CreationDate).Take(6);
            return View(data);

        }
    }
}
