using katano.Applications.Adapters;
using katano.Applications.Domains;
using katano.Infrastructures.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
namespace katano.Infrastructures.Adapters;
/// <summary>
/// ドメインオブジェクト:EmployeeとEmployeeEntityの相互変換インターフェイスの実装
/// </summary>
/// <typeparam name="TDomain">Employee</typeparam>
/// <typeparam name="TTarget">EmployeeEntity</typeparam>
public class EmployeeEntityAdapter :
IConverter<Employee, EmployeeEntity>, IRestorer<Employee, EmployeeEntity>
{
    /// <summary>
    /// ドメインオブジェクト:EmployeeをEmployeeEntityに変換する
    /// </summary>
    /// <param name="domain">ドメインモデル:社員</param>
    /// <returns>EmployeeEntity</returns>
    public EmployeeEntity Convert(Employee domain)
    {
        var entity = new EmployeeEntity
        {
            EmpName = domain.Name
        };
        if (domain.EmpId != null)
        {
            entity.EmpId = domain.EmpId.Value;
        }
        if (domain.Department != null)
        {
            entity.DeptId = domain.Department.Id;
        }
        return entity;
    }

    /// <summary>
    /// EmployeeEntityからドメインオブジェクト:Employeeを復元する
    /// </summary>
    /// <param name="target">EmployeeEntity</param>
    /// <returns>ドメインオブジェクト:Employee</returns>
    public Employee Restore(EmployeeEntity target)
    {

        var employee = new Employee(
            target.EmpId,
            target.EmpName,
            null
//            new Department(target.Department.DeptId,target.Department.DeptName)
        );
        //DepartmentEntityからDepartmentに変換
        DepartmentEntity deptEntity = target.Department!;
        int deptId = deptEntity.DeptId;
        string deptName = deptEntity.DeptName;
        Department department = new Department(deptId,deptName);
        employee.ChangeDepartment(department) ;
       
        return employee;
    }
}