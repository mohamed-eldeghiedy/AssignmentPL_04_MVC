using AssignmentBLL.DataTransferObjects;
using AssignmentDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssignmentBLL.Services
{
    
        public class DepartmentServices(IDepartmentRepository departmentRepository) : IDepartmentService
        {


            public int add(DepartmentRequest request)
            {
                var department = request.ToEntity();
                return departmentRepository.Add(department);
            }

            public bool delete(int id)
            {
                var department = departmentRepository.GetById(id);
                if (department == null)
                {
                    return false;
                }
                var result = departmentRepository.Delete(department);
                return result > 0;
            }

            public IEnumerable<DepartmentResponse> GetAll()
            {
                return departmentRepository.GetAll()
                      .Select(d => d.ToResponse());
            }

            public DepartmentDetailsResponse? GetById(int id)
            {
                return departmentRepository.GetById(id)?.ToDetailsResponse();
            }

            public int update(DepartmentUpdateRequest request)
            {
                return departmentRepository.Update(request.ToEntity());
            }

        }
}
