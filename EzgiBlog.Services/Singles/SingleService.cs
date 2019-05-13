using EzgiBlog.Data.DTO;
using EzgiBlog.Data.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EzgiBlog.Service.Singles
{
    public class SingleService :ISingleService
    {
        private EzgiBlogDbEntities _db;

        public SingleService(EzgiBlogDbEntities db)
        {
            _db = db;

        }
        public List<SingleDTO> GetSingles()
        {
            var single = _db.Singles.Select(s => new SingleDTO
            {
                Id = s.Id,
                Text=s.Text
                 
            }).ToList();
            return single;
        }

        public SingleDTO GetSingleById(int id)
        {
            var single = _db.Singles.FirstOrDefault(x => x.Id == id);

            if (single == null) return new SingleDTO();

            return new SingleDTO
            {
                Id = single.Id,
                Text=single.Text
            };
        }
    }
}
