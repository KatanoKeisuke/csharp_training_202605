using katano.Applications.Domains;

namespace katano.Applications.Services;

/// <summary>

/// 部署登録サービスインターフェイス

/// </summary>

public interface IDepartmentRegisterService 

{
    

    /// 新しい部署を登録する

    /// </summary>

    /// <param name=”department"></param>

    void Register(Department department);

}