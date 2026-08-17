using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP.Models.Entities;

namespace AP.Data.Repositories
{
    //SOLID: ISP - contrato especifico
    //DP: Repository Pattern
    public interface IPuzzleRepository
    {
        List<Puzzle> GetAll();

        Puzzle GetById(int id);

        void Add(Puzzle puzzle);

        void Update(Puzzle puzzle);

        void Delete(int id);
    }
}
