using ToDoListProject.DAL.Concrete;
using ToDoListProject.MediatorPattern.Results;

namespace ToDoListProject.MediatorPattern.Handlers
{
    public class GetEventQueryHandler
    {
        private readonly Context _context;

        public GetEventQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetEventQueryResult> Handle()
        {
            var values = _context.Events.Select(x => new GetEventQueryResult
            {
                Description = x.Description,
                End=x.End,
                EventID=x.EventID,
                IsFullDay = x.IsFullDay,
                Start = x.Start,   
                Subject = x.Subject,
                ThemeColor = x.ThemeColor
            }).ToList();
            return values;
        }
    }
}
