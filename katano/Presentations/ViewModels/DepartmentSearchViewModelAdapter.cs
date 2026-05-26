using katano.Applications.Adapters;
using katano.Applications.Domains;
namespace katano.Presentations.ViewModels;
/// <summary>
/// DepartmentRegisterViewModel(部署登録ViewModel)を
/// ドメインオブジェクト:Departmentに変換するアダプターインターフェイスの実装
/// </summary>
/// <typeparam name="TDomain">Department</typeparam>
/// <typeparam name="TTarget">DepartmentRegisterForm</typeparam>
public class DepartmentSearchViewModelAdapter : IRestorer<Department, DepartmentSearchViewModel>,IConverter<Department, DepartmentSearchViewModel>
{
    /// <summary>
    /// DepartmentRegisterViewModelをドメインオブジェクト:Departmentに変換する
    /// </summary>
    /// <param name="target">DepartmentRegisterViewModel</param>
    /// <returns>ドメインオブジェクト:Department</returns>
    public Department Restore(DepartmentSearchViewModel target)
    {
        // Department(部署)を作成する
        var department = new Department(target.DeptName);
        return department;
    }

      /// </summary>
    /// <param name="target">DepartmentRegisterViewModel</param>
    /// <returns>ドメインオブジェクト:Department</returns>
    public DepartmentSearchViewModel Convert(Department target)
    {
        // Department(部署)を作成する
        var department = new DepartmentSearchViewModel();
        department.DeptId = target.Id;
        department.DeptName = target.Name;
        return department;
    }
}