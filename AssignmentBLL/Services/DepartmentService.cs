using AssignmentBLL.DataTransferObjects;
using AssignmentDAL.Entities;
using AssignmentDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssignmentBLL.Services
{
    
        public class DepartmentServices(IUnitOfWork unitOfWork ) : IDepartmentService
        {


            public async Task<int> addAsync(DepartmentRequest request)
            {
                var department = request.ToEntity();
                unitOfWork.Departments.Add(department);
                return await unitOfWork.SaveChangesAsync();
        }

            public async Task<bool> deleteAsync(int id)
            {
                var department = await unitOfWork.Departments.GetByIdAsync(id);
                if (department == null)
                {
                    return false;
                }
                unitOfWork.Departments.Delete(department);
                return await unitOfWork.SaveChangesAsync() > 0;
            }

            public async Task<IEnumerable<DepartmentResponse>> GetAllAsync()
            {
                return (await unitOfWork.Departments.GetAllAsync())
                      .Select(d => d.ToResponse());
            }

            public async Task<DepartmentDetailsResponse?> GetByIdAsync(int id)
            {
                var department = await unitOfWork.Departments.GetByIdAsync(id);
            return  department?.ToDetailsResponse();
            }

            public async Task<int> updateAsync(DepartmentUpdateRequest request)
            {
               unitOfWork.Departments.Update(request.ToEntity());
               return await unitOfWork.SaveChangesAsync();
        }

        }
}
