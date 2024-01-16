using WebAPI_CountryStateCty.Models;

namespace WebAPI_CountryStateCty.Repository.IRepository
{
  public interface IRegisterRepository
  {
    ICollection<Register> GetRegisters();
    Register GetRegister(int registerId);
    bool CreateRegister(Register register);
    bool UpdateRegister(Register register);
    bool DeleteRegister(Register registerId);
    bool Save();
  }
}
