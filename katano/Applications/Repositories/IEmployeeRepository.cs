using katano.Applications.Domains;   
namespace katano.Applications.Repositories;
/// <summary>
/// ドメインオブジェクト:社員のCRUD操作インターフェイス
/// </summary>
public interface IEmployeeRepository
{
        /// <summary>
    /// すべての社員を取得する
    /// </summary>
    /// <returns>社員のリスト</returns>
    List<Employee> FindAll();

    /// <summary>
    /// 指定された社員Idの社員を取得する
    /// </summary>
    /// <param name="id">社員Id</param>
    /// <returns>取得して社員</returns>
    Employee? FindById(int id);
    /// <summary>
    /// 社員を永続化する
    /// </summary>
    /// <param name="employee">永続化対象の社員</param>
    void Create(Employee employee);
}