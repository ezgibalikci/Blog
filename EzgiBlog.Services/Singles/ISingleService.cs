using EzgiBlog.Data.DTO;
using System.Collections.Generic;

namespace EzgiBlog.Service.Singles
{
    public interface ISingleService
    {
        List<SingleDTO> GetSingles();
        SingleDTO GetSingleById(int id);
    }
}