using WebAPI_CountryStateCty.Data;
using WebAPI_CountryStateCty.Models;
using WebAPI_CountryStateCty.Repository.IRepository;

namespace WebAPI_CountryStateCty.Repository
{
  public class RegisterRepository : IRegisterRepository
  {
    private readonly ApplicationDbContext _context;
    public RegisterRepository(ApplicationDbContext context)
    {
      _context = context;          
    }
    public bool CreateRegister(Register register)
    {
      _context.Registers.Add(register);
      return Save();
    }

    public bool DeleteRegister(Register registerId)
    {
      _context.Registers.Remove(registerId);
      return Save();
    }

    public Register GetRegister(int registerId)
    {
      return _context.Registers.Find(registerId);
    }

    public ICollection<Register> GetRegisters()
    {
      return _context.Registers.ToList();
    }
    public bool Save()
    {
      return _context.SaveChanges() == 1 ? true : false;
    }

    public bool UpdateRegister(Register register)
    {
      _context.Registers.Update(register);
      return Save();
    }
  }
}
