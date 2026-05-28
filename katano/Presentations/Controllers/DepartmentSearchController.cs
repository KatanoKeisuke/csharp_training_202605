using Microsoft.AspNetCore.Mvc;
using katano.Applications.Services;
using katano.Presentations.ViewModels;

namespace katano.Presentations.Controllers;
/// <summary>
/// リスト4-3 
/// Razor構文の利用
/// </summary>
[Route("DepartmentSearch")]
public class DepartmentSearchController : Controller
{
    /// <summary>
    /// ロガー
    /// </summary>
    private readonly ILogger<DepartmentSearchController> _logger;
    /// <summary>
    /// 部署登録サービスインターフェイス
    /// </summary>
    private readonly IEmployeeRegisterService _employeeRegisterService;
    /// <summary>
    /// 社員登録ViewModelをDepartmentに変換するアダプター
    /// </summary>
    private readonly DepartmentSearchViewModelAdapter _adapter;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="employeeSearchService">部署登録サービスインターフェイス</param>
    /// <param name="employeeRegisterViewModelAdapter">部署登録ViewModelをDepartmentに変換するアダプター</param>
    /// <param name="empDataStore">TempDataを通じて一時的にViewModelを保存・復元するためのクラス</param>
    public DepartmentSearchController(
        ILogger<DepartmentSearchController> logger,
        IEmployeeRegisterService employeeRegisterService,
        DepartmentSearchViewModelAdapter departmentSearchViewModelAdapter)
    {
        _logger = logger;
        _employeeRegisterService = employeeRegisterService;
        _adapter = departmentSearchViewModelAdapter;
    }
    /// <summary>
    /// ViewModel SampleFormのListをRazor View Show.cshtmlに渡す
    /// </summary>
    /// <returns></returns>
    [HttpGet("Search")]
    public ActionResult Search()
    {
        var departments = _employeeRegisterService.GetDepartments();
        Console.WriteLine($"{departments.Count} debugu------------------------");
        //　DepartmentViewModelのリストを作成する
        List<DepartmentSearchViewModel> departmentSearchViewModels = new List<DepartmentSearchViewModel>();
        foreach (var dept in departments)
        {
            //Adapterを使いDepartmentからDepartmentSearchViewModelに変換する 
            var viewModel = _adapter.Convert(dept);
            //departmentSearchViewModelsにviewModelをAddする
            departmentSearchViewModels.Add(viewModel);
        }
        Console.WriteLine($"{departmentSearchViewModels.Count} debugu------------------------");
        //return view で引数にviewmodelのリストを渡す
        return View(departmentSearchViewModels);

    }
}