using katano.Applications.Domains;
namespace katano.Applications.Services;
/// <summary>
/// 従業員登録サービスインターフェイス
/// </summary>
public interface IDepartmentRegisterService 
{
    
    /// <summary>
    /// 新しい従業員を登録する
    /// </summary>
    /// <param name="department"></param>
    void Register(Department department);
}