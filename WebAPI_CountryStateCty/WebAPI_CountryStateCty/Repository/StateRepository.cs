using WebAPI_CountryStateCty.Data;
using WebAPI_CountryStateCty.Models;
using WebAPI_CountryStateCty.Repository.IRepository;

namespace WebAPI_CountryStateCty.Repository
{
  public class StateRepository : IStateRepository
  {
    private readonly ApplicationDbContext _context;
    public StateRepository(ApplicationDbContext context)
    {
      _context = context;          
    }
    public bool CreateState(State state)
    {
      _context.States.Add(state);
      return Save();
    }

    public State GetState(int stateId)
    {
      return _context.States.Find(stateId);
    }

    public ICollection<State> GetStates()
    {
      return _context.States.ToList();
    }

    public bool Save()
    {
      return _context.SaveChanges()==1?true:false;
    }
  }
}
