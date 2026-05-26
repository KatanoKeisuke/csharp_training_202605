using katano.Applications.Domains;
namespace katano.Applications.Services;
/// <summary>
/// 従業員登録サービスインターフェイス
/// </summary>
public interface IEmployeeRegisterService 
{
    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    /// <returns></returns>
    List<Department> GetDepartments();

    /// <summary>
    /// 指定された部署Idの部署を取得する
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <returns></returns>
    Department GetById(int id);

    /// <summary>
<<<<<<< HEAD
=======
    /// すべての部署を取得する
    /// </summary>
    /// <returns></returns>
    List<Employee> GetEmployees();

    /// <summary>
    /// 指定された社員Idの社員を取得する
    /// </summary>
    /// <param name="empid">社員Id</param>
    /// <returns></returns>
    Employee GetByEmpId(int empid);

    /// <summary>
>>>>>>> 85ca7ab (代々優勝)
    /// 新しい従業員を登録する
    /// </summary>
    /// <param name="employee"></param>
    void Register(Employee employee);
}