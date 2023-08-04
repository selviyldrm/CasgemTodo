using ToDoListProject.DAL.Concrete;
using ToDoListProject.MediatorPattern.Commands;

namespace ToDoListProject.MediatorPattern.Handlers
{
    public class RemoveEventCommandHandler
    {
        private readonly Context _context;

        public RemoveEventCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(int id)
        {
            var values = _context.Events.Find(id);
            _context.Events.Remove(values);
            _context.SaveChanges();
        }
    }
}
