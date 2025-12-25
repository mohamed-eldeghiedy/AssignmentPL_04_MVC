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

        Task<DepartmentDetailsResponse?> GetByIdAsync(int id);

        Task <IEnumerable<DepartmentResponse>> GetAllAsync();

        Task<int> updateAsync(DepartmentUpdateRequest request);
        Task<bool> deleteAsync(int id);

        Task<int> addAsync(DepartmentRequest request);
    }
}
