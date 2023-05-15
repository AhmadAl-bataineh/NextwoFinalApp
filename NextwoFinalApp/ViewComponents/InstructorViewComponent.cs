using Microsoft.AspNetCore.Mvc;
using NextwoFinalApp.Data;

namespace NextwoFinalApp.ViewComponents
{
    public class InstructorViewComponent : ViewComponent
    {
        private FinalDbContext db;
        public InstructorViewComponent(FinalDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            var data = db.instructors.OrderByDescending(x => x.CreationDate).Take(6);
            return View(data);

        }
    }
}
