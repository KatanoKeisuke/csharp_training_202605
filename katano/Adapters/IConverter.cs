namespace katano.Applications.Adapters;
/// <summary>
/// TDomainに指定されたドメインオブジェクトをTTargetに指定されたクラスに変換するインターフェイス
/// </summary>
<<<<<<< HEAD
/// <typeparam name="TDomain">ドメインオブジェクトの型</typeparam>
=======
/// <typeparam name="TDomain">ドメインオaブジェクトの型</typeparam>
>>>>>>> 85ca7ab (代々優勝)
/// <typeparam name="TTarget">変換クラスの型</typeparam>
public interface IConverter<TDomain, TTarget>
{
    /// <summary>
    /// TDomainに指定されたドメインオブジェクトをTTargetに指定されたクラスに変換する
    /// </summary>
    /// <param name="domain">ドメインオブジェクト</param>
    /// <returns>変換結果</returns>
    TTarget Convert(TDomain domain);
}