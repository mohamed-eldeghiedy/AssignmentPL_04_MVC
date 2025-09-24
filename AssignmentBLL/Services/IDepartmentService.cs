using AssignmentBLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBLL.Services
{
    public interface IDepartmentService
    {

        DepartmentDetailsResponse? GetById(int id);

        IEnumerable<DepartmentResponse> GetAll();

        int update(DepartmentUpdateRequest request);
        bool delete(int id);

        int add(DepartmentRequest request);
    }
}
