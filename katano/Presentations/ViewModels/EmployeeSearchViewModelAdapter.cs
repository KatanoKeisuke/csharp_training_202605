using katano.Applications.Adapters;
using katano.Applications.Domains;
using Microsoft.VisualBasic;
namespace katano.Presentations.ViewModels;
/// <summary>
/// EmployeeRegisterViewModel(社員一覧ViewModel)を
/// ドメインオブジェクト:Employeeに変換するアダプターインターフェイスの実装
/// </summary>
/// <typeparam name="TDomain">Employee</typeparam>
/// <typeparam name="TTarget">EmployeeRegisterForm</typeparam>
public class EmployeeSearchViewModelAdapter : IRestorer<Employee, EmployeeSearchViewModel>,IConverter<Employee, EmployeeSearchViewModel>
{

    public Employee Restore(EmployeeSearchViewModel target)
    {
        // Departentを作成する？
        var department = new Department(target.DeptId); 
        // Employeeを作成する
        var employee = new Employee(target.Name!,department);
        return employee;
      
    }

      /// </summary>
    /// <param name="target">DepartmentRegisterViewModel</param>
    /// <returns>ドメインオブジェクト:Department</returns>
    public EmployeeSearchViewModel Convert(Employee target)
    {
        // Employeeを作成する
              // Department(部署)を作成する
        var employee = new EmployeeSearchViewModel();
        employee.EmpId = target?.EmpId;
        employee.Name = target?.Name;
        employee.DeptId = target?.Department?.Id;
        employee.DeptName = target?.Department?.Name;
        return employee;
      
    }
}