using WebAPI_CountryStateCty.Models;

namespace WebAPI_CountryStateCty.Repository.IRepository
{
  public interface IStateRepository
  {
    ICollection<State> GetStates();
    State GetState(int stateId);
    bool CreateState(State state);
    bool Save();
  }
}
